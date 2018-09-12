using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace ArduLEDNameSpace
{
    public partial class MainForm : Form
    {
        #region Variabels

        public int ButtonWidth = 20;
        public int ButtonHeight = 15;
        public int BoxHeight = 45;
        public int Margins = 5;
        public int ScroolBarWidth = 25;
        public int Sizex = 1411;
        public int Sizey = 775;

        public bool ShowLoadingScreen = true;
        public bool UnitReady = false;
        private bool ReadyToRecive = false;
        private int UnitTimeoutCounter = 0;
        public bool VisualizerEnabled = false;
        public int TotalLEDCount = 0;

        public List<Control> ControlList = new List<Control>();

        public Point DragStart = new Point(0, 0);

        public AmbilightSide LeftSide;
        public AmbilightSide TopSide;
        public AmbilightSide RightSide;
        public AmbilightSide BottomSide;

        public VisualizerSection VisualizerSectionClass;
        public AmbiLightSection AmbiLightSectionClass;
        public InstructionsSection InstructionsSectionClass;
        public IndividualLEDSection IndividualLEDSectionClass;
        public ConfigureSetupSection ConfigureSetupSectionClass;
        public FadeColorsSection FadeColorsSectionClass;
        public MenuSection MenuSectionClass;
        public LoadingSection LoadingSectionClass;
        public AnimationModeSection AnimationModeSectionClass;
        public ServerAPISection ServerAPISectionClass;

        #endregion

        #region Base

        public void LoadSettings(string _Location)
        {
            if (File.Exists(_Location))
            {
                string[] Lines = File.ReadAllLines(_Location, System.Text.Encoding.UTF8);
                for (int i = 0; i < Lines.Length; i++)
                {
                    try
                    {
                        string[] Split = Lines[i].Split(';');
                        if (Split[0] != "")
                        {
                            if (Split[0].ToUpper() == "COMBOBOX")
                            {
                                ComboBox LoadCombobox = Controls.Find(Split[1], true)[0] as ComboBox;
                                LoadCombobox.SelectedIndex = Int32.Parse(Split[2]);
                            }
                            if (Split[0].ToUpper() == "CHECKBOX")
                            {
                                CheckBox LoadCheckBox = Controls.Find(Split[1], true)[0] as CheckBox;
                                LoadCheckBox.Checked = Convert.ToBoolean(Split[2]);
                            }
                            if (Split[0].ToUpper() == "TEXTBOX")
                            {
                                TextBox LoadTextBox = Controls.Find(Split[1], true)[0] as TextBox;
                                LoadTextBox.Text = Split[2];
                            }
                            if (Split[0].ToUpper() == "NUMERICUPDOWN")
                            {
                                NumericUpDown LoadNumericUpDown = Controls.Find(Split[1], true)[0] as NumericUpDown;
                                LoadNumericUpDown.Value = Convert.ToDecimal(Split[2]);
                            }
                            if (Split[0].ToUpper() == "TRACKBAR")
                            {
                                TrackBar LoadTrackBar = Controls.Find(Split[1], true)[0] as TrackBar;
                                LoadTrackBar.Value = Int32.Parse(Split[2]);
                            }
                            if (Split[0].ToUpper() == "SERIALPORT")
                            {
                                SerialPort1.BaudRate = Int32.Parse(Split[1]);
                            }
                        }
                    }
                    catch { }
                }
                FormatLayout();
            }
        }

        public void SaveSettings(string _Location, string _Additional)
        {
            if (File.Exists(_Location))
                File.Delete(_Location);

            using (StreamWriter SaveFile = File.CreateText(_Location))
            {
                string SerialOut;
                if (_Additional != "")
                {
                    SerialOut = _Additional;
                    SaveFile.WriteLine(SerialOut);
                }
                foreach (Control c in ControlList)
                {
                    if (c is ComboBox)
                    {
                        ComboBox SaveComboBox = c as ComboBox;
                        SerialOut = "COMBOBOX;" + SaveComboBox.Name + ";" + SaveComboBox.SelectedIndex;
                        SaveFile.WriteLine(SerialOut);
                        continue;
                    }
                    if (c is CheckBox)
                    {
                        CheckBox SaveCheckBox = c as CheckBox;
                        SerialOut = "CHECKBOX;" + SaveCheckBox.Name + ";" + SaveCheckBox.Checked;
                        SaveFile.WriteLine(SerialOut);
                        continue;
                    }
                    if (c is TextBox)
                    {
                        TextBox SaveTextBox = c as TextBox;
                        SerialOut = "TEXTBOX;" + SaveTextBox.Name + ";" + SaveTextBox.Text;
                        SaveFile.WriteLine(SerialOut);
                        continue;
                    }
                    if (c is NumericUpDown)
                    {
                        NumericUpDown SaveNumericUpDown = c as NumericUpDown;
                        SerialOut = "NUMERICUPDOWN;" + SaveNumericUpDown.Name + ";" + SaveNumericUpDown.Value;
                        SaveFile.WriteLine(SerialOut);
                        continue;
                    }
                    if (c is TrackBar)
                    {
                        TrackBar SaveTrackBar = c as TrackBar;
                        SerialOut = "TRACKBAR;" + SaveTrackBar.Name + ";" + SaveTrackBar.Value;
                        SaveFile.WriteLine(SerialOut);
                        continue;
                    }
                }
            }
            ControlList.Clear();
        }

        public void FormatLayout()
        {
            BeatZoneChart.ChartAreas[0].AxisX.Minimum = 0;
            SpectrumChart.ChartAreas[0].AxisX.Minimum = 0;
            BeatZoneChart.ChartAreas[0].AxisX.Maximum = BeatZoneToTrackBar.Maximum;
            SpectrumChart.ChartAreas[0].AxisX.Maximum = BeatZoneToTrackBar.Maximum;

            VisualizerSectionClass.UpdateSpectrumChart(SpectrumChart, SpectrumRedTextBox.Text, SpectrumGreenTextBox.Text, SpectrumBlueTextBox.Text, (int)VisualSamplesNumericUpDown.Value, SpectrumAutoScaleValuesCheckBox.Checked);
            VisualizerSectionClass.UpdateSpectrumChart(WaveChart, WaveRedTextBox.Text, WaveGreenTextBox.Text, WaveBlueTextBox.Text, 255 * 3, WaveAutoScaleValuesCheckBox.Checked);

            FadeColorsRedLabel.Text = FadeColorsRedTrackBar.Value.ToString();
            FadeColorsGreenLabel.Text = FadeColorsGreenTrackBar.Value.ToString();
            FadeColorsBlueLabel.Text = FadeColorsBlueTrackBar.Value.ToString();
            FormatCustomText((int)Math.Round(((double)(FadeColorsRedTrackBar.Value + FadeColorsGreenTrackBar.Value + FadeColorsBlueTrackBar.Value) / (double)(3 * 255)) * 100, 0), FadeColorsBrightnessLabel, "%");

            IndividalLEDRedLabel.Text = IndividalLEDRedTrackBar.Value.ToString();
            IndividalLEDGreenLabel.Text = IndividalLEDGreenTrackBar.Value.ToString();
            IndividalLEDBlueLabel.Text = IndividalLEDBlueTrackBar.Value.ToString();

            SmoothnessLabel.Text = SmoothnessTrackBar.Value.ToString();
            SampleTimeLabel.Text = SampleTimeTrackBar.Value.ToString();
            SensitivityLabel.Text = SensitivityTrackBar.Value.ToString();

            FormatCustomText(BeatZoneTriggerHeight.Value, BeatZoneTriggerHeightLabel, "");
            FormatCustomText(BeatZoneFromTrackBar.Value, BeatZoneFromLabel, "");
            FormatCustomText(BeatZoneToTrackBar.Value, BeatZoneToLabel, "");

            AnimationModeRedTrackbarLabel.Text = AnimationModeRedTrackbar.Value.ToString();
            AnimationModeGreenTrackbarLabel.Text = AnimationModeGreenTrackbar.Value.ToString();
            AnimationModeBlueTrackbarLabel.Text = AnimationModeBlueTrackbar.Value.ToString();
        }

        public void FormatCustomText(int _Value, Control _Control, string _Additional)
        {
            if (_Value < 10)
            {
                _Control.Text = _Control.Text.Substring(0, _Control.Text.Length - (3 + _Additional.Length)) + "  " + _Value.ToString() + _Additional;
            }
            else
            {
                if (_Value < 100)
                {
                    _Control.Text = _Control.Text.Substring(0, _Control.Text.Length - (3 + _Additional.Length)) + " " + _Value.ToString() + _Additional;
                }
                else
                {
                    _Control.Text = _Control.Text.Substring(0, _Control.Text.Length - (3 + _Additional.Length)) + _Value.ToString() + _Additional;
                }
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!UnitReady)
                UnitReady = true;
            if (SerialPort1.BytesToRead > 0)
            {
                if (!ReadyToRecive)
                {
                    ReadyToRecive = true;
                    UnitTimeoutCounter = 0;
                }
                SerialPort1.ReadChar();
            }
        }

        public void SendDataBySerial(string _Input)
        {
            if (UnitReady)
            {
                int TimeoutCounter = 0;
                while (!ReadyToRecive)
                {
                    Application.DoEvents();
                    Thread.Sleep(1);
                    TimeoutCounter++;
                    if (TimeoutCounter > 250)
                    {
                        UnitTimeoutCounter++;
                        if (UnitTimeoutCounter > 20)
                        {
                            MessageBox.Show("Connection to Unit failed!");
                            VisualizerSectionClass.EnableBASS(false);
                            AmbiLightSectionClass.StopAmbilight();
                            ModeSelectrionComboBox.SelectedIndex = 0;
                            UnitTimeoutCounter = 0;
                            break;
                        }
                        ReadyToRecive = true;
                        break;
                    }
                }
            }
            if (ReadyToRecive)
            {
                try
                {
                    SerialPort1.WriteLine(";" + _Input + ";-1;");
                }
                catch { }
                ReadyToRecive = false;
            }
        }

        public Color ShuffleColors(Color _InputColors)
        {
            int Red = 0;
            int Green = 0;
            int Blue = 0;

            if (ConfigureSetupRGBColorOrderFirstTextbox.Text == "R")
                Red = _InputColors.R;
            if (ConfigureSetupRGBColorOrderFirstTextbox.Text == "G")
                Red = _InputColors.G;
            if (ConfigureSetupRGBColorOrderFirstTextbox.Text == "B")
                Red = _InputColors.B;

            if (ConfigureSetupRGBColorOrderSeccondTextbox.Text == "R")
                Green = _InputColors.R;
            if (ConfigureSetupRGBColorOrderSeccondTextbox.Text == "G")
                Green = _InputColors.G;
            if (ConfigureSetupRGBColorOrderSeccondTextbox.Text == "B")
                Green = _InputColors.B;

            if (ConfigureSetupRGBColorOrderThirdTextbox.Text == "R")
                Blue = _InputColors.R;
            if (ConfigureSetupRGBColorOrderThirdTextbox.Text == "G")
                Blue = _InputColors.G;
            if (ConfigureSetupRGBColorOrderThirdTextbox.Text == "B")
                Blue = _InputColors.B;

            return Color.FromArgb(Red, Green, Blue);
        }

        public void AutoLoadAllSettings()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\cfg.txt"))
            {
                LoadSettings(Directory.GetCurrentDirectory() + "\\cfg.txt");
            }
        }

        public void AutoSaveAllSettings()
        {
            GetAllControls(this);

            SaveSettings(Directory.GetCurrentDirectory() + "\\cfg.txt",
                "SERIALPORT;" + SerialPort1.BaudRate + Environment.NewLine);
        }

        public void GetAllControls(Control _InputControl)
        {
            foreach (Control c in _InputControl.Controls)
            {
                GetAllControls(c);
                if (c.Tag != null)
                    if (c.Tag is string)
                        if ((string)c.Tag == "Setting")
                            ControlList.Add(c);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoadingSectionClass != null)
            {
                if (LoadingSectionClass.LoadingForm.Name != "Closing")
                    AutoSaveAllSettings();
            }
            else
            {
                AutoSaveAllSettings();
            }
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Temp.txt"))
                File.Delete(Directory.GetCurrentDirectory() + "\\Temp.txt");
        }

        private void ResetToDefaultPosition(object sender, EventArgs e)
        {
            Size = new Size(Sizex, Sizey);
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Sizex, 0);
        }

        public Stream GenerateStreamFromString(string _Input)
        {
            var Stream = new MemoryStream();
            var Writer = new StreamWriter(Stream);
            Writer.Write(_Input);
            Writer.Flush();
            Stream.Position = 0;
            return Stream;
        }

        #endregion

        #region Loading Section

        public MainForm()
        {
            InitializeComponent();
        }

        public async void Form1_Load(object sender, EventArgs e)
        {
            AmbiLightSectionClass = new AmbiLightSection(this);
            VisualizerSectionClass = new VisualizerSection(this);
            InstructionsSectionClass = new InstructionsSection(this);
            IndividualLEDSectionClass = new IndividualLEDSection(this);
            ConfigureSetupSectionClass = new ConfigureSetupSection(this);
            FadeColorsSectionClass = new FadeColorsSection(this);
            MenuSectionClass = new MenuSection(this);
            LoadingSectionClass = new LoadingSection(this);
            AnimationModeSectionClass = new AnimationModeSection(this);
            ServerAPISectionClass = new ServerAPISection(this);

            await LoadingSectionClass.MainLoadingSection();
        }

        #endregion

        #region Menu Section

        private void Connect(object sender, EventArgs e)
        {
            MenuSectionClass.ConnectToComDevice();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MenuSectionClass.ShowHideMenu();
        }

        private void ModeSelectrionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuSectionClass.ModeIndexChange();
        }

        private void MenuExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuSectionClass.LanguageIndexChange();
        }

        private async void MainForm_Activated(object sender, EventArgs e)
        {
            if (UnitReady)
                await MenuSectionClass.ShowArduLED();
        }

        #endregion

        #region Fade Colors Section

        private void FadeColorsRed_ValueChanged(object sender, EventArgs e)
        {
            FadeColorsRedLabel.Text = FadeColorsRedTrackBar.Value.ToString();
            FormatCustomText((int)Math.Round(((double)(FadeColorsRedTrackBar.Value + FadeColorsGreenTrackBar.Value + FadeColorsBlueTrackBar.Value) / (double)(3 * 255)) * 100, 0), FadeColorsBrightnessLabel, "%");
        }

        private void FadeColorsGreen_ValueChanged(object sender, EventArgs e)
        {
            FadeColorsGreenLabel.Text = FadeColorsGreenTrackBar.Value.ToString();
            FormatCustomText((int)Math.Round(((double)(FadeColorsRedTrackBar.Value + FadeColorsGreenTrackBar.Value + FadeColorsBlueTrackBar.Value) / (double)(3 * 255)) * 100, 0), FadeColorsBrightnessLabel, "%");
        }

        private void FadeColorsBlue_ValueChanged(object sender, EventArgs e)
        {
            FadeColorsBlueLabel.Text = FadeColorsBlueTrackBar.Value.ToString();
            FormatCustomText((int)Math.Round(((double)(FadeColorsRedTrackBar.Value + FadeColorsGreenTrackBar.Value + FadeColorsBlueTrackBar.Value) / (double)(3 * 255)) * 100, 0), FadeColorsBrightnessLabel, "%");
        }

        private void FadeColors_BeginSendData(object sender, MouseEventArgs e)
        {
            FadeColorsSectionClass.FadeColorsSendData(
                false, 
                (int)FadeLEDPanelFromIDNumericUpDown.Value, 
                (int)FadeLEDPanelToIDNumericUpDown.Value, 
                Color.FromArgb(FadeColorsRedTrackBar.Value, FadeColorsGreenTrackBar.Value, FadeColorsBlueTrackBar.Value),
                (int)FadeColorsFadeSpeedNumericUpDown.Value,
                (int)Math.Round(FadeColorsFadeFactorNumericUpDown.Value * 100, 0)
                );
        }

        #endregion

        #region Configure Setup Section

        private void AddLEDStrip(object sender, EventArgs e)
        {
            ConfigureSetupSectionClass.MakeLEDStrip(0, 0, (int)ConfigureSetupAddStripFromLEDID.Value, ConfigureSetupAddStripInvertX.Checked, ConfigureSetupAddStripInvertY.Checked, (int)ConfigureSetupAddStripXDir.Value, (int)ConfigureSetupAddStripYDir.Value, (int)ConfigureSetupAddStripPinID.Value, "", false, PixelTypeComboBox.SelectedIndex, PixelBitstreamComboBox.SelectedIndex);
        }

        private void LoadSetup(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Setups";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConfigureSetupSectionClass.LoadASetup(LoadFileDialog.FileName);
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private async void SendSetupButton_Click(object sender, EventArgs e)
        {
            await ConfigureSetupSectionClass.SendSetup();
        }

        private void ConfigureSetupWorkingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ConfigureSetupSectionClass.WorkingPanelMouseDown(sender);
        }

        private void ConfigureSetupWorkingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ConfigureSetupSectionClass.WorkingPanelMouseUp(sender);
        }

        private void ConfigureSetupWorkingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            ConfigureSetupSectionClass.WorkingPanelMouseMove(sender);
        }

        private void ConfigureSetupRGBColorOrderTextboxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'R' | e.KeyChar == 'G' | e.KeyChar == 'B')
            {
                TextBox SenderTextbox = sender as TextBox;
                SenderTextbox.Text = e.KeyChar.ToString();
            }
            e.Handled = true;
        }

        private void SaveSetup(object sender, EventArgs e)
        {
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Setups";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConfigureSetupSectionClass.SaveCurrentSetup();
            }
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        #endregion

        #region Individual LED Section

        public async void ColorSingleLED_Click(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            if (ColorEntireLEDStripCheckBox.Checked)
            {
                await IndividualLEDSectionClass.ColorEntireLEDStrip(SenderButton);
            }
            else
            {
                IndividualLEDSectionClass.ColorSingleLED(SenderButton);
            }
        }

        private void IndividalLEDRedTrackBar_Scroll(object sender, EventArgs e)
        {
            IndividalLEDRedLabel.Text = IndividalLEDRedTrackBar.Value.ToString();
        }

        private void IndividalLEDGreenTrackBar_Scroll(object sender, EventArgs e)
        {
            IndividalLEDGreenLabel.Text = IndividalLEDGreenTrackBar.Value.ToString();
        }

        private void IndividalLEDBlueTrackBar_Scroll(object sender, EventArgs e)
        {
            IndividalLEDBlueLabel.Text = IndividalLEDBlueTrackBar.Value.ToString();
        }

        private void IndividualLEDWorkingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ConfigureSetupSectionClass.WorkingPanelMouseDown(sender);
        }

        private void IndividualLEDWorkingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ConfigureSetupSectionClass.WorkingPanelMouseUp(sender);
        }

        private void IndividualLEDWorkingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            ConfigureSetupSectionClass.WorkingPanelMouseMove(sender);
        }

        #endregion

        #region Instructions Region

        private async void InstructionStartLoopButton_Click(object sender, EventArgs e)
        {
            if (!InstructionsSectionClass.InstructionsRunning)
            {
                InstructionsSectionClass.ContinueInstructionsLoop = true;
                await InstructionsSectionClass.RunInstructions();
            }
        }

        private void InstructionsAddDelayButton_Click(object sender, EventArgs e)
        {
            HideInstructionsPanels();
            InstructionsAddDelayPanel.Visible = true;
        }

        private void InstructionsAddFadeColorsButton_Click(object sender, EventArgs e)
        {
            HideInstructionsPanels();
            InstructionsAddFadeColorsPanel.Visible = true;
        }

        private void InstructionsAddIndividualLEDButton_Click(object sender, EventArgs e)
        {
            HideInstructionsPanels();
            InstructionsAddIndividualLEDPanel.Visible = true;
        }

        private void InstructionsAddVisualizerButton_Click(object sender, EventArgs e)
        {
            HideInstructionsPanels();
            InstructionsAddVisualizerPanel.Visible = true;
        }

        private void InstructionsAddAmbilightButton_Click(object sender, EventArgs e)
        {
            HideInstructionsPanels();
            InstructionsAddAmbilightPanel.Visible = true;
        }

        private void InstructionsAddWaitUntilButton_Click(object sender, EventArgs e)
        {
            HideInstructionsPanels();
            InstructionsAddWaitUntilSelectDateYear.Value = DateTime.Today.Year;
            InstructionsAddWaitUntilSelectDateMonth.Value = DateTime.Today.Month;
            InstructionsAddWaitUntilSelectDateDay.Value = DateTime.Today.Day;
            InstructionsAddWaitUntilSelectTimeHour.Value = DateTime.Now.Hour;
            InstructionsAddWaitUntilSelectTimeMinute.Value = DateTime.Now.Minute;
            InstructionsAddWaitUntilSelectTimeSecond.Value = DateTime.Now.Second;
            InstructionsAddWaitUntilPanel.Visible = true;
        }

        void HideInstructionsPanels()
        {
            InstructionsAddDelayPanel.Visible = false;
            InstructionsAddFadeColorsPanel.Visible = false;
            InstructionsAddVisualizerPanel.Visible = false;
            InstructionsAddIndividualLEDPanel.Visible = false;
            InstructionsAddAmbilightPanel.Visible = false;
            InstructionsAddWaitUntilPanel.Visible = false;
        }

        private void InstructionsAddDelayAddButton_Click(object sender, EventArgs e)
        {
            InstructionsSectionClass.AddInstruction("Delay;" + InstructionsAddDelayNumericUpDown.Value);
        }

        private void InstructionsAddFadeColorsAddButton_Click(object sender, EventArgs e)
        {
            InstructionsSectionClass.AddInstruction("Fade Colors;" + InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Value + ";" + InstructionsAddFadeColorsToSeriesIDNumericUpDown.Value + ";" + InstructionsAddFadeColorsRedTrackBar.Value.ToString() + ";" + InstructionsAddFadeColorsGreenTrackBar.Value.ToString() + ";" + InstructionsAddFadeColorsBlueTrackBar.Value.ToString() + ";" + InstructionsAddFadeColorsFadeSpeedNumericUpDown.Value.ToString() + ";" + InstructionsAddFadeColorsFadeFactorNumericUpDown.Value.ToString());
        }

        private void InstructionsAddIndividualLEDAddButton_Click(object sender, EventArgs e)
        {
            InstructionsSectionClass.AddInstruction("Individual LED;" + InstructionsAddIndividualLEDOnPinNumericUpDown.Value + ";" + InstructionsAddIndividualLEDAtIdNumericUpDown.Value + ";" + InstructionsAddIndividualLEDRedTrackBar.Value + ";" + InstructionsAddIndividualLEDGreenTrackBar.Value.ToString() + ";" + InstructionsAddIndividualLEDBlueTrackBar.Value.ToString());
        }

        private void InstructionsAddVisualizerPanelAdd_Click(object sender, EventArgs e)
        {
            InstructionsSectionClass.AddInstruction("Visualizer;" + InstructionsAddVisualizerStopVisualizerCheckBox.Checked + ";" + (string)InstructionsAddVisualizerLoadSetup.Tag);
        }

        private void InstructionsAddAmbilightAddButton_Click(object sender, EventArgs e)
        {
            InstructionsSectionClass.AddInstruction("Ambilight;" + InstructionsAddAmbilightStopAmbilightCheckBox.Checked + ";" + InstructionsAddAmbilightShowHideBlocksCheckBox.Checked + ";" + InstructionsAddAmbilightAutoSetOffsetsCheckBox.Checked + ";" + (string)InstructionsAddAmbilightUseAmbilightSettings.Tag);
        }

        private void InstructionsAddWaitUntilAddButton_Click(object sender, EventArgs e)
        {
            InstructionsSectionClass.AddInstruction("WaitUntil;" + InstructionsAddWaitUntilSelectDateYear.Value + ";" + InstructionsAddWaitUntilSelectDateMonth.Value + ";" + InstructionsAddWaitUntilSelectDateDay.Value + ";" + InstructionsAddWaitUntilSelectTimeHour.Value + ";" + InstructionsAddWaitUntilSelectTimeMinute.Value + ";" + InstructionsAddWaitUntilSelectTimeSecond.Value);
        }

        private void InstructionsAddFadeColorsRedTrackBar_Scroll(object sender, EventArgs e)
        {
            InstructionsAddFadeColorsRedLabel.Text = InstructionsAddFadeColorsRedTrackBar.Value.ToString();
        }

        private void InstructionsAddFadeColorsGreenTrackBar_Scroll(object sender, EventArgs e)
        {
            InstructionsAddFadeColorsGreenLabel.Text = InstructionsAddFadeColorsGreenTrackBar.Value.ToString();
        }

        private void InstructionsAddFadeColorsBlueTrackBar_Scroll(object sender, EventArgs e)
        {
            InstructionsAddFadeColorsBlueLabel.Text = InstructionsAddFadeColorsBlueTrackBar.Value.ToString();
        }

        private void InstructionsAddIndividualLEDRedTrackBar_Scroll(object sender, EventArgs e)
        {
            InstructionsAddIndividualLEDRedValueLabel.Text = InstructionsAddIndividualLEDRedTrackBar.Value.ToString();
        }

        private void InstructionsAddIndividualLEDGreenTrackBar_Scroll(object sender, EventArgs e)
        {
            InstructionsAddIndividualLEDGreenValueLabel.Text = InstructionsAddIndividualLEDGreenTrackBar.Value.ToString();
        }

        private void InstructionsAddIndividualLEDBlueTrackBar_Scroll(object sender, EventArgs e)
        {
            InstructionsAddIndividualLEDBlueValueLabel.Text = InstructionsAddIndividualLEDBlueTrackBar.Value.ToString();
        }

        private void InstructionsAddVisualizerLoadSetup_Click(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\VisualizerSettings";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                Button SenderButton = sender as Button;
                SenderButton.Tag = LoadFileDialog.FileName.Split('\\')[LoadFileDialog.FileName.Split('\\').Length - 1];
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void InstructionsAddAmbilightUseAmbilightSettings_Click(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\AmbilightSettings";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                Button SenderButton = sender as Button;
                SenderButton.Tag = LoadFileDialog.FileName.Split('\\')[LoadFileDialog.FileName.Split('\\').Length - 1];
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }
        
        private void SaveInstructions(object sender, EventArgs e)
        {
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Instructions";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                InstructionsSectionClass.SaveInstructions();
            }
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void LoadInstructions(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Instructions";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                InstructionsSectionClass.LoadInstructions();
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void InstructionStopLoopButton_Click(object sender, EventArgs e)
        {
            if (InstructionsSectionClass.ContinueInstructionsLoop)
                if (InstructionsSectionClass.InstructionsRunning)
                    InstructionsSectionClass.StopInstructionsLoop = true;
        }

        #endregion

        #region Visualizer Section

        private void SmoothnessTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SmoothnessLabel.Text = SmoothnessTrackBar.Value.ToString();
        }

        private void SampleTimeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SampleTimeLabel.Text = SampleTimeTrackBar.Value.ToString();
        }

        private void SensitivityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SensitivityLabel.Text = SensitivityTrackBar.Value.ToString();
        }

        private void BeatZoneTriggerHeight_Scroll(object sender, EventArgs e)
        {
            FormatCustomText(BeatZoneTriggerHeight.Value, BeatZoneTriggerHeightLabel, "");
        }

        private void BeatZoneFromTrackBar_Scroll(object sender, EventArgs e)
        {
            if (BeatZoneFromTrackBar.Value < BeatZoneFromTrackBar.Value)
                BeatZoneFromTrackBar.Value = BeatZoneFromTrackBar.Value + 1;
            FormatCustomText(BeatZoneFromTrackBar.Value, BeatZoneFromLabel, "");
        }

        private void BeatZoneToTrackBar_Scroll(object sender, EventArgs e)
        {
            if (BeatZoneToTrackBar.Value < BeatZoneFromTrackBar.Value)
                BeatZoneToTrackBar.Value = BeatZoneFromTrackBar.Value + 1;

            FormatCustomText(BeatZoneToTrackBar.Value, BeatZoneToLabel, "");
        }

        private void TrackBarUpdateBASSKey(object sender, KeyEventArgs e)
        {
            if (UnitReady && VisualizerEnabled)
                VisualizerSectionClass.EnableBASS(true);
        }

        private void TrackBarUpdateBASSMouse(object sender, MouseEventArgs e)
        {
            if (UnitReady && VisualizerEnabled)
                VisualizerSectionClass.EnableBASS(true);
        }

        private void VisualSamplesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BeatZoneFromTrackBar.Maximum = (int)VisualSamplesNumericUpDown.Value;
            BeatZoneToTrackBar.Maximum = (int)VisualSamplesNumericUpDown.Value;
            VisualizerSectionClass.UpdateSpectrumChart(SpectrumChart, SpectrumRedTextBox.Text, SpectrumGreenTextBox.Text, SpectrumBlueTextBox.Text, (int)VisualSamplesNumericUpDown.Value, SpectrumAutoScaleValuesCheckBox.Checked);
            VisualizerSectionClass.UpdateSpectrumChart(WaveChart, WaveRedTextBox.Text, WaveGreenTextBox.Text, WaveBlueTextBox.Text, 255 * 3, WaveAutoScaleValuesCheckBox.Checked);
            BeatZoneChart.ChartAreas[0].AxisX.Minimum = 0;
            SpectrumChart.ChartAreas[0].AxisX.Minimum = 0;
            WaveChart.ChartAreas[0].AxisX.Minimum = 0;
            BeatZoneChart.ChartAreas[0].AxisX.Maximum = BeatZoneToTrackBar.Maximum;
            SpectrumChart.ChartAreas[0].AxisX.Maximum = BeatZoneToTrackBar.Maximum;
        }

        private void VisualizationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpectrumPanel.Enabled = false;
            WavePanel.Enabled = false;
            FullSpectrumPanel.Enabled = false;
            BeatWaveProgressBar.Value = 0;
            if (VisualizationTypeComboBox.SelectedIndex == 1 | VisualizationTypeComboBox.SelectedIndex == 2)
            {
                SpectrumPanel.Enabled = true;
            }
            if (VisualizationTypeComboBox.SelectedIndex == 3 | VisualizationTypeComboBox.SelectedIndex == 4)
            {
                WavePanel.Enabled = true;
            }
            if (VisualizationTypeComboBox.SelectedIndex == 5)
            {
                FullSpectrumPanel.Enabled = true;
            }

            if (UnitReady && VisualizerEnabled)
                VisualizerSectionClass.EnableBASS(true);
        }

        private void AudioSampleRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnitReady && VisualizerEnabled)
                VisualizerSectionClass.EnableBASS(true);
        }

        private void UpdateSpectrumButton_Click(object sender, EventArgs e)
        {
            if (SpectrumPanel.Enabled)
            {
                VisualizerSectionClass.UpdateSpectrumChart(SpectrumChart, SpectrumRedTextBox.Text, SpectrumGreenTextBox.Text, SpectrumBlueTextBox.Text, (int)VisualSamplesNumericUpDown.Value, SpectrumAutoScaleValuesCheckBox.Checked);
            }

            if (UnitReady && VisualizerEnabled)
                VisualizerSectionClass.EnableBASS(true);
        }

        private void UpdateWaveButton_Click(object sender, EventArgs e)
        {
            if (WavePanel.Enabled)
            {
                VisualizerSectionClass.UpdateSpectrumChart(WaveChart, WaveRedTextBox.Text, WaveGreenTextBox.Text, WaveBlueTextBox.Text, 255 * 3, WaveAutoScaleValuesCheckBox.Checked);
            }

            if (UnitReady && VisualizerEnabled)
                VisualizerSectionClass.EnableBASS(true);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            BeatZoneTriggerHeight.Enabled = !AutoTriggerCheckBox.Checked;
        }

        private void AudioSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AudioSourceComboBox.Visible)
                if (UnitReady && VisualizerEnabled)
                    VisualizerSectionClass.EnableBASS(true);
        }

        private void VisualizerSaveSettingsButton_Click(object sender, EventArgs e)
        {
            GetAllControls(VisualizerPanel);

            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\VisualizerSettings";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveSettings(SaveFileDialog.FileName, "");
            }
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void VisualizerLoadSettingsButton_Click(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\VisualizerSettings";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadSettings(LoadFileDialog.FileName);
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void VisualizerToSeriesIDNumericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (UnitReady && VisualizerEnabled)
            {
                VisualizerSectionClass.EnableBASS(false);
                string SerialOut = "6;" + VisualizerFromSeriesIDNumericUpDown.Value + ";" + VisualizerToSeriesIDNumericUpDown.Value;
                SendDataBySerial(SerialOut);
                VisualizerSectionClass.EnableBASS(true);
            }
        }

        #endregion

        #region Ambilight Section

        private void AmbiLightModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AmbiLightModeLeftPanel.Enabled = false;
            AmbiLightModeTopPanel.Enabled = false;
            AmbiLightModeRightPanel.Enabled = false;
            AmbiLightModeBottomPanel.Enabled = false;

            if (AmbiLightModeLeftCheckBox.Checked)
                AmbiLightModeLeftPanel.Enabled = true;

            if (AmbiLightModeTopCheckBox.Checked)
                AmbiLightModeTopPanel.Enabled = true;

            if (AmbiLightModeRightCheckBox.Checked)
                AmbiLightModeRightPanel.Enabled = true;

            if (AmbiLightModeBottomCheckBox.Checked)
                AmbiLightModeBottomPanel.Enabled = true;
        }

        public void LoadAAmbilightSetup(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\AmbilightSettings";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadSettings(LoadFileDialog.FileName);
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        public void SaveCurrentAmbilightSetup(object sender, EventArgs e)
        {
            GetAllControls(AmbiLightModePanel);

            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\AmbilightSettings";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveSettings(SaveFileDialog.FileName, "");
            }
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        public void AmbiLightModeShowHideBlocksButton_Click(object sender, EventArgs e)
        {
            AmbiLightSectionClass.SetSides();
            AmbiLightSectionClass.ShowBlocks(
                LeftSide, 
                TopSide, 
                RightSide, 
                BottomSide, 
                (int)AmbiLightModeScreenIDNumericUpDown.Value, 
                (int)AmbiLightModeBlockSampleSplitNumericUpDown.Value
                );
        }

        public void AmbiLightModeStartAmbilightButton_Click(object sender, EventArgs e)
        {
            AmbiLightSectionClass.SetSides();
            AmbiLightSectionClass.StartAmbilight(
                LeftSide, 
                TopSide, 
                RightSide,
                BottomSide, 
                (int)AmbiLightModeScreenIDNumericUpDown.Value, 
                (int)AmbiLightModeBlockSampleSplitNumericUpDown.Value, 
                (double)AmbiLightModeGammaFactorNumericUpDown.Value,
                (double)AmbiLightModeFadeFactorNumericUpDown.Value,
                (int)AmbiLightModeRefreshRateNumericUpDown.Value
                );
        }

        public void AmbiLightModeStopAmbilightButton_Click(object sender, EventArgs e)
        {
            AmbiLightSectionClass.StopAmbilight();
        }

        public void AmbiLightModeAutosetOffsets_Click(object sender, EventArgs e)
        {
            AmbiLightSectionClass.SetSides();
            AmbiLightSectionClass.AutoSetOffsets(
                LeftSide, 
                TopSide, 
                RightSide, 
                BottomSide, 
                (int)AmbiLightModeScreenIDNumericUpDown.Value, 
                (int)AmbiLightModeBlockSampleSplitNumericUpDown.Value
                );
        }

        #endregion

        #region Animation Mode Section

        private void AnimationModeAddALineButton_Click(object sender, EventArgs e)
        {
            string SendData = "";
            for (int i = 0; i < AnimationModeLineSpacingNumericUpDown.Value; i++)
                SendData += "0.0.0;";
            AnimationModeSectionClass.AddLine(SendData);
        }

        private async void AnimationModeStartButton_Click(object sender, EventArgs e)
        {
            if (!AnimationModeSectionClass.AnimationRunning)
            {
                AnimationModeSectionClass.MoveInterval = (int)AnimationModeMoveIntervalNumericUpDown.Value;
                AnimationModeSectionClass.ContinueAnimationLoop = true;
                await AnimationModeSectionClass.RunAnimation();
            }
        }

        private void AnimationModeStopButton_Click(object sender, EventArgs e)
        {
            if (AnimationModeSectionClass.ContinueAnimationLoop)
                if (AnimationModeSectionClass.AnimationRunning)
                    AnimationModeSectionClass.StopAnimationLoop = true;
        }

        private void AnimationModeSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Animations";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AnimationModeSectionClass.SaveAnimation();
            }
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void AnimationModeLoadButton_Click(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Animations";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                AnimationModeSectionClass.LoadAnimation();
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void AnimationModeRedTrackbar_Scroll(object sender, EventArgs e)
        {
            AnimationModeRedTrackbarLabel.Text = AnimationModeRedTrackbar.Value.ToString();
        }

        private void AnimationModeGreenTrackbar_Scroll(object sender, EventArgs e)
        {
            AnimationModeGreenTrackbarLabel.Text = AnimationModeGreenTrackbar.Value.ToString();
        }

        private void AnimationModeBlueTrackbar_Scroll(object sender, EventArgs e)
        {
            AnimationModeBlueTrackbarLabel.Text = AnimationModeBlueTrackbar.Value.ToString();
        }

        private void AnimationModeClearButton_Click(object sender, EventArgs e)
        {
            AnimationModeSectionClass.AnimationList.Clear();
            Panel WorkingPanel = (Panel)AnimationModePanel.Controls.Find("AnimationModeAnimationWindowWorkingPanel", true)[0];
            WorkingPanel.Controls.Clear();
            AnimationModeLineSpacingNumericUpDown.Enabled = true;
        }

        private void AnimationModeColorEntireLineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AnimationModeSectionClass.ColorEntireLine = AnimationModeColorEntireLineCheckBox.Checked;
        }

        #endregion

        #region Server Section

        public void ServerSettingsStartServerButton_Click(object sender, EventArgs e)
        {
            ServerAPISectionClass.InitializeServer();
        }

        public void ServerSettingsStopServerButton_Click(object sender, EventArgs e)
        {
            ServerAPISectionClass.StopServer();
        }

        public void ServerSettingsClearConsoleButton_Click(object sender, EventArgs e)
        {
            ServerSettingsConsoleTextBox.Text = "";
        }

        #endregion
    }
}