using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ArduLEDNameSpace
{
    public class InstructionsSection : IDisposable
    {
        public bool IsDisposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public List<string> IntructionsList = new List<string>();
        public bool ContinueInstructionsLoop = false;
        public bool StopInstructionsLoop = false;
        public bool InstructionsRunning = false;
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
                IntructionsList.Clear();
            }

            IsDisposed = true;
        }

        public InstructionsSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public void AddInstruction(string _Input)
        {
            IntructionsList.Add(_Input);
            RestructureInstructions();
        }

        void RestructureInstructions()
        {
            MainFormClass.InstructionsWorkingPanel.Visible = false;
            MainFormClass.InstructionsWorkingPanel.Controls.Clear();
            for (int i = 0; i < IntructionsList.Count; i++)
            {
                MakeInstructionPanel(IntructionsList[i], i);
            }
            MainFormClass.InstructionsWorkingPanel.Visible = true;
        }

        public void MakeInstructionPanel(string _Input, int _ID)
        {
            Panel BackPanel = new Panel();
            BackPanel.Location = new Point(MainFormClass.Margins, MainFormClass.InstructionsWorkingPanel.Controls.Count * MainFormClass.BoxHeight + 2 * MainFormClass.Margins);
            BackPanel.Height = MainFormClass.BoxHeight;
            BackPanel.Width = MainFormClass.InstructionsWorkingPanel.Width - 2 * MainFormClass.Margins - MainFormClass.ScrollBarSize;
            BackPanel.BorderStyle = BorderStyle.FixedSingle;
            BackPanel.BackColor = Color.White;
            BackPanel.Tag = _Input;
            BackPanel.Font = new Font(BackPanel.Font.FontFamily, BackPanel.Font.Size);
            BackPanel.BackColor = Color.White;

            Button RemovePanelButton = new Button();
            RemovePanelButton.Tag = _ID;
            RemovePanelButton.Text = "X";
            RemovePanelButton.Width = MainFormClass.ButtonWidth;
            RemovePanelButton.Height = MainFormClass.ButtonHeight * 2;
            RemovePanelButton.Location = new Point(BackPanel.Width - MainFormClass.ButtonWidth - MainFormClass.Margins, MainFormClass.Margins);
            RemovePanelButton.Parent = BackPanel;
            RemovePanelButton.Click += RemoveInstruction;
            RemovePanelButton.BackColor = Color.DarkGray;
            RemovePanelButton.ForeColor = Color.White;
            RemovePanelButton.Name = "InstructionsInstructionPanelRemoveButton";

            BackPanel.Controls.Add(RemovePanelButton);

            Button MoveUpButton = new Button();
            MoveUpButton.Tag = _ID;
            MoveUpButton.Text = "^";
            MoveUpButton.Width = MainFormClass.ButtonWidth;
            MoveUpButton.Height = MainFormClass.ButtonHeight;
            MoveUpButton.Click += MoveInstructionUp;
            MoveUpButton.Location = new Point(BackPanel.Width - 2 * MainFormClass.ButtonWidth - 3 * MainFormClass.Margins, 0);
            MoveUpButton.BackColor = Color.DarkGray;
            MoveUpButton.ForeColor = Color.White;
            MoveUpButton.Name = "InstructionsInstructionPanelMoveUpButton";

            BackPanel.Controls.Add(MoveUpButton);

            Button MoveDownButton = new Button();
            MoveDownButton.Tag = _ID;
            MoveDownButton.Text = "v";
            MoveDownButton.Width = MainFormClass.ButtonWidth;
            MoveDownButton.Height = MainFormClass.ButtonHeight;
            MoveDownButton.Click += MoveInstructionDown;
            MoveDownButton.Location = new Point(BackPanel.Width - 2 * MainFormClass.ButtonWidth - 3 * MainFormClass.Margins, BackPanel.Height - MainFormClass.ButtonHeight - MainFormClass.Margins);
            MoveDownButton.BackColor = Color.DarkGray;
            MoveDownButton.ForeColor = Color.White;
            MoveDownButton.Name = "InstructionsInstructionPanelMoveDownButton";

            BackPanel.Controls.Add(MoveDownButton);

            TextBox InfoTextBox = new TextBox();
            InfoTextBox.Text = _ID + ": " + _Input.Replace(";", " : ");
            InfoTextBox.Width = BackPanel.Width - MainFormClass.ButtonWidth * 2 - 4 * MainFormClass.Margins;
            InfoTextBox.Height = BackPanel.Height;
            InfoTextBox.Location = new Point(MainFormClass.Margins, MainFormClass.Margins);
            InfoTextBox.BorderStyle = BorderStyle.None;
            InfoTextBox.BackColor = Color.DarkGray;
            InfoTextBox.ForeColor = Color.White;
            InfoTextBox.ReadOnly = true;
            InfoTextBox.Name = "InstructionsInstructionPanelInfoTextBox";

            BackPanel.Controls.Add(InfoTextBox);

            MainFormClass.InstructionsWorkingPanel.Controls.Add(BackPanel);
        }

        private void RemoveInstruction(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            int ID = (int)SenderButton.Tag;
            IntructionsList.RemoveAt(ID);
            RestructureInstructions();
        }

        private void MoveInstructionUp(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            int ID = (int)SenderButton.Tag;
            if (ID - 1 >= 0)
            {
                string Data = IntructionsList[ID];
                IntructionsList.RemoveAt(ID);
                IntructionsList.Insert(ID - 1, Data);
                RestructureInstructions();
            }
        }

        private void MoveInstructionDown(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            int ID = (int)SenderButton.Tag;
            if (ID + 1 < IntructionsList.Count)
            {
                string Data = IntructionsList[ID];
                IntructionsList.RemoveAt(ID);
                IntructionsList.Insert(ID + 1, Data);
                RestructureInstructions();
            }
        }

        public async void RunInstructions()
        {
            await RunInstructionsInner();
        }

        public async Task RunInstructionsInner()
        {
            await Task.Run(async () =>
            {
                InstructionsRunning = true;
                while (ContinueInstructionsLoop)
                {
                    for (int i = 0; i < IntructionsList.Count; i++)
                    {
                        if (i == 0)
                        {
                            MainFormClass.InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { MainFormClass.InstructionsWorkingPanel.Controls[IntructionsList.Count - 1].BackColor = Color.White; });
                        }
                        else
                        {
                            MainFormClass.InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { MainFormClass.InstructionsWorkingPanel.Controls[i - 1].BackColor = Color.White; });
                        }
                        MainFormClass.InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { MainFormClass.InstructionsWorkingPanel.Controls[i].BackColor = Color.Gray; });

                        string[] Data = IntructionsList[i].Split(';');
                        if (Data[0] == "Delay")
                        {
                            for (int j = 0; j < Int32.Parse(Data[1]); j += 100)
                            {
                                await Task.Delay(100);
                                if (StopInstructionsLoop)
                                    break;
                            }
                        }
                        if (Data[0] == "WaitUntil")
                        {
                            DateTime WaitUntil = DateTime.Parse(Data[1] + "/" + Data[2] + "/" + Data[3] + " " + Data[4] + ":" + Data[5] + ":" + Data[6]);
                            while (DateTime.Now < WaitUntil)
                            {
                                await Task.Delay(1000);
                                if (StopInstructionsLoop)
                                    break;
                            }
                        }
                        if (Data[0] == "Fade Colors")
                        {
                            string SerialOut = "6;" + Data[1] + ";" + Data[2];
                            MainFormClass.SendDataBySerial(SerialOut);
                            Color AfterShuffel = MainFormClass.ShuffleColors(Color.FromArgb(Int32.Parse(Data[3]), Int32.Parse(Data[4]), Int32.Parse(Data[5])));
                            SerialOut = "1;" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B + ";" + Data[6] + ";" + Math.Round((Convert.ToDecimal(Data[7]) * 100), 0).ToString();
                            MainFormClass.SendDataBySerial(SerialOut);
                        }
                        if (Data[0] == "Individual LED")
                        {
                            Color AfterShuffel = MainFormClass.ShuffleColors(Color.FromArgb(Int32.Parse(Data[3]), Int32.Parse(Data[4]), Int32.Parse(Data[5])));
                            string SerialOut = "4;" + Data[1] + ";" + Data[2] + ";" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B;
                            MainFormClass.SendDataBySerial(SerialOut);
                        }
                        if (Data[0] == "Visualizer")
                        {
                            if (Data[1] == "True")
                            {
                                MainFormClass.VisualizerSectionClass.EnableBASS(false);
                            }
                            else
                            {
                                string SerialOut = "";
                                MainFormClass.VisualizerPanel.Invoke((MethodInvoker)delegate {
                                    MainFormClass.LoadSettings(Directory.GetCurrentDirectory() + "\\VisualizerSettings\\" + Data[2]);
                                });
                                MainFormClass.VisualizerFromSeriesIDNumericUpDown.Invoke((MethodInvoker)delegate {
                                    MainFormClass.VisualizerToSeriesIDNumericUpDown.Invoke((MethodInvoker)delegate {
                                        SerialOut = "6;" + MainFormClass.VisualizerFromSeriesIDNumericUpDown.Value + ";" + MainFormClass.VisualizerToSeriesIDNumericUpDown.Value;
                                    });
                                });
                                MainFormClass.SendDataBySerial(SerialOut);
                                MainFormClass.VisualizerPanel.Invoke((MethodInvoker)delegate {
                                    MainFormClass.VisualizerSectionClass.EnableBASS(true);
                                });
                            }
                        }
                        if (Data[0] == "Ambilight")
                        {
                            if (Data[1] == "True")
                            {
                                MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                                    MainFormClass.AmbiLightSectionClass.StopAmbilight();
                                });
                            }
                            else
                            {
                                if (Data[2] == "True")
                                {
                                    MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                                        MainFormClass.AmbiLightSectionClass.ShowBlocks(
                                            (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                            (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value
                                            );
                                    });
                                }
                                else
                                {
                                    if (Data[3] == "True")
                                    {
                                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                                            MainFormClass.AmbiLightSectionClass.AutoSetOffsets(
                                                (int)MainFormClass.AmbiLightModeScreenIDNumericUpDown.Value,
                                                (int)MainFormClass.AmbiLightModeBlockSampleSplitNumericUpDown.Value
                                                );
                                        });
                                    }
                                    else
                                    {
                                        MainFormClass.AmbiLightModePanel.Invoke((MethodInvoker)delegate {
                                            MainFormClass.LoadSettings(Directory.GetCurrentDirectory() + "\\AmbilightSettings\\" + Data[4]);
                                            MainFormClass.AmbiLightSectionClass.StartAmbilight(
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
                        if (StopInstructionsLoop)
                            break;
                    }
                    MainFormClass.InstructionsLoopCheckBox.Invoke((MethodInvoker)delegate { ContinueInstructionsLoop = MainFormClass.InstructionsLoopCheckBox.Checked; });
                    if (StopInstructionsLoop)
                    {
                        StopInstructionsLoop = false;
                        ContinueInstructionsLoop = false;
                        InstructionsRunning = false;
                    }
                }
                for (int i = 0; i < IntructionsList.Count; i++)
                {
                    MainFormClass.InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { MainFormClass.InstructionsWorkingPanel.Controls[i].BackColor = Color.White; });
                }
                InstructionsRunning = false;
            });
        }

        public void SaveInstructions(string _FileLoc)
        {
            try
            { 
                using (StreamWriter AutoSaveFile = new StreamWriter(MainFormClass.GenerateStreamFromString(Directory.GetCurrentDirectory() + "\\Instructions\\0.txt"), System.Text.Encoding.UTF8))
                {
                    using (StreamWriter SaveFile = new StreamWriter(MainFormClass.GenerateStreamFromString(_FileLoc), System.Text.Encoding.UTF8))
                    {
                        foreach (string c in IntructionsList)
                        {
                            string SerialOut = c;
                            SaveFile.WriteLine(SerialOut);
                            AutoSaveFile.WriteLine(SerialOut);
                        }
                    }
                }
            }
            catch { MessageBox.Show("Cannot access file: " + _FileLoc); }
        }

        public void LoadInstructions(string _FileLoc)
        {
            try
            { 
                while (MainFormClass.InstructionsWorkingPanel.Controls.Count > 0)
                    MainFormClass.InstructionsWorkingPanel.Controls[0].Dispose();

                IntructionsList.Clear();
                string[] Lines = File.ReadAllLines(_FileLoc, System.Text.Encoding.UTF8);
                for (int i = 0; i < Lines.Length; i++)
                {
                    IntructionsList.Add(Lines[i]);
                    MakeInstructionPanel(Lines[i], i);
                }
            }
            catch { MessageBox.Show("Cannot access file: " + _FileLoc); }
        }

        public void AutoSave()
        {
            if (IntructionsList.Count > 0)
            {
                try
                {
                    using (StreamWriter AutoSaveFile = new StreamWriter(Directory.GetCurrentDirectory() + "\\Instructions\\0.txt", false))
                    {
                        foreach (string c in IntructionsList)
                        {
                            AutoSaveFile.WriteLine(c);
                        }
                    }
                }
                catch { MessageBox.Show("Cannot access autosave file!"); }
            }
        }


        public void AutoloadLastInstructions()
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\Instructions\\0.txt"))
                {
                    while (MainFormClass.InstructionsWorkingPanel.Controls.Count > 0)
                        MainFormClass.InstructionsWorkingPanel.Controls[0].Dispose();

                    IntructionsList.Clear();

                    string[] Lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Instructions\\0.txt", System.Text.Encoding.UTF8);
                    for (int i = 0; i < Lines.Length; i++)
                    {
                        IntructionsList.Add(Lines[i]);
                        MakeInstructionPanel(Lines[i], i);
                    }
                }
            }
            catch { MessageBox.Show("Cannot access autosave file!"); }
        }
    }
}
