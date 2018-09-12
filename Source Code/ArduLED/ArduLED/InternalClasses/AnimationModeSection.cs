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
    public class AnimationModeSection : IDisposable
    {
        public bool IsDisposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private MainForm MainFormClass;
        public List<string> AnimationList = new List<string>();
        public bool ContinueAnimationLoop = false;
        public bool StopAnimationLoop = false;
        public bool AnimationRunning = false;
        public int MoveInterval = 50;
        private DateTime AnimationsFPSCounter;
        private int AnimationsFPSCounterFramesRendered;
        public bool ColorEntireLine = false;

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
                AnimationList.Clear();
            }

            IsDisposed = true;
        }

        public AnimationModeSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public void AddLine(string _Input)
        {
            AnimationList.Add(_Input);
            RestructureAnimationsList();
        }

        private void MakeNewLinePanel(string _Input, int _ID, Panel _AddToPanel)
        {
            Panel BackPanel = new Panel();
            BackPanel.Height = _AddToPanel.Height - MainFormClass.Margins * 2 - 20;
            BackPanel.Width = MainFormClass.ButtonWidth * 2 + MainFormClass.Margins * 3;
            BackPanel.Location = new Point(MainFormClass.Margins + (_AddToPanel.Controls.Count * (BackPanel.Width + MainFormClass.Margins)), MainFormClass.Margins);
            BackPanel.BorderStyle = BorderStyle.FixedSingle;
            BackPanel.BackColor = Color.White;
            BackPanel.Font = new Font(BackPanel.Font.FontFamily, BackPanel.Font.Size);
            BackPanel.BackColor = Color.White;

            Button RemovePanelButton = new Button();
            RemovePanelButton.Tag = _ID;
            RemovePanelButton.Text = "X";
            RemovePanelButton.Width = MainFormClass.ButtonWidth;
            RemovePanelButton.Height = MainFormClass.ButtonHeight * 2;
            RemovePanelButton.Location = new Point(MainFormClass.Margins, MainFormClass.Margins);
            RemovePanelButton.Parent = BackPanel;
            RemovePanelButton.Click += RemoveLine;
            RemovePanelButton.BackColor = Color.DarkGray;
            RemovePanelButton.ForeColor = Color.White;
            RemovePanelButton.Name = "AnimationPanelRemoveButton";

            BackPanel.Controls.Add(RemovePanelButton);

            Button MoveLeftButton = new Button();
            MoveLeftButton.Tag = _ID;
            MoveLeftButton.Text = "<";
            MoveLeftButton.Width = MainFormClass.ButtonWidth;
            MoveLeftButton.Height = MainFormClass.ButtonHeight * 2;
            MoveLeftButton.Click += MoveLineLeft;
            MoveLeftButton.Location = new Point(MainFormClass.Margins, MainFormClass.Margins * 2 + MainFormClass.ButtonHeight * 2);
            MoveLeftButton.BackColor = Color.DarkGray;
            MoveLeftButton.ForeColor = Color.White;
            MoveLeftButton.Name = "AnimationPanelMoveLeftButton";

            BackPanel.Controls.Add(MoveLeftButton);

            Button MoveRightButton = new Button();
            MoveRightButton.Tag = _ID;
            MoveRightButton.Text = ">";
            MoveRightButton.Width = MainFormClass.ButtonWidth;
            MoveRightButton.Height = MainFormClass.ButtonHeight * 2;
            MoveRightButton.Click += MoveLineRight;
            MoveRightButton.Location = new Point(MainFormClass.Margins * 2 + MainFormClass.ButtonWidth, MainFormClass.Margins * 2 + MainFormClass.ButtonHeight * 2);
            MoveRightButton.BackColor = Color.DarkGray;
            MoveRightButton.ForeColor = Color.White;
            MoveRightButton.Name = "AnimationPanelMoveRightButton";

            BackPanel.Controls.Add(MoveRightButton);

            string[] InputSplit = _Input.Split(';');

            for (int i = 0; i < InputSplit.Length - 1; i++)
            {
                string[] InnerInputSplit = InputSplit[i].Split('.');

                Panel ColorPanel = new Panel();
                ColorPanel.Tag = _ID + ";" + i;
                ColorPanel.Text = "";
                ColorPanel.Width = BackPanel.Width - MainFormClass.Margins * 2;
                ColorPanel.Height = (BackPanel.Height - MoveRightButton.Location.Y - MoveRightButton.Height - MainFormClass.Margins) / (InputSplit.Length - 1) - MainFormClass.Margins;
                ColorPanel.Click += SetColor;
                ColorPanel.Location = new Point(MainFormClass.Margins, MainFormClass.Margins + MoveRightButton.Location.Y + MoveRightButton.Height + (ColorPanel.Height + MainFormClass.Margins) * i);
                ColorPanel.BackColor = Color.FromArgb(Int32.Parse(InnerInputSplit[0]), Int32.Parse(InnerInputSplit[1]), Int32.Parse(InnerInputSplit[2]));
                ColorPanel.Name = "AnimationPanelColorPanel";

                BackPanel.Controls.Add(ColorPanel);
            }

            _AddToPanel.Controls.Add(BackPanel);
        }

        private void RemoveLine(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            int ID = (int)SenderButton.Tag;
            AnimationList.RemoveAt(ID);
            RestructureAnimationsList();
        }

        private void MoveLineLeft(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            int ID = (int)SenderButton.Tag;
            if (ID - 1 >= 0)
            {
                string Data = AnimationList[ID];
                AnimationList.RemoveAt(ID);
                AnimationList.Insert(ID - 1, Data);
                RestructureAnimationsList();
            }
        }

        private void MoveLineRight(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            int ID = (int)SenderButton.Tag;
            if (ID + 1 < AnimationList.Count)
            {
                string Data = AnimationList[ID];
                AnimationList.RemoveAt(ID);
                AnimationList.Insert(ID + 1, Data);
                RestructureAnimationsList();
            }
        }

        private void SetColor(object sender, EventArgs e)
        {
            Panel SenderButton = sender as Panel;
            string SenderData = (string)SenderButton.Tag;
            Color NewColor = Color.FromArgb(MainFormClass.AnimationModeRedTrackbar.Value, MainFormClass.AnimationModeGreenTrackbar.Value, MainFormClass.AnimationModeBlueTrackbar.Value);
            if (ColorEntireLine)
            {
                AnimationList[Int32.Parse(SenderData.Split(';')[0])] = "";
                foreach (Control InnerPanel in SenderButton.Parent.Controls)
                {
                    if (InnerPanel is Panel)
                    {
                        InnerPanel.BackColor = NewColor;
                        AnimationList[Int32.Parse(SenderData.Split(';')[0])] += NewColor.R + "." + NewColor.G + "." + NewColor.B + ";";
                    }
                }
            }
            else
            {
                string[] AnimationSplit = AnimationList[Int32.Parse(SenderData.Split(';')[0])].Split(';');
                AnimationSplit[Int32.Parse(SenderData.Split(';')[1])] = NewColor.R + "." + NewColor.G + "." + NewColor.B;
                string EndValue = "";
                foreach (string s in AnimationSplit)
                    EndValue += s + ";";
                EndValue = EndValue.Substring(0, EndValue.Length - 1);
                AnimationList.RemoveAt(Int32.Parse(SenderData.Split(';')[0]));
                AnimationList.Insert(Int32.Parse(SenderData.Split(';')[0]), EndValue);
                SenderButton.BackColor = NewColor;
            }
        }

        void RestructureAnimationsList()
        {
            Panel OrgPanel = (Panel)MainFormClass.AnimationModePanel.Controls.Find("AnimationModeAnimationWindowWorkingPanel",true)[0];
            Panel NewPanel = new Panel();
            NewPanel.SuspendLayout();
            NewPanel.Name = OrgPanel.Name;
            NewPanel.Width = OrgPanel.Width;
            NewPanel.Height = OrgPanel.Height;
            NewPanel.Location = OrgPanel.Location;
            NewPanel.BackColor = OrgPanel.BackColor;
            NewPanel.AutoScroll = OrgPanel.AutoScroll;
            NewPanel.BorderStyle = OrgPanel.BorderStyle;
            for (int i = 0; i < AnimationList.Count; i++)
            {
                MakeNewLinePanel(AnimationList[i], i, NewPanel);
            }
            if (NewPanel.Controls.Count == 0)
                MainFormClass.AnimationModeLineSpacingNumericUpDown.Enabled = true;
            else
                MainFormClass.AnimationModeLineSpacingNumericUpDown.Enabled = false;

            OrgPanel.Dispose();
            MainFormClass.AnimationModePanel.Controls.Add(NewPanel);
            NewPanel.ResumeLayout();
        }

        private void MakeLiveViewBox(int _ID)
        {
            Panel BackPanel = new Panel();
            BackPanel.Height = MainFormClass.AnimationModeLiveViewWorkingPanel.Height - MainFormClass.Margins * 2;
            BackPanel.Width = MainFormClass.ButtonWidth * 2 + MainFormClass.Margins * 3;
            BackPanel.Location = new Point(MainFormClass.Margins + (MainFormClass.AnimationModeLiveViewWorkingPanel.Controls.Count * (BackPanel.Width + MainFormClass.Margins)), MainFormClass.Margins);
            BackPanel.BorderStyle = BorderStyle.FixedSingle;
            BackPanel.BackColor = Color.White;
            BackPanel.Font = new Font(BackPanel.Font.FontFamily, BackPanel.Font.Size);
            BackPanel.BackColor = Color.White;

            string[] InputSplit = AnimationList[_ID].Split(';');

            for (int i = 0; i < InputSplit.Length - 1; i++)
            {
                string[] InnerInputSplit = InputSplit[i].Split('.');

                Panel ColorPanel = new Panel();
                ColorPanel.Text = "";
                ColorPanel.Width = BackPanel.Width - MainFormClass.Margins * 2;
                ColorPanel.Height = (BackPanel.Height - MainFormClass.Margins) / (InputSplit.Length - 1) - MainFormClass.Margins;
                ColorPanel.Location = new Point(MainFormClass.Margins, (ColorPanel.Height + MainFormClass.Margins) * i + MainFormClass.Margins);
                ColorPanel.BackColor = Color.FromArgb(Int32.Parse(InnerInputSplit[0]), Int32.Parse(InnerInputSplit[1]), Int32.Parse(InnerInputSplit[2]));
                ColorPanel.Name = "AnimationPanelLiveViewColorPanel";

                BackPanel.Controls.Add(ColorPanel);
            }

            MainFormClass.AnimationModeLiveViewWorkingPanel.Controls.Add(BackPanel);

            if (MainFormClass.AnimationModeLiveViewWorkingPanel.Controls.Count > 15)
                MainFormClass.AnimationModeLiveViewWorkingPanel.Controls[0].Dispose();

            for (int i = 0; i < MainFormClass.AnimationModeLiveViewWorkingPanel.Controls.Count; i++)
            {
                MainFormClass.AnimationModeLiveViewWorkingPanel.Controls[i].Location = new Point(MainFormClass.Margins + ((i - 1) * (MainFormClass.AnimationModeLiveViewWorkingPanel.Controls[i].Width + MainFormClass.Margins)), MainFormClass.Margins);
            }
        }

        public async Task RunAnimation()
        {
            DateTime CalibrateRefreshRate = new DateTime();

            await Task.Run(async () =>
            {
                Panel WorkingPanel = (Panel)MainFormClass.AnimationModePanel.Controls.Find("AnimationModeAnimationWindowWorkingPanel", true)[0];
                MainFormClass.AnimationModeInterfacePanel.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeInterfacePanel.Enabled = false; });
                WorkingPanel.Invoke((MethodInvoker)delegate { WorkingPanel.Enabled = false; });
                MainFormClass.AnimationModeSaveButton.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeSaveButton.Enabled = false; });
                MainFormClass.AnimationModeLoadButton.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeLoadButton.Enabled = false; });
                MainFormClass.AnimationModeLiveViewWorkingPanel.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeLiveViewWorkingPanel.Controls.Clear(); });

                string SerialOut = "6;" + MainFormClass.AnimationModeFromIDNumericUpDown.Value + ";" + MainFormClass.AnimationModeToIDNumericUpDown.Value;
                MainFormClass.SendDataBySerial(SerialOut);

                bool UseCompression = MainFormClass.AnimationModeHighCompressionCheckBox.Checked;

                CalibrateRefreshRate = DateTime.Now;

                AnimationRunning = true;
                while (ContinueAnimationLoop)
                {
                    for (int i = 0; i < AnimationList.Count; i++)
                    {
                        if (MoveInterval > 20)
                        {
                            MainFormClass.AnimationModeInterfacePanel.Invoke((MethodInvoker)delegate
                            {
                                MakeLiveViewBox(i);
                            });
                        }

                        SerialOut = "8;" + MainFormClass.AnimationModeLineSpacingNumericUpDown.Value + ";" + Convert.ToInt32(UseCompression) + ";1;";

                        int Count = 0;
                        int PreCount = 0;
                        for (int j = 0; j < AnimationList[i].Split(';').Length; j++)
                        {
                            if (AnimationList[i].Split(';')[j] != "")
                            {
                                Color AfterShuffel = MainFormClass.ShuffleColors(Color.FromArgb(Int32.Parse(AnimationList[i].Split(';')[j].Split('.')[0]), Int32.Parse(AnimationList[i].Split(';')[j].Split('.')[1]), Int32.Parse(AnimationList[i].Split(';')[j].Split('.')[2])));

                                string AddString = "";

                                if (UseCompression)
                                {
                                    int RVal = (int)Math.Round((decimal)8 / ((decimal)255 / (AfterShuffel.R + 1)), 0) + 1;
                                    int GVal = (int)Math.Round((decimal)8 / ((decimal)255 / (AfterShuffel.G + 1)), 0) + 1;
                                    int BVal = (int)Math.Round((decimal)8 / ((decimal)255 / (AfterShuffel.B + 1)), 0) + 1;

                                    if (RVal == GVal && GVal == BVal)
                                    {
                                        AddString = RVal.ToString() + ";";
                                    }
                                    else
                                    {
                                        if (RVal == GVal && RVal != 0)
                                        {
                                            AddString = RVal.ToString() + BVal.ToString() + ";";
                                        }
                                        else
                                        {
                                            AddString = RVal.ToString() + GVal.ToString() + BVal.ToString() + ";";
                                        }
                                    }
                                }
                                else
                                {
                                    AddString = AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B + ";";
                                }

                                if (SerialOut.Length + AddString.Length > 75)
                                {
                                    string[] InnerSerialOutSplit = SerialOut.Split(';');
                                    InnerSerialOutSplit[1] = (Count - PreCount).ToString();
                                    InnerSerialOutSplit[3] = "0";

                                    SerialOut = "";
                                    foreach (string Split in InnerSerialOutSplit)
                                        SerialOut += Split + ";";

                                    SerialOut = SerialOut.Substring(0, SerialOut.Length - 2);

                                    MainFormClass.SendDataBySerial(SerialOut);

                                    SerialOut = "8;" + (MainFormClass.AnimationModeLineSpacingNumericUpDown.Value - Count).ToString() + ";" + Convert.ToInt32(UseCompression) + ";1;" + AddString;

                                    PreCount = Count;
                                }
                                else
                                {
                                    SerialOut += AddString;
                                }
                                Count++;
                            }
                        }

                        MainFormClass.SendDataBySerial(SerialOut);

                        int ExectuionTime = (int)(DateTime.Now - CalibrateRefreshRate).TotalMilliseconds;
                        int ActuralRefreshTime = MoveInterval - ExectuionTime;

                        if (ActuralRefreshTime < 0)
                            ActuralRefreshTime = 0;

                        await Task.Delay(ActuralRefreshTime);

                        AnimationsFPSCounterFramesRendered++;

                        CalibrateRefreshRate = DateTime.Now;

                        if ((DateTime.Now - AnimationsFPSCounter).TotalSeconds >= 1)
                        {
                            MainFormClass.AnimationModeAPSLabel.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeAPSLabel.Text = "APS: " + AnimationsFPSCounterFramesRendered; });
                            AnimationsFPSCounterFramesRendered = 0;
                            AnimationsFPSCounter = DateTime.Now;
                        }

                        if (StopAnimationLoop)
                            break;
                    }
                    MainFormClass.AnimationModeLoopCheckBox.Invoke((MethodInvoker)delegate { ContinueAnimationLoop = MainFormClass.AnimationModeLoopCheckBox.Checked; });
                    if (StopAnimationLoop)
                    {
                        StopAnimationLoop = false;
                        ContinueAnimationLoop = false;
                        AnimationRunning = false;
                    }
                }
                AnimationRunning = false;
                MainFormClass.AnimationModeInterfacePanel.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeInterfacePanel.Enabled = true; });
                WorkingPanel.Invoke((MethodInvoker)delegate { WorkingPanel.Enabled = true; });
                MainFormClass.AnimationModeSaveButton.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeSaveButton.Enabled = true; });
                MainFormClass.AnimationModeLoadButton.Invoke((MethodInvoker)delegate { MainFormClass.AnimationModeLoadButton.Enabled = true; });
            });
        }

        public void SaveAnimation()
        {
            using (StreamWriter AutoSaveFile = new StreamWriter(MainFormClass.GenerateStreamFromString(Directory.GetCurrentDirectory() + "\\Animations\\0.txt"), System.Text.Encoding.UTF8))
            {
                using (StreamWriter SaveFile = new StreamWriter(MainFormClass.SaveFileDialog.OpenFile(), System.Text.Encoding.UTF8))
                {
                    foreach (string c in AnimationList)
                    {
                        string SerialOut = c;
                        SaveFile.WriteLine(SerialOut);
                        AutoSaveFile.WriteLine(SerialOut);
                    }
                }
            }
        }

        public void LoadAnimation()
        {
            Panel WorkingPanel = (Panel)MainFormClass.AnimationModePanel.Controls.Find("AnimationModeAnimationWindowWorkingPanel", true)[0];
            while (WorkingPanel.Controls.Count > 0)
                WorkingPanel.Controls[0].Dispose();

            AnimationList.Clear();

            string[] Lines = File.ReadAllLines(MainFormClass.LoadFileDialog.FileName, System.Text.Encoding.UTF8);
            for (int i = 0; i < Lines.Length; i++)
            {
                AnimationList.Add(Lines[i]);
                MakeNewLinePanel(Lines[i], i, WorkingPanel);
            }
        }

        public void AutoSave()
        {
            using (StreamWriter AutoSaveFile = new StreamWriter(MainFormClass.GenerateStreamFromString(Directory.GetCurrentDirectory() + "\\Animations\\0.txt"), System.Text.Encoding.UTF8))
            {
                foreach (string c in AnimationList)
                {
                    string SerialOut = c;
                    AutoSaveFile.WriteLine(SerialOut);
                }
            }
        }
    }
}
