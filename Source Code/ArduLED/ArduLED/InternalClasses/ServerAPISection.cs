﻿using System;
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
        public Thread ThreadingServer;
        private MainForm MainFormClass;

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
                if (ThreadingServer != null)
                    ThreadingServer.Abort();
                if (ServerListener != null)
                    ServerListener.Stop();
                if (ClientSocket != null)
                    ClientSocket.Close();
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
                Thread.Sleep(100);
            ServerRunning = true;
            ThreadingServer = new Thread(RunServer);
            ThreadingServer.Start();
        }

        public void StopServer()
        {
            if (ServerRunning)
            {
                ServerRunning = false;
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
                ClientSocket = null;
                ServerListener = null;
                IPAddress ServerIP = IPAddress.None;
                int ServerPort = 0;
                MainFormClass.ServerSettingsIPAddressTextBox.Invoke((MethodInvoker)delegate { ServerIP = IPAddress.Parse(MainFormClass.ServerSettingsIPAddressTextBox.Text); });
                MainFormClass.ServerSettingsPortTextBox.Invoke((MethodInvoker)delegate { ServerPort = Int32.Parse(MainFormClass.ServerSettingsPortTextBox.Text); });
                ServerListener = new TcpListener(ServerIP, ServerPort);
                ClientSocket = default(TcpClient);

                ServerListener.Start();
                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server waiting connections!" + Environment.NewLine; });
                while(!ServerListener.Pending())
                {
                    if (!ServerRunning)
                        break;
                    Thread.Sleep(100);
                }
                if (ServerRunning)
                {
                    ClientSocket = ServerListener.AcceptTcpClient();
                    MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Connected!" + Environment.NewLine; });
                }
            }
            catch
            {
                MessageBox.Show("Error with Server Settings");
                ServerRunning = false;
            }

            while (ServerRunning)
            {
                try
                {
                    if (ClientSocket.Client.Poll(0, SelectMode.SelectRead))
                    {
                        try
                        {
                            byte[] PeekBuffer = new byte[1];
                            ClientSocket.Client.Receive(PeekBuffer, SocketFlags.Peek);
                        }
                        catch
                        {
                            MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Client Disconnected!" + Environment.NewLine; });
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
                                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Connected!" + Environment.NewLine; });
                            }
                            else
                                break;
                        }
                    }
                    if (ClientSocket.Available == 0)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    NetworkStream DataStream = ClientSocket.GetStream();
                    byte[] ReadBytes = new byte[1024];
                    DataStream.Read(ReadBytes, 0, 1024);
                    string ClientData = System.Text.Encoding.ASCII.GetString(ReadBytes);
                    ClientData = ClientData.Substring(0, ClientData.IndexOf("$"));

                    MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Recieved: " + ClientData + Environment.NewLine; });

                    string Out = ArduLEDServerAPI(ClientData);
                    if (Out != "")
                    {
                        Byte[] SendBytes = System.Text.Encoding.ASCII.GetBytes(Out);
                        DataStream.Write(SendBytes, 0, SendBytes.Length);
                        DataStream.Flush();
                    }
                    if (Out != "N")
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += " Command Done!" + Environment.NewLine; });
                    else
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += " Bad Input!!" + Environment.NewLine; });
                }
                catch
                {
                    ServerListener.Stop();
                    ServerListener.Start();
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
                        MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Connected!" + Environment.NewLine; });
                    }
                    else
                        break;
                }
            }
            ServerListener.Stop();
            MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "Server Disconnected!" + Environment.NewLine; });
            ServerEnded = true;
        }

        private string ArduLEDServerAPI(string _Input)
        {
            try
            {
                string[] InputSplit = _Input.Split(',');

                MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     Running Command: " + InputSplit[0].ToUpper().Split('(')[0] + " ... "; });

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
                        Int32.Parse(InputSplit[7])
                        );
                }

                //INDIVIDUALCOLOR(3,40,0,255,255)

                if (InputSplit[0].Replace(InputSplit[0].Replace("INDIVIDUALCOLOR(", ""), "").ToUpper() == "INDIVIDUALCOLOR(")
                {
                    InputSplit[0] = InputSplit[0].Replace("FADECOLOR(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    string SerialOut = "4;" + InputSplit[0] + ";" + InputSplit[1] + ";" + InputSplit[2] + ";" + InputSplit[3] + ";" + InputSplit[4];
                    MainFormClass.SendDataBySerial(SerialOut);
                }

                //VISUALIZER(False,test.txt)

                if (InputSplit[0].Replace(InputSplit[0].Replace("VISUALIZER(", ""), "").ToUpper() == "VISUALIZER(")
                {
                    InputSplit[0] = InputSplit[0].Replace("VISUALIZER(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    if (InputSplit[0] == "True")
                    {
                        MainFormClass.VisualizerSectionClass.EnableBASS(false);
                    }
                    else
                    {
                        try
                        {
                            string SerialOut = "";
                            MainFormClass.VisualizerPanel.Invoke((MethodInvoker)delegate
                            {
                                MainFormClass.LoadSettings(Directory.GetCurrentDirectory() + "\\VisualizerSettings\\" + InputSplit[1]);
                            });
                            MainFormClass.VisualizerFromSeriesIDNumericUpDown.Invoke((MethodInvoker)delegate
                            {
                                MainFormClass.VisualizerToSeriesIDNumericUpDown.Invoke((MethodInvoker)delegate
                                {
                                    SerialOut = "6;" + MainFormClass.VisualizerFromSeriesIDNumericUpDown.Value + ";" + MainFormClass.VisualizerToSeriesIDNumericUpDown.Value;
                                });
                            });
                            MainFormClass.SendDataBySerial(SerialOut);
                            MainFormClass.VisualizerPanel.Invoke((MethodInvoker)delegate
                            {
                                MainFormClass.VisualizerSectionClass.EnableBASS(true);
                            });
                        }
                        catch (Exception E)
                        {
                            MainFormClass.ServerSettingsConsoleTextBox.Invoke((MethodInvoker)delegate { MainFormClass.ServerSettingsConsoleTextBox.Text += "     " + E.ToString() + Environment.NewLine; });
                        }
                    }
                }

                //AMBILIGHT(False,True,False,wew5.txt)

                if (InputSplit[0].Replace(InputSplit[0].Replace("AMBILIGHT(", ""), "").ToUpper() == "AMBILIGHT(")
                {
                    InputSplit[0] = InputSplit[0].Replace("AMBILIGHT(", "");
                    InputSplit[InputSplit.Length - 1] = InputSplit[InputSplit.Length - 1].Replace(")", "");

                    if (InputSplit[0] == "True")
                    {
                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                            MainFormClass.AmbiLightSectionClass.StopAmbilight();
                        });
                    }
                    else
                    {
                        if (InputSplit[1] == "True")
                        {
                            MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                                MainFormClass.AmbiLightSectionClass.SetSides();
                                MainFormClass.AmbiLightSectionClass.ShowBlocks(
                                    MainFormClass.LeftSide,
                                    MainFormClass.TopSide,
                                    MainFormClass.RightSide,
                                    MainFormClass.BottomSide,
                                    (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                    (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value
                                    );
                            });
                        }
                        else
                        {
                            if (InputSplit[2] == "True")
                            {
                                MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                                    MainFormClass.AmbiLightSectionClass.SetSides();
                                    MainFormClass.AmbiLightSectionClass.AutoSetOffsets(
                                        MainFormClass.LeftSide,
                                        MainFormClass.TopSide,
                                        MainFormClass.RightSide,
                                        MainFormClass.BottomSide,
                                        (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                        (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value
                                        );
                                });
                            }
                            else
                            {
                                MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                                    MainFormClass.LoadSettings(Directory.GetCurrentDirectory() + "\\AmbilightSettings\\" + InputSplit[3]);
                                    MainFormClass.AmbiLightSectionClass.SetSides();
                                    MainFormClass.AmbiLightSectionClass.StartAmbilight(
                                        MainFormClass.LeftSide,
                                        MainFormClass.TopSide,
                                        MainFormClass.RightSide,
                                        MainFormClass.BottomSide,
                                        (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                        (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value,
                                        (double)MainFormClass.AmbiLightModeGammaFactorNumericUpDown.Value,
                                        (double)MainFormClass.AmbiLightModeFadeFactorNumericUpDown.Value,
                                        (int)MainFormClass.AmbiLightModeRefreshRateNumericUpDown.Value
                                        );
                                });
                            }
                        }
                    }
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
                }

                return "G";
            }
            catch
            {  }
            return "F";
        }
    }
}