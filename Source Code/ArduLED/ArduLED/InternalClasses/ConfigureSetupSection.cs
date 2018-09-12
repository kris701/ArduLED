using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduLEDNameSpace
{
    public class ConfigureSetupSection
    {
        private MainForm MainFormClass;

        public ConfigureSetupSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public void MakeLEDStrip(int _XLocation, int _YLocation, int _FromLEDID, bool _InvertXDir, bool _InvertYDir, int _XLEDAmount, int _YLEDAmount, int _PinID, string _IndputTextData, bool _IsIndividualLEDs, int _PixelTypeIndex, int _PixelBitstreamIndex)
        {
            int CurrentLED = _FromLEDID;
            Panel BackPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = (int)(_XLEDAmount * MainFormClass.ButtonWidth + MainFormClass.Margins) + MainFormClass.Margins * 2,
                Height = (int)(_YLEDAmount * (2 * MainFormClass.ButtonHeight) + MainFormClass.Margins) + MainFormClass.Margins * 2 + MainFormClass.ButtonHeight,
                Location = new Point(_XLocation, _YLocation)
            };
            if (_IsIndividualLEDs)
                BackPanel.Font = new Font(MainFormClass.IndividualLEDWorkingPanel.Font.FontFamily, BackPanel.Font.Size);
            else
                BackPanel.Font = new Font(MainFormClass.ConfigureSetupWorkingPanel.Font.FontFamily, BackPanel.Font.Size);
            BackPanel.BackColor = Color.Gray;
            if (!_IsIndividualLEDs)
            {
                BackPanel.MouseMove += MoveLEDStrip;
                BackPanel.MouseDown += MoveLEDStripDown;
                BackPanel.MouseUp += MoveLEDStripUp;
            }

            Button DeleteButton = new Button
            {
                Width = MainFormClass.ButtonWidth,
                Height = MainFormClass.ButtonHeight,
                Text = "X",
                Parent = BackPanel
            };
            DeleteButton.Click += RemoveLEDStrip;
            DeleteButton.Font = new Font(BackPanel.Font.FontFamily, 7);
            DeleteButton.Location = new Point(0, MainFormClass.Margins);
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.BackColor = Color.DarkGray;
            DeleteButton.Name = "MakeLEDPanelDeleteButton";
            BackPanel.Controls.Add(DeleteButton);

            Label StripIDLabel = new Label
            {
                Height = MainFormClass.ButtonHeight,
                Font = new Font(BackPanel.Font.FontFamily, 7),
                Tag = _PinID,
                Text = _PinID.ToString()
            };
            StripIDLabel.Location = new Point(StripIDLabel.Location.X + MainFormClass.ButtonWidth, MainFormClass.Margins);
            StripIDLabel.ForeColor = Color.White;
            StripIDLabel.Name = "MakeLEDPanelStripIDLabel";
            BackPanel.Controls.Add(StripIDLabel);

            bool UseDefaultText = true;
            string[] InputTextDataSplit = _IndputTextData.Split(';');
            if (_IndputTextData != "")
                UseDefaultText = false;

            int BoxNumber = 0;

            for (int i = 0; i < _XLEDAmount; i++)
            {
                for (int j = 0; j < _YLEDAmount; j++)
                {
                    if (!_IsIndividualLEDs)
                    {
                        TextBox NewButton = new TextBox
                        {
                            Width = MainFormClass.ButtonWidth,
                            Height = MainFormClass.ButtonHeight,
                            Text = CurrentLED.ToString(),
                            Font = new Font(BackPanel.Font.FontFamily, 7),
                            Enabled = false,
                            TextAlign = HorizontalAlignment.Center,
                            BorderStyle = BorderStyle.None,
                            BackColor = Color.DarkGray,
                            ForeColor = Color.White,
                            Name = "MakeLEDPanelStripLEDIDLabel"
                        };
                        if (_InvertXDir)
                        {
                            if (_InvertYDir)
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * ((_XLEDAmount - 1) - i), MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                            else
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * ((_XLEDAmount - 1) - i), MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * j + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                        }
                        else
                        {
                            if (_InvertYDir)
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * i, MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                            else
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * i, MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * j + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                        }

                        if (i == 0 && j == 0)
                        {
                            TextBox NewTextBox = new TextBox();
                            NewTextBox.Width = MainFormClass.ButtonWidth;
                            NewTextBox.Height = MainFormClass.ButtonHeight;
                            NewTextBox.Click += ClickToSetSeries;
                            if (UseDefaultText)
                            {
                                NewTextBox.Text = "0";
                            }
                            else
                            {
                                NewTextBox.Text = InputTextDataSplit[0];
                            }
                            NewTextBox.Font = new Font(BackPanel.Font.FontFamily, 7);
                            NewTextBox.TextChanged += ChangeSeries;
                            NewTextBox.Location = new Point(NewButton.Location.X, NewButton.Location.Y + MainFormClass.ButtonHeight);
                            NewTextBox.Parent = BackPanel;
                            NewTextBox.BorderStyle = BorderStyle.None;
                            NewTextBox.BackColor = Color.DarkGray;
                            NewTextBox.ForeColor = Color.White;
                            NewTextBox.Name = "MakeLEDPanelStripSeriesIDLabelFrom";

                            BackPanel.Controls.Add(NewTextBox);
                        }
                        if (i == _XLEDAmount - 1 && j == _YLEDAmount - 1)
                        {
                            TextBox NewTextBox = new TextBox();
                            NewTextBox.Width = MainFormClass.ButtonWidth;
                            NewTextBox.Height = MainFormClass.ButtonHeight;
                            NewTextBox.Click += ClickToSetSeries;
                            if (UseDefaultText)
                            {
                                NewTextBox.Text = "0";
                            }
                            else
                            {
                                NewTextBox.Text = InputTextDataSplit[1];
                            }
                            NewTextBox.Font = new Font(BackPanel.Font.FontFamily, 7);
                            NewTextBox.TextChanged += ChangeSeries;
                            NewTextBox.Location = new Point(NewButton.Location.X, NewButton.Location.Y + MainFormClass.ButtonHeight);
                            NewTextBox.Parent = BackPanel;
                            NewTextBox.BorderStyle = BorderStyle.None;
                            NewTextBox.BackColor = Color.DarkGray;
                            NewTextBox.ForeColor = Color.White;
                            NewTextBox.Name = "MakeLEDPanelStripSeriesIDLabelTo";

                            BackPanel.Controls.Add(NewTextBox);
                        }

                        BackPanel.Controls.Add(NewButton);
                    }
                    else
                    {
                        Button NewButton = new Button();
                        NewButton.Width = MainFormClass.ButtonWidth;
                        NewButton.Height = MainFormClass.ButtonHeight;
                        NewButton.Text = CurrentLED.ToString();
                        NewButton.Font = new Font(BackPanel.Font.FontFamily, 5);
                        NewButton.FlatStyle = FlatStyle.Flat;
                        NewButton.FlatAppearance.BorderSize = 0;
                        NewButton.BackColor = Color.DarkGray;
                        NewButton.ForeColor = Color.White;
                        NewButton.Name = "MakeLEDPanelStripLEDIDButton";
                        if (_InvertXDir)
                        {
                            if (_InvertYDir)
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * ((_XLEDAmount - 1) - i), MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                            else
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * ((_XLEDAmount - 1) - i), MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * j + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                        }
                        else
                        {
                            if (_InvertYDir)
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * i, MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                            else
                                NewButton.Location = new Point(MainFormClass.Margins + MainFormClass.ButtonWidth * i, MainFormClass.Margins + (MainFormClass.ButtonHeight * 2) * j + (MainFormClass.Margins + MainFormClass.ButtonHeight));
                        }

                        NewButton.Click += MainFormClass.ColorSingleLED_Click;
                        BackPanel.Controls.Add(NewButton);
                    }


                    CurrentLED++;
                    BoxNumber++;
                }
            }

            WorkingPanelBox TagData = new WorkingPanelBox(_XLocation, _YLocation, false, _XLEDAmount, _YLEDAmount, _PinID, _InvertXDir, _InvertYDir, _FromLEDID, _PixelTypeIndex, _PixelBitstreamIndex);

            BackPanel.Tag = TagData;

            if (_IsIndividualLEDs)
                MainFormClass.IndividualLEDWorkingPanel.Controls.Add(BackPanel);
            else
                MainFormClass.ConfigureSetupWorkingPanel.Controls.Add(BackPanel);
        }

        public void WorkingPanelMouseDown(object _Sender)
        {
            MainFormClass.DragStart = Control.MousePosition;
            Panel SenderPanel = _Sender as Panel;
            foreach (Control InnerControl in SenderPanel.Controls)
            {
                foreach (Control InnerInnerControl in InnerControl.Controls)
                {
                    InnerInnerControl.Visible = false;
                }
                WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)InnerControl.Tag;
                MomentaryDataTag.XLoc = InnerControl.Location.X;
                MomentaryDataTag.YLoc = InnerControl.Location.Y;
                MomentaryDataTag.Moving = true;
                InnerControl.Tag = MomentaryDataTag;
            }
        }

        public void WorkingPanelMouseUp(object _Sender)
        {
            Panel SenderPanel = _Sender as Panel;
            foreach (Control InnerControl in SenderPanel.Controls)
            {
                foreach (Control InnerInnerControl in InnerControl.Controls)
                {
                    InnerInnerControl.Visible = true;
                }
                WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)InnerControl.Tag;
                MomentaryDataTag.XLoc = InnerControl.Location.X;
                MomentaryDataTag.YLoc = InnerControl.Location.Y;
                MomentaryDataTag.Moving = false;
                InnerControl.Tag = MomentaryDataTag;
            }
        }

        public void WorkingPanelMouseMove(object _Sender)
        {
            Panel SenderPanel = _Sender as Panel;
            foreach (Control InnerControl in SenderPanel.Controls)
            {
                WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)InnerControl.Tag;
                if (MomentaryDataTag.Moving)
                {
                    InnerControl.Location = new Point(MomentaryDataTag.XLoc + (Control.MousePosition.X - MainFormClass.DragStart.X), MomentaryDataTag.YLoc + (Control.MousePosition.Y - MainFormClass.DragStart.Y));
                }
            }
        }

        public async Task SendSetup()
        {
            while (MainFormClass.IndividualLEDWorkingPanel.Controls.Count > 0)
                MainFormClass.IndividualLEDWorkingPanel.Controls[0].Dispose();

            foreach (Control InnerControl in MainFormClass.ConfigureSetupWorkingPanel.Controls)
            {
                WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)InnerControl.Tag;
                MakeLEDStrip(MomentaryDataTag.XLoc, MomentaryDataTag.YLoc, MomentaryDataTag.FromLEDID, MomentaryDataTag.InvertXDir, MomentaryDataTag.InvertYDir, MomentaryDataTag.XLEDCount, MomentaryDataTag.YLEDCount, MomentaryDataTag.PinID, "", true, MomentaryDataTag.PixelTypeIndex, MomentaryDataTag.PixelBitstreamIndex);
            }

            await Task.Run(async () =>
            {
                List<int> Pins = new List<int>();
                List<int> LEDCount = new List<int>();
                List<int> PixelTypesIndexs = new List<int>();
                List<int> PixelBitrateIndexs = new List<int>();

                foreach (Control c in MainFormClass.ConfigureSetupWorkingPanel.Controls)
                {
                    WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)c.Tag;
                    if (!Pins.Contains(MomentaryDataTag.PinID))
                    {
                        Pins.Add(MomentaryDataTag.PinID);
                        LEDCount.Add(MomentaryDataTag.XLEDCount * MomentaryDataTag.YLEDCount);
                        PixelTypesIndexs.Add(MomentaryDataTag.PixelTypeIndex);
                        PixelBitrateIndexs.Add(MomentaryDataTag.PixelBitstreamIndex);
                    }
                    else
                    {
                        int Index = Pins.FindIndex(x => x == MomentaryDataTag.PinID);
                        LEDCount[Index] += (MomentaryDataTag.XLEDCount * MomentaryDataTag.YLEDCount);
                    }
                }

                for (int i = 0; i < Pins.Count; i++)
                {
                    string SerialOut = "0;" + LEDCount[i] + ";" + Pins[i] + ";" + PixelTypesIndexs[i] + ";" + PixelBitrateIndexs[i];
                    MainFormClass.SendDataBySerial(SerialOut);
                }

                MainFormClass.SendDataBySerial("0;9999");

                int TotalLEDs = 0;
                foreach (int i in LEDCount)
                    TotalLEDs += i;

                MainFormClass.TotalLEDCount = TotalLEDs;

                MainFormClass.SendSetupProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.SendSetupProgressBar.Maximum = MainFormClass.ConfigureSetupWorkingPanel.Controls.Count; });
                if (MainFormClass.ConfigureSetupAutoSendCheckBox.Checked)
                    MainFormClass.ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.ConfigureSetupHiddenProgressBar.Maximum = MainFormClass.ConfigureSetupWorkingPanel.Controls.Count; });

                List<int> UpOrDownFrom = new List<int>();
                List<int> UpOrDownTo = new List<int>();
                List<int> InternalPins = new List<int>();
                List<int> SeriesData = new List<int>();

                foreach (Control c in MainFormClass.ConfigureSetupWorkingPanel.Controls)
                {
                    WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)c.Tag;
                    InternalPins.Add(MomentaryDataTag.PinID);

                    int Lowest = 999999;
                    int Highest = 0;
                    foreach (Control g in c.Controls)
                    {
                        if (g is TextBox)
                        {
                            if (!g.Enabled)
                            {
                                int Value = Int32.Parse(g.Text);
                                if (Value > Highest)
                                    Highest = Value;
                                if (Value < Lowest)
                                    Lowest = Value;
                            }
                        }
                    }

                    int UpDownValue = Int32.Parse(c.Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", true)[0].Text) - Int32.Parse(c.Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", true)[0].Text);
                    if (UpDownValue < 0)
                        UpDownValue = 0;
                    if (UpDownValue > 0)
                    {
                        UpOrDownFrom.Add(Lowest);
                        UpOrDownTo.Add(Highest);
                    }
                    else
                    {
                        UpOrDownFrom.Add(Highest);
                        UpOrDownTo.Add(Lowest);
                    }
                }

                int PanelNumber = 0;
                for (int i = 0; i < MainFormClass.ConfigureSetupWorkingPanel.Controls.Count; i++)
                {
                    int Position = SeriesData.Count;
                    for (int j = 0; j < SeriesData.Count; j++)
                    {
                        int ValueA = Int32.Parse(MainFormClass.ConfigureSetupWorkingPanel.Controls[i].Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", true)[0].Text);
                        int ValueB = Int32.Parse(MainFormClass.ConfigureSetupWorkingPanel.Controls[j].Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", true)[0].Text);
                        if (ValueA < ValueB)
                        {
                            Position--;
                        }
                    }
                    SeriesData.Insert(Position, PanelNumber);
                    PanelNumber++;
                }

                for (int i = 0; i < InternalPins.Count; i++)
                {
                    MainFormClass.SendSetupProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.SendSetupProgressBar.Value = i; });
                    if (MainFormClass.ConfigureSetupAutoSendCheckBox.Checked)
                        MainFormClass.ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.ConfigureSetupHiddenProgressBar.Value = i; });

                    string SerialOut = "0;" + UpOrDownFrom[SeriesData[i]] + ";" + UpOrDownTo[SeriesData[i]] + ";" + InternalPins[SeriesData[i]] + ";";
                    MainFormClass.SendDataBySerial(SerialOut);
                }

                MainFormClass.SendDataBySerial("0;9999;");

                MainFormClass.SendSetupProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.SendSetupProgressBar.Value = 0; });
                if (MainFormClass.ConfigureSetupAutoSendCheckBox.Checked)
                {
                    for (int i = MainFormClass.Width - MainFormClass.MenuButton.Width; i < MainFormClass.Width; i++)
                    {
                        MainFormClass.ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.ConfigureSetupHiddenProgressBar.Location = new Point(i, 0); });
                        await Task.Delay(5);
                    }
                    MainFormClass.ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { MainFormClass.ConfigureSetupHiddenProgressBar.Visible = false; });
                    MainFormClass.ConfigureSetupAutoSendCheckBox.Invoke((MethodInvoker)delegate { MainFormClass.ConfigureSetupAutoSendCheckBox.Enabled = true; });
                }

                MainFormClass.SendDataBySerial("0;9999");
            });
        }

        private void ChangeSeries(object sender, EventArgs e)
        {
            TextBox SenderTextBox = sender as TextBox;
            Panel ParentPanel = SenderTextBox.Parent as Panel;

            if (SenderTextBox.Name == "MakeLEDPanelStripSeriesIDLabelFrom")
            {
                TextBox Textbox2 = ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", false)[0] as TextBox;
                SenderTextBox.TextChanged -= ChangeSeries;
                Textbox2.TextChanged -= ChangeSeries;
                string Value1 = (Int32.Parse(SenderTextBox.Text) + ParentPanel.Controls.Count - 5).ToString();
                ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", false)[0].Text = Value1;
                SenderTextBox.TextChanged += ChangeSeries;
                Textbox2.TextChanged += ChangeSeries;
            }
            else
            {
                TextBox Textbox2 = ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", false)[0] as TextBox;
                SenderTextBox.TextChanged -= ChangeSeries;
                Textbox2.TextChanged -= ChangeSeries;
                string Value1 = (Int32.Parse(SenderTextBox.Text) + ParentPanel.Controls.Count - 5).ToString();
                ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", false)[0].Text = Value1;
                SenderTextBox.TextChanged += ChangeSeries;
                Textbox2.TextChanged += ChangeSeries;
            }
        }

        private void ClickToSetSeries(object sender, EventArgs e)
        {
            if (MainFormClass.ConfigureSetupClickToSetupSeriesCheckBox.Checked)
            {
                TextBox SenderTextBox = sender as TextBox;
                Panel ParentPanel = SenderTextBox.Parent as Panel;

                if (SenderTextBox.Name == "MakeLEDPanelStripSeriesIDLabelFrom")
                {
                    TextBox Textbox2 = ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", false)[0] as TextBox;
                    SenderTextBox.TextChanged -= ChangeSeries;
                    Textbox2.TextChanged -= ChangeSeries;
                    int IncrementValue = (int)MainFormClass.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value + ParentPanel.Controls.Count - 5;
                    SenderTextBox.Text = MainFormClass.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value.ToString();
                    string Value1 = IncrementValue.ToString();
                    MainFormClass.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value = IncrementValue + 1;
                    ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", false)[0].Text = Value1;
                    SenderTextBox.TextChanged += ChangeSeries;
                    Textbox2.TextChanged += ChangeSeries;
                }
                else
                {
                    TextBox Textbox2 = ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", false)[0] as TextBox;
                    SenderTextBox.TextChanged -= ChangeSeries;
                    Textbox2.TextChanged -= ChangeSeries;
                    int IncrementValue = (int)MainFormClass.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value + ParentPanel.Controls.Count - 5;
                    SenderTextBox.Text = MainFormClass.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value.ToString();
                    string Value1 = IncrementValue.ToString();
                    MainFormClass.ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value = IncrementValue + 1;
                    ParentPanel.Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", false)[0].Text = Value1;
                    SenderTextBox.TextChanged += ChangeSeries;
                    Textbox2.TextChanged += ChangeSeries;
                }
            }
        }

        private void MoveLEDStrip(object sender, MouseEventArgs e)
        {
            Panel SenderPanel = sender as Panel;
            WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)SenderPanel.Tag;
            if (MomentaryDataTag.Moving == true)
            {
                SenderPanel.Location = new Point(MomentaryDataTag.XLoc + (Control.MousePosition.X - MainFormClass.DragStart.X), MomentaryDataTag.YLoc + (Control.MousePosition.Y - MainFormClass.DragStart.Y));
            }
        }

        private void MoveLEDStripDown(object sender, MouseEventArgs e)
        {
            MainFormClass.DragStart = Control.MousePosition;
            Panel SenderPanel = sender as Panel;
            foreach (Control InnerControl in SenderPanel.Parent.Controls)
            {
                foreach (Control InnerInnerControl in InnerControl.Controls)
                {
                    InnerInnerControl.Visible = false;
                }
            }
            WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)SenderPanel.Tag;
            MomentaryDataTag.XLoc = SenderPanel.Location.X;
            MomentaryDataTag.YLoc = SenderPanel.Location.Y;
            MomentaryDataTag.Moving = true;
            SenderPanel.Tag = MomentaryDataTag;
        }

        private void MoveLEDStripUp(object sender, MouseEventArgs e)
        {
            Panel SenderPanel = sender as Panel;
            foreach (Control InnerControl in SenderPanel.Parent.Controls)
            {
                foreach (Control InnerInnerControl in InnerControl.Controls)
                {
                    InnerInnerControl.Visible = true;
                }
            }
            WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)SenderPanel.Tag;
            MomentaryDataTag.XLoc = SenderPanel.Location.X;
            MomentaryDataTag.YLoc = SenderPanel.Location.Y;
            MomentaryDataTag.Moving = false;
            SenderPanel.Tag = MomentaryDataTag;
        }

        private void RemoveLEDStrip(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            SenderButton.Parent.Dispose();
        }

        public void LoadASetup(string _FileName)
        {
            while (MainFormClass.ConfigureSetupWorkingPanel.Controls.Count > 0)
                MainFormClass.ConfigureSetupWorkingPanel.Controls[0].Dispose();
            while (MainFormClass.IndividualLEDWorkingPanel.Controls.Count > 0)
                MainFormClass.IndividualLEDWorkingPanel.Controls[0].Dispose();

            string[] Lines = File.ReadAllLines(_FileName, System.Text.Encoding.UTF8);
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Split = Lines[i].Split(';');
                MainFormClass.ConfigureSetupSectionClass.MakeLEDStrip(Int32.Parse(Split[0]), Int32.Parse(Split[1]), Int32.Parse(Split[2]), Boolean.Parse(Split[3]), Boolean.Parse(Split[4]), Int32.Parse(Split[5]), Int32.Parse(Split[6]), Int32.Parse(Split[7]), Lines[i + 1], false, Int32.Parse(Split[8]), Int32.Parse(Split[9]));
                MainFormClass.ConfigureSetupSectionClass.MakeLEDStrip(Int32.Parse(Split[0]), Int32.Parse(Split[1]), Int32.Parse(Split[2]), Boolean.Parse(Split[3]), Boolean.Parse(Split[4]), Int32.Parse(Split[5]), Int32.Parse(Split[6]), Int32.Parse(Split[7]), Lines[i + 1], true, Int32.Parse(Split[8]), Int32.Parse(Split[9]));
                i++;
            }
        }

        public void SaveCurrentSetup()
        {
            using (StreamWriter SaveFile = new StreamWriter(MainFormClass.SaveFileDialog.FileName, false))
            {
                using (StreamWriter AutoSaveFile = new StreamWriter(Directory.GetCurrentDirectory() + "\\Setups\\0.txt", false))
                {
                    foreach (Control c in MainFormClass.ConfigureSetupWorkingPanel.Controls)
                    {
                        WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)c.Tag;
                        string SerialOut = MomentaryDataTag.XLoc + ";" + MomentaryDataTag.YLoc + ";" + MomentaryDataTag.FromLEDID + ";" + MomentaryDataTag.InvertXDir + ";" + MomentaryDataTag.InvertYDir + ";" + MomentaryDataTag.XLEDCount + ";" + MomentaryDataTag.YLEDCount + ";" + MomentaryDataTag.PinID + ";" + MomentaryDataTag.PixelTypeIndex + ";" + MomentaryDataTag.PixelBitstreamIndex;
                        SaveFile.WriteLine(SerialOut);
                        AutoSaveFile.WriteLine(SerialOut);

                        SerialOut = "";
                        SerialOut += (c.Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", true)[0] as TextBox).Text + ";";
                        SerialOut += (c.Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", true)[0] as TextBox).Text + ";";

                        SaveFile.WriteLine(SerialOut);
                        AutoSaveFile.WriteLine(SerialOut);
                    }
                }
            }
        }

        public void AutoloadLastSetup()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Setups\\0.txt"))
            {
                LoadASetup(Directory.GetCurrentDirectory() + "\\Setups\\0.txt");
            }
        }

        public void AutoSave()
        {
            using (StreamWriter AutoSaveFile = new StreamWriter(Directory.GetCurrentDirectory() + "\\Setups\\0.txt", false))
            {
                foreach (Control c in MainFormClass.ConfigureSetupWorkingPanel.Controls)
                {
                    WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)c.Tag;
                    string SerialOut = MomentaryDataTag.XLoc + ";" + MomentaryDataTag.YLoc + ";" + MomentaryDataTag.FromLEDID + ";" + MomentaryDataTag.InvertXDir + ";" + MomentaryDataTag.InvertYDir + ";" + MomentaryDataTag.XLEDCount + ";" + MomentaryDataTag.YLEDCount + ";" + MomentaryDataTag.PinID + ";" + MomentaryDataTag.PixelTypeIndex + ";" + MomentaryDataTag.PixelBitstreamIndex;
                    AutoSaveFile.WriteLine(SerialOut);

                    SerialOut = "";
                    SerialOut += (c.Controls.Find("MakeLEDPanelStripSeriesIDLabelFrom", true)[0] as TextBox).Text + ";";
                    SerialOut += (c.Controls.Find("MakeLEDPanelStripSeriesIDLabelTo", true)[0] as TextBox).Text + ";";

                    AutoSaveFile.WriteLine(SerialOut);
                }
            }
        }
    }
}
