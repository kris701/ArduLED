using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ArduLEDNameSpace
{
    public class ServerAPISection : IDisposable
    {
        public bool IsDisposed = false;
        private bool ServerRunning = false;
        private bool ServerEnded = true;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public TcpListener ServerListener;
        public TcpClient ClientSocket;
        public Thread ServerThread;
        private MainForm MainFormClass;
        public bool RunningCommand = false;
        private int TotalLEDCount = 0;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool _Disposing)
        {
            if (IsDisposed)
                return;

            if (_Disposing)
            {
                handle.Dispose();
                if (ServerListener != null)
                    ServerListener.Stop();
                if (ClientSocket != null)
                    ClientSocket.Close();
                if (ServerRunning)
                {
                    ServerRunning = false;
                }
                while (!ServerEnded)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
                if (ServerThread != null)
                    ServerThread.Abort();
            }

            IsDisposed = true;
        }

        public ServerAPISection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public void InitializeServer()
        {
            if (ServerRunning)
            {
                ServerRunning = false;
            }
            while (!ServerEnded)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            ServerRunning = true;
            ServerThread = new Thread(RunServer);
            ServerThread.Start();
        }

        public void StopServer()
        {
            if (ServerRunning)
            {
                ServerRunning = false;
                while (!ServerEnded)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Disconnected!" + Environment.NewLine; });
            }
            else
                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server not running!" + Environment.NewLine; });
        }

        private void RunServer()
        {
            ServerEnded = false;
            try
            {
                if (ServerListener != null)
                    ServerListener.Stop();
                if (ClientSocket != null)
                    ClientSocket.Close();
                ClientSocket = null;
                ServerListener = null;
                IPAddress ServerIP = IPAddress.None;
                int ServerPort = 0;
                MainFormClass.ServerSettingsIPAddressTextBox.Invoke((MethodInvoker)delegate { ServerIP = IPAddress.Parse(MainFormClass.ServerSettingsIPAddressTextBox.Text); });
                MainFormClass.ServerSettingsPortTextBox.Invoke((MethodInvoker)delegate { ServerPort = Int32.Parse(MainFormClass.ServerSettingsPortTextBox.Text); });
                ServerListener = new TcpListener(ServerIP, ServerPort);
                ClientSocket = default(TcpClient);

                ServerListener.Start();

                ConnectToClient();
            }
            catch(Exception E)
            {
                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += E; });
                MessageBox.Show("Error with Server Settings");
                ServerRunning = false;
            }

            while (ServerRunning)
            {
                try
                {
                    if (!ClientSocket.Connected)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Client Disconnected!" + Environment.NewLine; });
                        if (!ConnectToClient())
                            break;
                    }
                    NetworkStream DataStream = ClientSocket.GetStream();
                    byte[] ReadBytes = new byte[1024];
                    DataStream.Read(ReadBytes, 0, 1024);
                    DataStream.Flush();
                    string ClientData = System.Text.Encoding.ASCII.GetString(ReadBytes);
                    if (ClientData.IndexOf("$") > 0)
                    {
                        ClientData = ClientData.Substring(0, ClientData.IndexOf("$"));

                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Recieved: " + ClientData + Environment.NewLine; });

                        string Out = ArduLEDServerAPI(ClientData);

                        RunningCommand = false;

                        //Use for debug
                        //if (Out != "")
                        //{
                        //    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(Out);
                        //    DataStream.Write(SendBytes, 0, SendBytes.Length);
                        //    DataStream.Flush();
                        //}
                        if (Out != "N")
                            MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += " Command Done!" + Environment.NewLine; });
                        else
                            MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += " Bad Input!!" + Environment.NewLine; });

                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.SelectionStart = MainFormClass.ServerSettingsConsoleTextBox.TextLength - 1; });
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.ScrollToCaret(); });
                    }
                    else
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Client Disconnected!" + Environment.NewLine; });
                        ServerListener.Stop();
                        ServerListener.Start();
                        if (!ConnectToClient())
                            break;
                    }
                }
                catch
                {
                    MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Client Disconnected!" + Environment.NewLine; });
                    ServerListener.Stop();
                    ServerListener.Start();
                    if (!ConnectToClient())
                        break;
                }
            }
            ServerListener.Stop();
            MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Closed!" + Environment.NewLine; });
            ServerEnded = true;
        }

        private bool ConnectToClient()
        {
            try
            {
                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server waiting connections!" + Environment.NewLine; });
                while (!ServerListener.Pending())
                {
                    if (!ServerRunning)
                        break;
                    Thread.Sleep(100);
                }
                if (ServerRunning)
                {
                    ClientSocket = ServerListener.AcceptTcpClient();
                    NetworkStream DataStream = ClientSocket.GetStream();
                    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes("G");
                    DataStream.Write(SendBytes, 0, SendBytes.Length);
                    DataStream.Flush();
                    MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Connected!" + Environment.NewLine; });
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return true;
            }
        }

        private string ArduLEDServerAPI(string _Input)
        {
            RunningCommand = true;
            try
            {
                string[] InputSplit = _Input.Split(',');

                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     Running Command: " + InputSplit[0].ToUpper().Split('(')[0] + " ... "; });

                //GETTOTALLEDCOUNT()

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETTOTALLEDCOUNT(", ""), "").ToUpper() == "GETTOTALLEDCOUNT(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETTOTALLEDCOUNT(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    TotalLEDCount = MainFormClass.TotalLEDCount;
                    NetworkStream DataStream = ClientSocket.GetStream();
                    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(TotalLEDCount.ToString());
                    DataStream.Write(SendBytes, 0, SendBytes.Length);
                    DataStream.Flush();
                    return "G";
                }

                //GETSERVERNAME()

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETSERVERNAME(", ""), "").ToUpper() == "GETSERVERNAME(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETSERVERNAME(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    NetworkStream DataStream = ClientSocket.GetStream();
                    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(MainFormClass.ServerSettingsServerNameTextbox.Text);
                    DataStream.Write(SendBytes, 0, SendBytes.Length);
                    DataStream.Flush();
                    return "G";
                }

                //FADECOLOR(True,0,-1,255,0,255,20,10)

                if (InputSplit[0].Replace(InputSplit[0].Replace("FADECOLOR(", ""), "").ToUpper() == "FADECOLOR(")
                {
                    InputSplit[0] = InputSplit[0].Replace("FADECOLOR(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    MainFormClass.FadeColorsSectionClass.FadeColorsSendData(
                        Convert.ToBoolean(InputSplit[0]),
                        Int32.Parse(InputSplit[1]),
                        Int32.Parse(InputSplit[2]),
                        Color.FromArgb(Int32.Parse(InputSplit[3]), Int32.Parse(InputSplit[4]), Int32.Parse(InputSplit[5])),
                        Int32.Parse(InputSplit[6]),
                        Convert.ToDouble(InputSplit[7].Replace('.',','))
                        );
                    MainFormClass.MenuPanel.Invoke((MethodInvoker)delegate
                    {
                        MainFormClass.FadeLEDPanelFromIDNumericUpDown.Value = Int32.Parse(InputSplit[1]);
                        MainFormClass.FadeLEDPanelToIDNumericUpDown.Value = Int32.Parse(InputSplit[2]);
                        MainFormClass.FadeColorsRedTrackBar.Value = Int32.Parse(InputSplit[3]);
                        MainFormClass.FadeColorsGreenTrackBar.Value = Int32.Parse(InputSplit[4]);
                        MainFormClass.FadeColorsBlueTrackBar.Value = Int32.Parse(InputSplit[5]);
                        MainFormClass.FadeColorsFadeSpeedNumericUpDown.Value = Int32.Parse(InputSplit[6]);
                        MainFormClass.FadeColorsFadeFactorNumericUpDown.Value = Convert.ToDecimal(InputSplit[7].Replace('.', ','));

                        MainFormClass.FadeColorsRedLabel.Text = MainFormClass.FadeColorsRedTrackBar.Value.ToString();
                        MainFormClass.FadeColorsGreenLabel.Text = MainFormClass.FadeColorsGreenTrackBar.Value.ToString();
                        MainFormClass.FadeColorsBlueLabel.Text = MainFormClass.FadeColorsBlueTrackBar.Value.ToString();
                    });
                    return "G";
                }

                //INDIVIDUALCOLOR(3,40,0,255,255)

                if (InputSplit[0].Replace(InputSplit[0].Replace("INDIVIDUALCOLOR(", ""), "").ToUpper() == "INDIVIDUALCOLOR(")
                {
                    InputSplit[0] = InputSplit[0].Replace("FADECOLOR(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    string SerialOut = "4;" + InputSplit[0] + ";" + InputSplit[1] + ";" + InputSplit[2] + ";" + InputSplit[3] + ";" + InputSplit[4];
                    MainFormClass.SendDataBySerial(SerialOut);
                    return "G";
                }

                //VISUALIZER(False,True,test.txt)

                if (InputSplit[0].Replace(InputSplit[0].Replace("VISUALIZER(", ""), "").ToUpper() == "VISUALIZER(")
                {
                    InputSplit[0] = InputSplit[0].Replace("VISUALIZER(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    if (InputSplit[2] != "")
                    {
                        try
                        {
                            string SerialOut = "";
                            MainFormClass.VisualizerPanel.Invoke((MethodInvoker)delegate
                            {
                                MainFormClass.LoadSettings(Directory.GetCurrentDirectory() + "\\VisualizerSettings\\" + InputSplit[2]);
                            });
                            MainFormClass.VisualizerFromSeriesIDNumericUpDown.Invoke((MethodInvoker)delegate
                            {
                                MainFormClass.VisualizerToSeriesIDNumericUpDown.Invoke((MethodInvoker)delegate
                                {
                                    SerialOut = "6;" + MainFormClass.VisualizerFromSeriesIDNumericUpDown.Value + ";" + MainFormClass.VisualizerToSeriesIDNumericUpDown.Value;
                                });
                            });
                            MainFormClass.SendDataBySerial(SerialOut);
                        }
                        catch (Exception E)
                        {
                            MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                        }
                    }

                    if (InputSplit[0] == "True")
                    {
                        MainFormClass.VisualizerPanel.Invoke((MethodInvoker)delegate
                        {
                            MainFormClass.VisualizerSectionClass.EnableBASS(true);
                        });
                    }
                    if (InputSplit[1] == "True")
                    {
                        MainFormClass.VisualizerSectionClass.EnableBASS(false);
                    }
                    return "G";
                }

                //GETVISUALIZERCONFIGS()

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETVISUALIZERCONFIGS(", ""), "").ToUpper() == "GETVISUALIZERCONFIGS(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETVISUALIZERCONFIGS(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    string SendString = " ";

                    foreach(string _File in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\VisualizerSettings"))
                    {
                        SendString += _File.Split('\\')[_File.Split('\\').Length - 1] + ";";
                    }

                    NetworkStream DataStream = ClientSocket.GetStream();
                    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(SendString);
                    DataStream.Write(SendBytes, 0, SendBytes.Length);
                    DataStream.Flush();
                    return "G";
                }

                //AMBILIGHT(True,False,True,False,wew5.txt)

                if (InputSplit[0].Replace(InputSplit[0].Replace("AMBILIGHT(", ""), "").ToUpper() == "AMBILIGHT(")
                {
                    InputSplit[0] = InputSplit[0].Replace("AMBILIGHT(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    if (InputSplit[4] != "")
                    {
                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                            MainFormClass.LoadSettings(Directory.GetCurrentDirectory() + "\\AmbilightSettings\\" + InputSplit[4]);
                            MainFormClass.AmbiLightSectionClass.SetSides();
                        });
                    }
                    if (InputSplit[0] == "True")
                    {
                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                            MainFormClass.AmbiLightSectionClass.StartAmbilight(
                                    (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                    (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value,
                                    (double)MainFormClass.AmbiLightModeGammaFactorNumericUpDown.Value,
                                    (double)MainFormClass.AmbiLightModeFadeFactorNumericUpDown.Value,
                                    (int)MainFormClass.AmbiLightModeRefreshRateNumericUpDown.Value
                                    );
                        });
                    }
                    if (InputSplit[1] == "True")
                    {
                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                            MainFormClass.AmbiLightSectionClass.StopAmbilight();
                        });
                    }
                    if (InputSplit[2] == "True")
                    {
                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                            MainFormClass.AmbiLightSectionClass.ShowBlocks(
                                (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value
                                );
                        });
                    }
                    if (InputSplit[3] == "True")
                    {
                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                            MainFormClass.AmbiLightSectionClass.AutoSetOffsets(
                                (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value
                                );
                        });
                    }
                    return "G";
                }

                //GETAMBILIGHTCONFIGS()

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETAMBILIGHTCONFIGS(", ""), "").ToUpper() == "GETAMBILIGHTCONFIGS(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETAMBILIGHTCONFIGS(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    string SendString = " ";

                    foreach (string _File in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\AmbilightSettings"))
                    {
                        SendString += _File.Split('\\')[_File.Split('\\').Length - 1] + ";";
                    }

                    NetworkStream DataStream = ClientSocket.GetStream();
                    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(SendString);
                    DataStream.Write(SendBytes, 0, SendBytes.Length);
                    DataStream.Flush();
                    return "G";
                }

                //ANIMATION(True,False,True,wew5.txt)

                if (InputSplit[0].Replace(InputSplit[0].Replace("ANIMATION(", ""), "").ToUpper() == "ANIMATION(")
                {
                    InputSplit[0] = InputSplit[0].Replace("ANIMATION(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    if (InputSplit[3] != "")
                    {
                        MainFormClass.AnimationModePanel.Invoke((MethodInvoker)delegate
                        {
                            MainFormClass.AnimationModeSectionClass.LoadAnimation(Directory.GetCurrentDirectory() + "\\Animations\\" + InputSplit[3]);
                        });
                    }
                    if (InputSplit[0] == "True")
                    {
                        MainFormClass.AnimationModePanel.Invoke((MethodInvoker)delegate
                        {
                            if (!MainFormClass.AnimationModeSectionClass.AnimationRunning)
                            {
                                MainFormClass.AnimationModeSectionClass.MoveInterval = (int)MainFormClass.AnimationModeMoveIntervalNumericUpDown.Value;
                                MainFormClass.AnimationModeSectionClass.ContinueAnimationLoop = true;
                                MainFormClass.AnimationModeSectionClass.RunAnimation();
                            }
                        });
                    }
                    if (InputSplit[1] == "True")
                    {
                        MainFormClass.AnimationModePanel.Invoke((MethodInvoker)delegate
                        {
                            if (MainFormClass.AnimationModeSectionClass.ContinueAnimationLoop)
                                if (MainFormClass.AnimationModeSectionClass.AnimationRunning)
                                    MainFormClass.AnimationModeSectionClass.StopAnimationLoop = true;
                        });
                    }
                    MainFormClass.AnimationModePanel.Invoke((MethodInvoker)delegate {
                        MainFormClass.AnimationModeLoopCheckBox.Checked = Convert.ToBoolean(InputSplit[2]);
                    });
                    return "G";
                }

                //GETANIMATIONCONFIGS()

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETANIMATIONCONFIGS(", ""), "").ToUpper() == "GETANIMATIONCONFIGS(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETANIMATIONCONFIGS(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    string SendString = " ";

                    foreach (string _File in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Animations"))
                    {
                        SendString += _File.Split('\\')[_File.Split('\\').Length - 1] + ";";
                    }

                    NetworkStream DataStream = ClientSocket.GetStream();
                    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(SendString);
                    DataStream.Write(SendBytes, 0, SendBytes.Length);
                    DataStream.Flush();
                    return "G";
                }

                //INSTRUCTIONS(True,False,True,wew5.txt)

                if (InputSplit[0].Replace(InputSplit[0].Replace("INSTRUCTIONS(", ""), "").ToUpper() == "INSTRUCTIONS(")
                {
                    InputSplit[0] = InputSplit[0].Replace("INSTRUCTIONS(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    if (InputSplit[3] != "")
                    {
                        MainFormClass.InstructionsPanel.Invoke((MethodInvoker)delegate
                        {
                            MainFormClass.InstructionsSectionClass.LoadInstructions(Directory.GetCurrentDirectory() + "\\Instructions\\" + InputSplit[3]);
                        });
                    }
                    if (InputSplit[0] == "True")
                    {
                        MainFormClass.InstructionsPanel.Invoke((MethodInvoker)delegate
                        {
                            if (!MainFormClass.InstructionsSectionClass.InstructionsRunning)
                            {
                                MainFormClass.InstructionsSectionClass.ContinueInstructionsLoop = true;
                                MainFormClass.InstructionsSectionClass.RunInstructions();
                            }
                        });
                    }
                    if (InputSplit[1] == "True")
                    {
                        MainFormClass.InstructionsPanel.Invoke((MethodInvoker)delegate
                        {
                            if (MainFormClass.InstructionsSectionClass.ContinueInstructionsLoop)
                                if (MainFormClass.InstructionsSectionClass.InstructionsRunning)
                                    MainFormClass.InstructionsSectionClass.StopInstructionsLoop = true;
                        });
                    }
                    MainFormClass.InstructionsPanel.Invoke((MethodInvoker)delegate {
                        MainFormClass.InstructionsLoopCheckBox.Checked = Convert.ToBoolean(InputSplit[2]);
                    });
                    return "G";
                }

                //GETINSTRUCTIONSCONFIGS()

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETINSTRUCTIONSCONFIGS(", ""), "").ToUpper() == "GETINSTRUCTIONSCONFIGS(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETINSTRUCTIONSCONFIGS(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    string SendString = " ";

                    foreach (string _File in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Instructions"))
                    {
                        SendString += _File.Split('\\')[_File.Split('\\').Length - 1] + ";";
                    }

                    NetworkStream DataStream = ClientSocket.GetStream();
                    Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(SendString);
                    DataStream.Write(SendBytes, 0, SendBytes.Length);
                    DataStream.Flush();
                    return "G";
                }

                //CLICKBUTTON(ServerSettingsClearConsoleButton,0)

                if (InputSplit[0].Replace(InputSplit[0].Replace("CLICKBUTTON(", ""), "").ToUpper() == "CLICKBUTTON(")
                {
                    InputSplit[0] = InputSplit[0].Replace("CLICKBUTTON(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        Button CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as Button;
                        CallControl.Invoke((MethodInvoker)delegate { CallControl.PerformClick(); });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //SETTEXTCONTROL(ServerSettingsConsoleTextBox,0,wew lad)

                if (InputSplit[0].Replace(InputSplit[0].Replace("SETTEXTCONTROL(", ""), "").ToUpper() == "SETTEXTCONTROL(")
                {
                    InputSplit[0] = InputSplit[0].Replace("SETTEXTCONTROL(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        TextBox CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as TextBox;
                        CallControl.Invoke((MethodInvoker)delegate { CallControl.Text = InputSplit[2]; });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //SETTACKBARCONTROL(SampleTimeTrackBar,0,20)

                if (InputSplit[0].Replace(InputSplit[0].Replace("SETTACKBARCONTROL(", ""), "").ToUpper() == "SETTACKBARCONTROL(")
                {
                    InputSplit[0] = InputSplit[0].Replace("SETTACKBARCONTROL(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        TrackBar CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as TrackBar;
                        CallControl.Invoke((MethodInvoker)delegate { CallControl.Value = Int32.Parse(InputSplit[2]); });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //SETNUMERICCONTROL(AutoTriggerMinNumericUpDown,0,20)

                if (InputSplit[0].Replace(InputSplit[0].Replace("SETNUMERICCONTROL(", ""), "").ToUpper() == "SETNUMERICCONTROL(")
                {
                    InputSplit[0] = InputSplit[0].Replace("SETNUMERICCONTROL(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        NumericUpDown CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as NumericUpDown;
                        CallControl.Invoke((MethodInvoker)delegate { CallControl.Value = Int32.Parse(InputSplit[2]); });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //SETCOMBOBOXINDEXCONTROL(LanguageComboBox,0,1)

                if (InputSplit[0].Replace(InputSplit[0].Replace("SETCOMBOBOXINDEXCONTROL(", ""), "").ToUpper() == "SETCOMBOBOXINDEXCONTROL(")
                {
                    InputSplit[0] = InputSplit[0].Replace("SETCOMBOBOXINDEXCONTROL(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        ComboBox CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as ComboBox;
                        CallControl.Invoke((MethodInvoker)delegate { CallControl.SelectedIndex = Int32.Parse(InputSplit[2]); });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //SETCHECKBOXCONTROL(AutoTriggerCheckBox,0,True)

                if (InputSplit[0].Replace(InputSplit[0].Replace("SETCHECKBOXCONTROL(", ""), "").ToUpper() == "SETCHECKBOXCONTROL(")
                {
                    InputSplit[0] = InputSplit[0].Replace("SETCHECKBOXCONTROL(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        CheckBox CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as CheckBox;
                        CallControl.Invoke((MethodInvoker)delegate { CallControl.Checked = Convert.ToBoolean(InputSplit[2]); });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //GETCONTROLTEXT(LanguageComboBox,0)

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETCONTROLTEXT(", ""), "").ToUpper() == "GETCONTROLTEXT(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETCONTROLTEXT(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        Control CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as Control;
                        CallControl.Invoke((MethodInvoker)delegate {
                            NetworkStream DataStream = ClientSocket.GetStream();
                            Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(CallControl.Text);
                            DataStream.Write(SendBytes, 0, SendBytes.Length);
                            DataStream.Flush();
                        });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //GETCOMBOBOXLIST(LanguageComboBox,0)

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETCOMBOBOXLIST(", ""), "").ToUpper() == "GETCOMBOBOXLIST(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETCOMBOBOXLIST(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        string SendString = "";

                        ComboBox CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as ComboBox;
                        CallControl.Invoke((MethodInvoker)delegate {
                            foreach(string Item in CallControl.Items)
                            {
                                SendString += Item + ";";
                            }
                        });

                        NetworkStream DataStream = ClientSocket.GetStream();
                        Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(SendString);
                        DataStream.Write(SendBytes, 0, SendBytes.Length);
                        DataStream.Flush();
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //GETTRACKBARVALUE(SampleTimeTrackBar,0)

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETTRACKBARVALUE(", ""), "").ToUpper() == "GETTRACKBARVALUE(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETTRACKBARVALUE(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        TrackBar CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as TrackBar;
                        CallControl.Invoke((MethodInvoker)delegate {
                            NetworkStream DataStream = ClientSocket.GetStream();
                            Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(CallControl.Value.ToString());
                            DataStream.Write(SendBytes, 0, SendBytes.Length);
                            DataStream.Flush();
                        });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                //GETCHECKBOXSTATE(SampleTimeTrackBar,0)

                if (InputSplit[0].Replace(InputSplit[0].Replace("GETTRACKBARVALUE(", ""), "").ToUpper() == "GETTRACKBARVALUE(")
                {
                    InputSplit[0] = InputSplit[0].Replace("GETTRACKBARVALUE(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    try
                    {
                        TrackBar CallControl = MainFormClass.Controls.Find(InputSplit[0], true)[Int32.Parse(InputSplit[1])] as TrackBar;
                        CallControl.Invoke((MethodInvoker)delegate {
                            NetworkStream DataStream = ClientSocket.GetStream();
                            Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(CallControl.Value.ToString());
                            DataStream.Write(SendBytes, 0, SendBytes.Length);
                            DataStream.Flush();
                        });
                    }
                    catch (Exception E)
                    {
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                    }

                    return "G";
                }

                return "U";
            }
            catch
            { RunningCommand = false; }
            return "B";
        }
    }
}
