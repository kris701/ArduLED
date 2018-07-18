using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Threading;
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace ArduLEDNameSpace
{
    public partial class MainForm : Form
    {
        #region Variabels

        const int ButtonWidth = 20;
        const int ButtonHeight = 15;
        const int BoxHeight = 45;
        const int Margins = 5;
        const int ScroolBarWidth = 25;
        const int Sizex = 1411;
        const int Sizey = 775;
        const int TransferDelay = 25;

        List<string> IntructionsList = new List<string>();
        bool ContinueInstructionsLoop = false;
        bool StopInstructionsLoop = false;
        bool InstructionsRunning = false;
        bool ShowLoadingScreen = true;
        bool UnitReady = false;
        List<List<int>> AudioDataPointStore = new List<List<int>>();
        DispatcherTimer AudioDataTimer;
        float[] AudioData;
        WASAPIPROC BassProcess;
        Series BeatZoneSeries;
        bool BassFirst;
        List<Control> ControlList = new List<Control>();
        Loading LoadingForm;
        Point DragStart = new Point(0,0);

        #endregion

        #region Loading Section

        public MainForm()
        {
            InitializeComponent();
        }

        public async void Form1_Load(object sender, EventArgs e)
        {
            LoadingScreen();

            while (LoadingForm == null) { }
            while (!LoadingForm.Visible) { }

            SerialPort1.Encoding = System.Text.Encoding.ASCII;
            SerialPort1.NewLine = "\n";

            SetLoadingLabelTo("BASS.NET");

            InitializeBass();

            SetLoadingLabelTo("Instructions folder");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Instructions"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Instructions");
            }

            SetLoadingLabelTo("Setup folder");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Setups"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Setups");
            }

            SetLoadingLabelTo("Language Packs");

            if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Languages").Length > 0)
            {
                foreach (string f in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Languages"))
                {
                    LanguageComboBox.Items.Add(f.Substring(f.Length - 6, 2));
                }
            }
            else
                MessageBox.Show("No language packs found! Using default preset");

            SetLoadingLabelTo("Visuals");

            MaximumSize = new Size(Sizex, Sizey);
            MinimumSize = new Size(Sizex, Sizey);
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Sizex, 0);

            SetLoadingLabelTo("Save/Load Mechanisms");

            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            SetLoadingLabelTo("Charts");

            BeatZoneChart.ChartAreas[0].AxisY.Maximum = 255;
            SpectrumChart.ChartAreas[0].AxisY.Maximum = 255;
            WaveChart.ChartAreas[0].AxisY.Maximum = 255;
            BeatZoneChart.ChartAreas[0].AxisY.Minimum = 0;
            SpectrumChart.ChartAreas[0].AxisY.Minimum = 0;
            WaveChart.ChartAreas[0].AxisY.Minimum = 0;

            SetLoadingLabelTo("Presetting Combobox indexes");

            ModeSelectrionComboBox.Items.Add(" ");
            ModeSelectrionComboBox.Items.Add(" ");
            ModeSelectrionComboBox.Items.Add(" ");
            ModeSelectrionComboBox.Items.Add(" ");
            ModeSelectrionComboBox.Items.Add(" ");
            VisualizationTypeComboBox.Items.Add(" ");
            VisualizationTypeComboBox.Items.Add(" ");
            VisualizationTypeComboBox.Items.Add(" ");
            VisualizationTypeComboBox.Items.Add(" ");
            VisualizationTypeComboBox.Items.Add(" ");
            PixelTypeComboBox.Items.Add(" ");
            PixelTypeComboBox.Items.Add(" ");
            PixelBitstreamComboBox.Items.Add(" ");
            PixelBitstreamComboBox.Items.Add(" ");

            SetLoadingLabelTo("Indexing Comboboxes");

            AudioSourceComboBox.SelectedIndex = 0;
            VisualizationTypeComboBox.SelectedIndex = 0;
            AudioSampleRateComboBox.SelectedIndex = 6;
            PixelTypeComboBox.SelectedIndex = 0;
            PixelBitstreamComboBox.SelectedIndex = 0;

            SetLoadingLabelTo("Last Setup");

            AutoloadLastSetup();

            SetLoadingLabelTo("Last instructions");

            AutoloadLastInstructions();

            SetLoadingLabelTo("Default language pack");

            if (LanguageComboBox.Items.Contains("EN"))
                LanguageComboBox.SelectedIndex = LanguageComboBox.FindString("EN");
            else
                LanguageComboBox.SelectedIndex = 0;

            SetLoadingLabelTo("Previus settings");

            AutoLoadAllSettings();

            SetLoadingLabelTo("Updating Charts");

            UpdateSpectrumChart(SpectrumChart, SpectrumRedTextBox.Text, SpectrumGreenTextBox.Text, SpectrumBlueTextBox.Text, (int)VisualSamplesNumericUpDown.Value, SpectrumAutoScaleValuesCheckBox.Checked);
            UpdateSpectrumChart(WaveChart, WaveRedTextBox.Text, WaveGreenTextBox.Text, WaveBlueTextBox.Text, 255 * 3, WaveAutoScaleValuesCheckBox.Checked);

            SetLoadingLabelTo("Formating label values");

            SensitivityLabel.Text = SensitivityTrackBar.Value.ToString();
            SmoothnessLabel.Text = SmoothnessTrackBar.Value.ToString();
            SampleTimeLabel.Text = SampleTimeTrackBar.Value.ToString();

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

            SetLoadingLabelTo("Complete!");

            ShowLoadingScreen = false;
            for (double i = 0; i <= 100; i += 2)
            {
                Opacity = i / 100;
                await Task.Delay(10);
            }
            if (ConfigureSetupAutoSendCheckBox.Checked)
            {
                if (ComPortsComboBox.Items.Count > 0)
                {
                    ConfigureSetupAutoSendCheckBox.Enabled = false;
                    ConfigureSetupHiddenProgressBar.Visible = true;
                    for (int i = Width; i > Width - MenuButton.Width; i--)
                    {
                        ConfigureSetupHiddenProgressBar.Location = new Point(i, 0);
                        await Task.Delay(5);
                    }
                    ConnectToComDevice();
                }
                else
                    MessageBox.Show("Error, saved COM port not found!");
            }
        }

        public void LoadingScreen()
        {
            Task.Run(() =>
            {
                LoadingForm = new Loading();
                LoadingForm.Show();
                for (double i = 0; i <= 100; i += 2)
                {
                    LoadingForm.Opacity = i / 100;
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                while (ShowLoadingScreen) { Application.DoEvents(); Thread.Sleep(10); }
                for (double i = 100; i >= 0; i -= 4)
                {
                    LoadingForm.Opacity = i / 100;
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                LoadingForm.Dispose();
                LoadingForm.Dispose();
            });
        }

        void SetLoadingLabelTo(string _Input)
        {
            LoadingForm.LoadingScreenLabel.Invoke((MethodInvoker)delegate { LoadingForm.LoadingScreenLabel.Text = "Loading: " + _Input; });
        }

        private void InitializeBass()
        {
            AudioSourceComboBox.Items.Clear();
            for (int i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
            {
                var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                if (device.IsEnabled && device.IsLoopback)
                {
                    AudioSourceComboBox.Items.Add(string.Format("{0} - {1}", i, device.name));
                }
            }

            foreach (string s in SerialPort.GetPortNames())
            {
                ComPortsComboBox.Items.Add(s);
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            UnitReady = true;
            SerialPort1.ReadExisting();
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Languages\\" + LanguageComboBox.SelectedItem + ".txt");
            for (int i = 0; i < Lines.Length; i++)
            {
                try
                {
                    string[] Split = Lines[i].Split(';');
                    if (Split[0] != "")
                    {
                        if (Split[0].ToUpper() == "INDEXNAMES")
                        {
                            Control[] ControlText = Controls.Find(Split[1], true);
                            if (ControlText.Length > 0)
                            {
                                foreach (Control c in ControlText)
                                {
                                    ComboBox ChangeIndexNameComboBox = c as ComboBox;
                                    for (int j = 2; j < Split.Length; j++)
                                    {
                                        ChangeIndexNameComboBox.Items[j - 2] = Split[j];
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Control: " + Split[1] + " Was not found! ( Line: " + i + " )");
                        }
                        else
                        {
                            if (Split[0].ToUpper() == "POSSIBLE")
                            {
                                Control[] ControlText = Controls.Find(Split[0], true);
                                if (ControlText.Length > 0)
                                {
                                    foreach (Control c in ControlText)
                                    {
                                        c.Font = new Font(Split[1], Int32.Parse(Split[2]));
                                        if (Split[3] != "")
                                            c.Text = Split[3];
                                    }
                                }
                            }
                            else
                            {
                                Control[] ControlText = Controls.Find(Split[0], true);
                                if (ControlText.Length > 0)
                                {
                                    foreach (Control c in ControlText)
                                    {
                                        c.Font = new Font(Split[1], Int32.Parse(Split[2]));
                                        if (Split[3] != "")
                                            c.Text = Split[3];
                                    }
                                }
                                else
                                    MessageBox.Show("Control: " + Split[0] + " Was not found! ( Line: " + i + " )");
                            }
                        }
                    }
                }
                catch {  }
            }
            SensitivityLabel.Text = SensitivityTrackBar.Value.ToString();
            SmoothnessLabel.Text = SmoothnessTrackBar.Value.ToString();
            SampleTimeLabel.Text = SampleTimeTrackBar.Value.ToString();

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
        }

        void AutoLoadAllSettings()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\cfg.txt"))
            {
                string[] Lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\cfg.txt", System.Text.Encoding.UTF8);
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
            }
        }

        void AutoSaveAllSettings()
        {
            GetAllControls(this);


            if (File.Exists(Directory.GetCurrentDirectory() + "\\cfg.txt"))
                File.Delete(Directory.GetCurrentDirectory() + "\\cfg.txt");

            using (StreamWriter SaveFile = File.CreateText(Directory.GetCurrentDirectory() + "\\cfg.txt"))
            {
                string SerialOut = "SERIALPORT;" + SerialPort1.BaudRate;
                SaveFile.WriteLine(SerialOut);
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
        }

        void GetAllControls(Control _InputControl)
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
            AutoSaveAllSettings();
        }

        private void ResetToDefaultPosition(object sender, EventArgs e)
        {
            Size = new Size(Sizex, Sizey);
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Sizex, 0);
        }

        void SendDataBySerial(string _Input)
        {
            try
            {
                SerialPort1.WriteLine(_Input);
            }
            catch { }
        }

        #endregion

        #region Menu Section

        private void Connect(object sender, EventArgs e)
        {
            ConnectToComDevice();
        }

        async void ConnectToComDevice()
        {
            try
            {
                if (SerialPort1.IsOpen)
                    SerialPort1.Close();
                SerialPort1.PortName = ComPortsComboBox.Text;
                SerialPort1.Open();
                UnitReady = false;
            }
            catch { }

            if (SerialPort1.IsOpen)
            {
                int DelayCount = 0;
                bool NoError = true;
                while (!UnitReady)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                    DelayCount++;
                    if (DelayCount >= 100)
                    {
                        if (ConfigureSetupAutoSendCheckBox.Checked)
                            ConfigureSetupHiddenProgressBar.Visible = false;
                        MessageBox.Show("Error, unit timed out!");
                        NoError = false;
                        break;
                    }
                }
                if (NoError)
                {
                    ModeSelectrionComboBox.Enabled = true;
                    if (!ConfigureSetupAutoSendCheckBox.Checked)
                        ModeSelectrionComboBox.SelectedIndex = 4;
                    else
                        await SendSetup();
                }
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            if (MenuPanel.Visible)
            {
                MenuPanel.Visible = false;
                IndividualLEDPanel.Visible = false;
                VisualizerPanel.Visible = false;
                ConfigureSetupPanel.Visible = false;
                InstructionsPanel.Visible = false;
                AutoSaveAllSettings();
            }
            else
                MenuPanel.Visible = true;
        }

        private void ModeSelectrionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FadeLEDPanel.Enabled = false;
            VisualizerPanel.Visible = false;
            IndividualLEDPanel.Visible = false;
            InstructionsPanel.Visible = false;
            ConfigureSetupPanel.Visible = false;
            EnableBASS(false);

            if (ModeSelectrionComboBox.SelectedIndex == 0)
            {
                FadeLEDPanel.Enabled = true;
                FadeLEDPanel.BringToFront();
                if (!ContinueInstructionsLoop)
                    FadeColorsSendData(true);
            }
            if (ModeSelectrionComboBox.SelectedIndex == 1)
            {
                VisualizerPanel.Visible = true;
                VisualizerPanel.BringToFront();
                if (!ContinueInstructionsLoop)
                    EnableBASS(true);
            }
            if (ModeSelectrionComboBox.SelectedIndex == 2)
            {
                IndividualLEDPanel.Visible = true;
                IndividualLEDPanel.BringToFront();
                if (!ContinueInstructionsLoop)
                    FadeColorsSendData(true);
            }
            if (ModeSelectrionComboBox.SelectedIndex == 3)
            {
                InstructionsPanel.Visible = true;
                InstructionsPanel.BringToFront();
                if (!ContinueInstructionsLoop)
                    FadeColorsSendData(true);
            }
            if (ModeSelectrionComboBox.SelectedIndex == 4)
            {
                ConfigureSetupPanel.Visible = true;
                ConfigureSetupPanel.BringToFront();
            }
        }

        private void MenuExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            FadeColorsSendData(false);
        }

        void FadeColorsSendData(bool _FromZero)
        {
            if (SerialPort1.IsOpen)
            {
                string SerialOut;
                if (_FromZero)
                {
                    SerialOut = "F;0;-1;0;0;0;0;0;E";
                    SendDataBySerial(SerialOut);
                    Thread.Sleep(10);
                }
                SerialOut = "F;0;-1;" + FadeColorsRedTrackBar.Value + ";" + FadeColorsGreenTrackBar.Value + ";" + FadeColorsBlueTrackBar.Value + ";" + FadeColorsFadeSpeedNumericUpDown.Value + ";" + Math.Round(FadeColorsFadeFactorNumericUpDown.Value * 100, 0) + ";E";
                SendDataBySerial(SerialOut);
            }
        }

        #endregion

        #region Configure Setup Section

        private void AddLEDStrip(object sender, EventArgs e)
        {
            MakeLEDStrip(0, 0, (int)ConfigureSetupAddStripFromLEDID.Value, ConfigureSetupAddStripInvertX.Checked, ConfigureSetupAddStripInvertY.Checked, (int)ConfigureSetupAddStripXDir.Value, (int)ConfigureSetupAddStripYDir.Value, (int)ConfigureSetupAddStripPinID.Value, "", false, PixelTypeComboBox.SelectedIndex, PixelBitstreamComboBox.SelectedIndex);
        }

        void MakeLEDStrip(int _XLocation, int _YLocation, int _FromLEDID, bool _InvertXDir, bool _InvertYDir, int _XLEDAmount, int _YLEDAmount, int _PinID, string _IndputTextData, bool _IsIndividualLEDs, int _PixelTypeIndex, int _PixelBitstreamIndex)
        {
            int CurrentLED = _FromLEDID;
            Panel BackPanel = new Panel();
            BackPanel.BorderStyle = BorderStyle.FixedSingle;
            BackPanel.Width = (int)(_XLEDAmount * ButtonWidth + Margins) + Margins * 2;
            BackPanel.Height = (int)(_YLEDAmount * (2 * ButtonHeight) + Margins) + Margins * 2 + ButtonHeight;
            BackPanel.Location = new Point(_XLocation, _YLocation);
            if (_IsIndividualLEDs)
                BackPanel.Font = new Font(IndividualLEDWorkingPanel.Font.FontFamily, BackPanel.Font.Size);
            else
                BackPanel.Font = new Font(ConfigureSetupWorkingPanel.Font.FontFamily, BackPanel.Font.Size);
            BackPanel.BackColor = Color.Gray;
            if (!_IsIndividualLEDs)
            {
                BackPanel.MouseMove += MoveLEDStrip;
                BackPanel.MouseDown += MoveLEDStripDown;
                BackPanel.MouseUp += MoveLEDStripUp;
            }

            Button DeleteButton = new Button();
            DeleteButton.Width = ButtonWidth;
            DeleteButton.Height = ButtonHeight;
            DeleteButton.Text = "X";
            DeleteButton.Parent = BackPanel;
            DeleteButton.Click += RemoveLEDStrip;
            DeleteButton.Font = new Font(BackPanel.Font.FontFamily, 7);
            DeleteButton.Location = new Point(0, Margins);
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.BackColor = Color.DarkGray;
            DeleteButton.Name = "MakeLEDPanelDeleteButton";
            BackPanel.Controls.Add(DeleteButton);

            Label StripIDLabel = new Label();
            StripIDLabel.Height = ButtonHeight;
            StripIDLabel.Font = new Font(BackPanel.Font.FontFamily, 7);
            StripIDLabel.Tag = _PinID;
            StripIDLabel.Text = _PinID.ToString();
            StripIDLabel.Location = new Point(StripIDLabel.Location.X + ButtonWidth, Margins);
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
                        TextBox NewButton = new TextBox();
                        NewButton.Width = ButtonWidth;
                        NewButton.Height = ButtonHeight;
                        NewButton.Text = CurrentLED.ToString();
                        NewButton.Font = new Font(BackPanel.Font.FontFamily, 7);
                        NewButton.Enabled = false;
                        NewButton.TextAlign = HorizontalAlignment.Center;
                        NewButton.BorderStyle = BorderStyle.None;
                        NewButton.BackColor = Color.DarkGray;
                        NewButton.ForeColor = Color.White;
                        NewButton.Name = "MakeLEDPanelStripLEDIDLabel";
                        if (_InvertXDir)
                        {
                            if (_InvertYDir)
                                NewButton.Location = new Point(Margins + ButtonWidth * ((_XLEDAmount - 1) - i), Margins + (ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (Margins + ButtonHeight));
                            else
                                NewButton.Location = new Point(Margins + ButtonWidth * ((_XLEDAmount - 1) - i), Margins + (ButtonHeight * 2) * j + (Margins + ButtonHeight));
                        }
                        else
                        {
                            if (_InvertYDir)
                                NewButton.Location = new Point(Margins + ButtonWidth * i, Margins + (ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (Margins + ButtonHeight));
                            else
                                NewButton.Location = new Point(Margins + ButtonWidth * i, Margins + (ButtonHeight * 2) * j + (Margins + ButtonHeight));
                        }

                        TextBox NewTextBox = new TextBox();
                        NewTextBox.Width = ButtonWidth;
                        NewTextBox.Height = ButtonHeight;
                        NewTextBox.Click += ClickToSetSeries;
                        if (UseDefaultText)
                        {
                            NewTextBox.Text = "0";
                        }
                        else
                        {
                            NewTextBox.Text = InputTextDataSplit[BoxNumber];
                        }
                        NewTextBox.Font = new Font(BackPanel.Font.FontFamily, 7);
                        NewTextBox.TextChanged += FormatText;
                        NewTextBox.Location = new Point(NewButton.Location.X, NewButton.Location.Y + ButtonHeight);
                        NewTextBox.Parent = BackPanel;
                        NewTextBox.BorderStyle = BorderStyle.None;
                        NewTextBox.BackColor = Color.DarkGray;
                        NewTextBox.ForeColor = Color.White;
                        NewTextBox.Name = "MakeLEDPanelStripSeriesIDLabel";

                        BackPanel.Controls.Add(NewButton);
                        BackPanel.Controls.Add(NewTextBox);
                    }
                    else
                    {
                        Button NewButton = new Button();
                        NewButton.Width = ButtonWidth;
                        NewButton.Height = ButtonHeight;
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
                                NewButton.Location = new Point(Margins + ButtonWidth * ((_XLEDAmount - 1) - i), Margins + (ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (Margins + ButtonHeight));
                            else
                                NewButton.Location = new Point(Margins + ButtonWidth * ((_XLEDAmount - 1) - i), Margins + (ButtonHeight * 2) * j + (Margins + ButtonHeight));
                        }
                        else
                        {
                            if (_InvertYDir)
                                NewButton.Location = new Point(Margins + ButtonWidth * i, Margins + (ButtonHeight * 2) * ((_YLEDAmount - 1) - j) + (Margins + ButtonHeight));
                            else
                                NewButton.Location = new Point(Margins + ButtonWidth * i, Margins + (ButtonHeight * 2) * j + (Margins + ButtonHeight));
                        }

                        NewButton.Click += ColorSingleLED;
                        BackPanel.Controls.Add(NewButton);
                    }


                    CurrentLED++;
                    BoxNumber++;
                }
            }

            Point3D[] TagData = { new Point3D(0, 0, 0), new Point3D(_XLEDAmount, _YLEDAmount, _PinID), new Point3D(Convert.ToInt32(_InvertXDir), Convert.ToInt32(_InvertYDir), _FromLEDID), new Point3D(_PixelTypeIndex, _PixelBitstreamIndex, 0) };
            BackPanel.Tag = TagData;

            if (_IsIndividualLEDs)
                IndividualLEDWorkingPanel.Controls.Add(BackPanel);
            else
                ConfigureSetupWorkingPanel.Controls.Add(BackPanel);
        }

        private void FormatText(object sender, EventArgs e)
        {
            TextBox SenderTextBox = sender as TextBox;
            if (!IsDigitsOnly(SenderTextBox.Text))
                if (SenderTextBox.Text.Length > 0)
                {
                    SenderTextBox.Text = SenderTextBox.Text.Substring(0, SenderTextBox.Text.Length - 1);
                    SenderTextBox.SelectionStart = SenderTextBox.Text.Length;
                    SenderTextBox.SelectionLength = 0;
                }
        }

        bool IsDigitsOnly(string _Input)
        {
            foreach (char c in _Input)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void ClickToSetSeries(object sender, EventArgs e)
        {
            if (ConfigureSetupClickToSetupSeriesCheckBox.Checked)
            {
                TextBox SenderTextBox = sender as TextBox;
                SenderTextBox.Text = ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value.ToString();
                ConfigureSetupClickToSetupSeriesFromIDNumericUpDown.Value++;
            }
        }

        private void MoveLEDStrip(object sender, MouseEventArgs e)
        {
            Panel SenderPanel = sender as Panel;
            Point3D[] MomentaryDataTag = (Point3D[])SenderPanel.Tag;
            if (MomentaryDataTag[0].Z == 1)
            {
                SenderPanel.Location = new Point((int)MomentaryDataTag[0].X + (MousePosition.X - DragStart.X), (int)MomentaryDataTag[0].Y + (MousePosition.Y - DragStart.Y));
            }
        }

        private void MoveLEDStripDown(object sender, MouseEventArgs e)
        {
            DragStart = MousePosition;
            Panel SenderPanel = sender as Panel;
            foreach (Control InnerControl in SenderPanel.Parent.Controls)
            {
                foreach (Control InnerInnerControl in InnerControl.Controls)
                {
                    InnerInnerControl.Visible = false;
                }
            }
            Point3D[] MomentaryDataTag = (Point3D[])SenderPanel.Tag;
            MomentaryDataTag[0] = new Point3D(SenderPanel.Location.X, SenderPanel.Location.Y, 1);
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
            Point3D[] MomentaryDataTag = (Point3D[])SenderPanel.Tag;
            MomentaryDataTag[0] = new Point3D(SenderPanel.Location.X, SenderPanel.Location.Y, 0);
            SenderPanel.Tag = MomentaryDataTag;
        }

        private void RemoveLEDStrip(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            SenderButton.Parent.Dispose();
        }

        private void SaveSetup(object sender, EventArgs e)
        {
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Setups";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCurrentSetup();
            }
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        void SaveCurrentSetup()
        {
            using (StreamWriter SaveFile = new StreamWriter(SaveFileDialog.FileName, false))
            {
                using (StreamWriter AutoSaveFile = new StreamWriter(Directory.GetCurrentDirectory() + "\\Setups\\0.txt", false))
                {
                    foreach (Control c in ConfigureSetupWorkingPanel.Controls)
                    {
                        Point3D[] MomentaryDataTag = (Point3D[])c.Tag;
                        string SerialOut = c.Location.X + ";" + c.Location.Y + ";" + MomentaryDataTag[2].Z + ";" + Convert.ToBoolean(MomentaryDataTag[2].X) + ";" + Convert.ToBoolean(MomentaryDataTag[2].Y) + ";" + MomentaryDataTag[1].X + ";" + MomentaryDataTag[1].Y + ";" + MomentaryDataTag[1].Z + ";" + MomentaryDataTag[3].X + ";" + MomentaryDataTag[3].Y;
                        SaveFile.WriteLine(SerialOut);
                        AutoSaveFile.WriteLine(SerialOut);

                        SerialOut = "";
                        for (int j = 0; j < c.Controls.Count; j++)
                        {
                            if (c.Controls[j].Name == "MakeLEDPanelStripSeriesIDLabel")
                            {
                                SerialOut += c.Controls[j].Text + ";";
                            }
                        }

                        SaveFile.WriteLine(SerialOut);
                        AutoSaveFile.WriteLine(SerialOut);
                    }
                }
            }
        }

        void AutoloadLastSetup()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Setups\\0.txt"))
            {
                while (ConfigureSetupWorkingPanel.Controls.Count > 0)
                    ConfigureSetupWorkingPanel.Controls[0].Dispose();
                while (IndividualLEDWorkingPanel.Controls.Count > 0)
                    IndividualLEDWorkingPanel.Controls[0].Dispose();

                string[] Lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Setups\\0.txt", System.Text.Encoding.UTF8);
                for (int i = 0; i < Lines.Length; i++)
                {
                    string[] Split = Lines[i].Split(';');
                    MakeLEDStrip(Int32.Parse(Split[0]), Int32.Parse(Split[1]), Int32.Parse(Split[2]), Boolean.Parse(Split[3]), Boolean.Parse(Split[4]), Int32.Parse(Split[5]), Int32.Parse(Split[6]), Int32.Parse(Split[7]), Lines[i + 1], false, Int32.Parse(Split[8]), Int32.Parse(Split[9]));
                    MakeLEDStrip(Int32.Parse(Split[0]), Int32.Parse(Split[1]), Int32.Parse(Split[2]), Boolean.Parse(Split[3]), Boolean.Parse(Split[4]), Int32.Parse(Split[5]), Int32.Parse(Split[6]), Int32.Parse(Split[7]), Lines[i + 1], true, Int32.Parse(Split[8]), Int32.Parse(Split[9]));
                    i++;
                }
            }
        }

        private void LoadSetup(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Setups";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                while (ConfigureSetupWorkingPanel.Controls.Count > 0)
                    ConfigureSetupWorkingPanel.Controls[0].Dispose();
                while (IndividualLEDWorkingPanel.Controls.Count > 0)
                    IndividualLEDWorkingPanel.Controls[0].Dispose();

                string[] Lines = File.ReadAllLines(LoadFileDialog.FileName, System.Text.Encoding.UTF8);
                for (int i = 0; i < Lines.Length; i++)
                {
                    string[] Split = Lines[i].Split(';');
                    MakeLEDStrip(Int32.Parse(Split[0]), Int32.Parse(Split[1]), Int32.Parse(Split[2]), Boolean.Parse(Split[3]), Boolean.Parse(Split[4]), Int32.Parse(Split[5]), Int32.Parse(Split[6]), Int32.Parse(Split[7]), Lines[i + 1], false, Int32.Parse(Split[8]), Int32.Parse(Split[9]));
                    MakeLEDStrip(Int32.Parse(Split[0]), Int32.Parse(Split[1]), Int32.Parse(Split[2]), Boolean.Parse(Split[3]), Boolean.Parse(Split[4]), Int32.Parse(Split[5]), Int32.Parse(Split[6]), Int32.Parse(Split[7]), Lines[i + 1], true, Int32.Parse(Split[8]), Int32.Parse(Split[9]));
                    i++;
                }
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private async void SendSetupButton_Click(object sender, EventArgs e)
        {
            await SendSetup();
        }

        public async Task SendSetup()
        {
            await Task.Run(async () =>
            {
                List<int> Pins = new List<int>();
                List<int> LEDCount = new List<int>();
                List<int> PixelTypesIndexs = new List<int>();
                List<int> PixelBitrateIndexs = new List<int>();

                foreach (Control c in ConfigureSetupWorkingPanel.Controls)
                {
                    Point3D[] MomentaryDataTag = (Point3D[])c.Tag;
                    if (!Pins.Contains((int)MomentaryDataTag[1].Z))
                    {
                        Pins.Add((int)MomentaryDataTag[1].Z);
                        LEDCount.Add(((int)MomentaryDataTag[1].X * (int)MomentaryDataTag[1].Y));
                        PixelTypesIndexs.Add((int)MomentaryDataTag[3].X);
                        PixelBitrateIndexs.Add((int)MomentaryDataTag[3].Y);
                    }
                    else
                    {
                        int Index = Pins.FindIndex(x => x == (int)MomentaryDataTag[1].Z);
                        LEDCount[Index] += ((int)MomentaryDataTag[1].X * (int)MomentaryDataTag[1].Y);
                    }
                }

                for (int i = 0; i < Pins.Count; i++)
                {
                    string SerialOut = "D;" + LEDCount[i] + ";" + Pins[i] + ";" + PixelTypesIndexs[i] + ";" + PixelBitrateIndexs[i] + ";E";
                    SendDataBySerial(SerialOut);
                    await Task.Delay(TransferDelay);
                }

                SendDataBySerial("D;9999;E");
                await Task.Delay(TransferDelay * 2);

                int TotalLEDs = 0;
                foreach (int i in LEDCount)
                    TotalLEDs += i;

                SendSetupProgressBar.Invoke((MethodInvoker)delegate { SendSetupProgressBar.Maximum = TotalLEDs; });
                if (ConfigureSetupAutoSendCheckBox.Checked)
                    ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { ConfigureSetupHiddenProgressBar.Maximum = TotalLEDs; });

                for (int i = 0; i < TotalLEDs; i++)
                {
                    SendSetupProgressBar.Invoke((MethodInvoker)delegate { SendSetupProgressBar.Value = i; });
                    if (ConfigureSetupAutoSendCheckBox.Checked)
                        ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { ConfigureSetupHiddenProgressBar.Value = i; });
                    foreach (Control c in ConfigureSetupWorkingPanel.Controls)
                    {
                        for (int j = 0; j < c.Controls.Count; j++)
                        {
                            if (c.Controls[j] is TextBox)
                            {
                                if (c.Controls[j].Enabled)
                                {
                                    TextBox LEDTextBox = c.Controls[j] as TextBox;
                                    if (c.Controls[j].Text == i.ToString())
                                    {
                                        Point3D[] MomentaryDataTag = (Point3D[])c.Controls[j].Parent.Tag;
                                        string SerialOut = "D;" + c.Controls[j - 1].Text + ";" + MomentaryDataTag[1].Z + ";E";
                                        SendDataBySerial(SerialOut);
                                        await Task.Delay(TransferDelay);
                                    }
                                }
                            }
                        }
                    }
                }

                SendSetupProgressBar.Invoke((MethodInvoker)delegate { SendSetupProgressBar.Value = 0; });
                if (ConfigureSetupAutoSendCheckBox.Checked)
                {
                    for (int i = Width - MenuButton.Width; i < Width; i++)
                    {
                        ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { ConfigureSetupHiddenProgressBar.Location = new Point(i, 0); });
                        await Task.Delay(5);
                    }
                    ConfigureSetupHiddenProgressBar.Invoke((MethodInvoker)delegate { ConfigureSetupHiddenProgressBar.Visible = false; });
                    ConfigureSetupAutoSendCheckBox.Invoke((MethodInvoker)delegate { ConfigureSetupAutoSendCheckBox.Enabled = true; });
                }

                SendDataBySerial("D;9999;E");

                if (!ConfigureSetupAutoSendCheckBox.Checked)
                    ModeSelectrionComboBox.Invoke((MethodInvoker)delegate { ModeSelectrionComboBox.SelectedIndex = 0; });
            });
        }

        #endregion

        #region Individual LED Section

        private async void ColorSingleLED(object sender, EventArgs e)
        {
            Button SenderButton = sender as Button;
            if (ColorEntireLEDStripCheckBox.Checked)
            {
                await ColorEntireLEDStrip(SenderButton);
            }
            else
            {
                Point3D[] MomentaryDataTag = (Point3D[])SenderButton.Parent.Tag;
                SenderButton.BackColor = Color.FromArgb(IndividalLEDRedTrackBar.Value, IndividalLEDGreenTrackBar.Value, IndividalLEDBlueTrackBar.Value);
                string SerialOut = "I;" + MomentaryDataTag[1].Z + ";" + SenderButton.Text + ";" + IndividalLEDRedTrackBar.Value.ToString() + ";" + IndividalLEDGreenTrackBar.Value.ToString() + ";" + IndividalLEDBlueTrackBar.Value.ToString() + ";E";
                SendDataBySerial(SerialOut);
            }
        }

        public async Task ColorEntireLEDStrip(Button SenderButton)
        {
            await Task.Run(async () =>
            {
                foreach (Control c in SenderButton.Parent.Controls)
                {
                    if (c is Button)
                    {
                        Button Button = c as Button;
                        if (Button.Text != "X")
                        {
                            IndividalLEDRedTrackBar.Invoke((MethodInvoker)delegate {
                                IndividalLEDGreenTrackBar.Invoke((MethodInvoker)delegate {
                                    IndividalLEDBlueTrackBar.Invoke((MethodInvoker)delegate {
                                        Point3D[] MomentaryDataTag = (Point3D[])Button.Parent.Tag;
                                        Button.BackColor = Color.FromArgb(IndividalLEDRedTrackBar.Value, IndividalLEDGreenTrackBar.Value, IndividalLEDBlueTrackBar.Value);
                                        string SerialOut = "I;" + MomentaryDataTag[1].Z + ";" + Button.Text + ";" + IndividalLEDRedTrackBar.Value.ToString() + ";" + IndividalLEDGreenTrackBar.Value.ToString() + ";" + IndividalLEDBlueTrackBar.Value.ToString() + ";E";
                                        SendDataBySerial(SerialOut);
                                    });
                                });
                            });
                            await Task.Delay(10);
                        }
                    }
                }
            });
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

        #endregion

        #region Instructions Region

        private async void InstructionStartLoopButton_Click(object sender, EventArgs e)
        {
            if (!InstructionsRunning)
            {
                ContinueInstructionsLoop = true;
                await RunInstructions();
            }
        }

        private void InstructionsAddDelayButton_Click(object sender, EventArgs e)
        {
            MakeInstructionsInvisable();
            InstructionsAddDelayPanel.Visible = true;
        }

        private void InstructionsAddFadeColorsButton_Click(object sender, EventArgs e)
        {
            MakeInstructionsInvisable();
            InstructionsAddFadeColorsPanel.Visible = true;
        }

        void MakeInstructionsInvisable()
        {
            InstructionsAddDelayPanel.Visible = false;
            InstructionsAddFadeColorsPanel.Visible = false;
        }

        private void InstructionsAddDelayAddButton_Click(object sender, EventArgs e)
        {
            IntructionsList.Add("Delay;" + InstructionsAddDelayNumericUpDown.Value);
            RestructureInstructions();
        }

        private void InstructionsAddFadeColorsAddButton_Click(object sender, EventArgs e)
        {
            IntructionsList.Add("Fade Colors;" + InstructionsAddFadeColorsFromSeriesIDNumericUpDown.Value + ";" + InstructionsAddFadeColorsToSeriesIDNumericUpDown.Value + ";" + InstructionsAddFadeColorsRedTrackBar.Value.ToString() + ";" + InstructionsAddFadeColorsGreenTrackBar.Value.ToString() + ";" + InstructionsAddFadeColorsBlueTrackBar.Value.ToString() + ";" + InstructionsAddFadeColorsFadeSpeedNumericUpDown.Value.ToString() + ";" + InstructionsAddFadeColorsFadeFactorNumericUpDown.Value.ToString());
            RestructureInstructions();
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

        void RestructureInstructions()
        {
            InstructionsWorkingPanel.Controls.Clear();
            for (int i = 0; i < IntructionsList.Count; i++)
            {
                MakeInstructionPanel(IntructionsList[i],i);
            }
        }

        void MakeInstructionPanel(string _Input, int _ID)
        {
            Panel BackPanel = new Panel();
            BackPanel.Location = new Point(Margins, InstructionsWorkingPanel.Controls.Count * BoxHeight + 2 * Margins);
            BackPanel.Height = BoxHeight;
            BackPanel.Width = InstructionsWorkingPanel.Width - 2 * Margins - ScroolBarWidth;
            BackPanel.BorderStyle = BorderStyle.FixedSingle;
            BackPanel.BackColor = Color.White;
            BackPanel.Tag = _Input;
            BackPanel.Font = new Font(BackPanel.Font.FontFamily, BackPanel.Font.Size);
            BackPanel.BackColor = Color.White;

            Button RemovePanelButton = new Button();
            RemovePanelButton.Tag = _ID;
            RemovePanelButton.Text = "X";
            RemovePanelButton.Width = ButtonWidth;
            RemovePanelButton.Height = ButtonHeight * 2;
            RemovePanelButton.Location = new Point(BackPanel.Width - ButtonWidth - Margins, Margins);
            RemovePanelButton.Parent = BackPanel;
            RemovePanelButton.Click += RemoveInstruction;
            RemovePanelButton.BackColor = Color.DarkGray;
            RemovePanelButton.ForeColor = Color.White;
            RemovePanelButton.Name = "InstructionsInstructionPanelRemoveButton";

            BackPanel.Controls.Add(RemovePanelButton);

            Button MoveUpButton = new Button();
            MoveUpButton.Tag = _ID;
            MoveUpButton.Text = "^";
            MoveUpButton.Width = ButtonWidth;
            MoveUpButton.Height = ButtonHeight;
            MoveUpButton.Click += MoveInstructionUp;
            MoveUpButton.Location = new Point(BackPanel.Width - 2 * ButtonWidth - 3 * Margins, 0);
            MoveUpButton.BackColor = Color.DarkGray;
            MoveUpButton.ForeColor = Color.White;
            MoveUpButton.Name = "InstructionsInstructionPanelMoveUpButton";

            BackPanel.Controls.Add(MoveUpButton);

            Button MoveDownButton = new Button();
            MoveDownButton.Tag = _ID;
            MoveDownButton.Text = "v";
            MoveDownButton.Width = ButtonWidth;
            MoveDownButton.Height = ButtonHeight;
            MoveDownButton.Click += MoveInstructionDown;
            MoveDownButton.Location = new Point(BackPanel.Width - 2 * ButtonWidth - 3 * Margins, BackPanel.Height - ButtonHeight - Margins);
            MoveDownButton.BackColor = Color.DarkGray;
            MoveDownButton.ForeColor = Color.White;
            MoveDownButton.Name = "InstructionsInstructionPanelMoveDownButton";

            BackPanel.Controls.Add(MoveDownButton);

            TextBox InfoTextBox = new TextBox();
            InfoTextBox.Text = _Input.Replace(";"," : ");
            InfoTextBox.Width = BackPanel.Width - ButtonWidth * 2 - 4 * Margins;
            InfoTextBox.Height = BackPanel.Height;
            InfoTextBox.Location = new Point(Margins,Margins);
            InfoTextBox.BorderStyle = BorderStyle.None;
            InfoTextBox.BackColor = Color.DarkGray;
            InfoTextBox.ForeColor = Color.White;
            InfoTextBox.ReadOnly = true;
            InfoTextBox.Name = "InstructionsInstructionPanelInfoTextBox";

            BackPanel.Controls.Add(InfoTextBox);

            InstructionsWorkingPanel.Controls.Add(BackPanel);
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

        private void SaveInstructions(object sender, EventArgs e)
        {
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Instructions";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter AutoSaveFile = new StreamWriter(GenerateStreamFromString(Directory.GetCurrentDirectory() + "\\Instructions\\0.txt"), System.Text.Encoding.UTF8))
                {
                    using (StreamWriter SaveFile = new StreamWriter(SaveFileDialog.OpenFile(), System.Text.Encoding.UTF8))
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
            SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void LoadInstructions(object sender, EventArgs e)
        {
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Instructions";
            if (LoadFileDialog.ShowDialog() == DialogResult.OK)
            {
                while (InstructionsWorkingPanel.Controls.Count > 0)
                    InstructionsWorkingPanel.Controls[0].Dispose();

                IntructionsList.Clear();

                string[] Lines = File.ReadAllLines(LoadFileDialog.FileName, System.Text.Encoding.UTF8);
                for (int i = 0; i < Lines.Length; i++)
                {
                    IntructionsList.Add(Lines[i]);
                    MakeInstructionPanel(Lines[i], i);
                }
            }
            LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        void AutoloadLastInstructions()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Instructions\\0.txt"))
            {
                while (InstructionsWorkingPanel.Controls.Count > 0)
                    InstructionsWorkingPanel.Controls[0].Dispose();

                IntructionsList.Clear();

                string[] Lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Instructions\\0.txt", System.Text.Encoding.UTF8);
                for (int i = 0; i < Lines.Length; i++)
                {
                    IntructionsList.Add(Lines[i]);
                    MakeInstructionPanel(Lines[i], i);
                }
            }
        }
        public static Stream GenerateStreamFromString(string _Input)
        {
            var Stream = new MemoryStream();
            var Writer = new StreamWriter(Stream);
            Writer.Write(_Input);
            Writer.Flush();
            Stream.Position = 0;
            return Stream;
        }

        public async Task RunInstructions()
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
                            InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { InstructionsWorkingPanel.Controls[IntructionsList.Count - 1].BackColor = Color.White; });
                        }
                        else
                        {
                            InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { InstructionsWorkingPanel.Controls[i - 1].BackColor = Color.White; });
                        }
                        InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { InstructionsWorkingPanel.Controls[i].BackColor = Color.Gray; });

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
                        if (Data[0] == "Fade Colors")
                        {
                            string SerialOut = "F;" + Data[1] + ";" + Data[2] + ";" + Data[3] + ";" + Data[4] + ";" + Data[5] + ";" + Data[6] + ";" + Math.Round((Convert.ToDecimal(Data[7]) * 100), 0).ToString() + ";E";
                            SendDataBySerial(SerialOut);
                        }
                        if (StopInstructionsLoop)
                            break;
                    }
                    InstructionsLoopCheckBox.Invoke((MethodInvoker)delegate { ContinueInstructionsLoop = InstructionsLoopCheckBox.Checked; });
                    if (StopInstructionsLoop)
                    {
                        StopInstructionsLoop = false;
                        ContinueInstructionsLoop = false;
                        InstructionsRunning = false;
                    }
                }
                for (int i = 0; i < IntructionsList.Count; i++)
                {
                    InstructionsWorkingPanel.Invoke((MethodInvoker)delegate { InstructionsWorkingPanel.Controls[i].BackColor = Color.White; });
                }
                InstructionsRunning = false;
            });
        }

        private void InstructionStopLoopButton_Click(object sender, EventArgs e)
        {
            if (ContinueInstructionsLoop)
                if (InstructionsRunning)
                    StopInstructionsLoop = true;
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
            EnableBASS(true);
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
            if (BeatZoneToTrackBar.Value < BeatZoneFromTrackBar.Value)
                BeatZoneToTrackBar.Value = BeatZoneFromTrackBar.Value + 1;
            FormatCustomText(BeatZoneFromTrackBar.Value, BeatZoneFromLabel, "");
        }

        private void BeatZoneToTrackBar_Scroll(object sender, EventArgs e)
        {
            if (BeatZoneToTrackBar.Value < BeatZoneFromTrackBar.Value)
                BeatZoneToTrackBar.Value = BeatZoneFromTrackBar.Value + 1;

            FormatCustomText(BeatZoneToTrackBar.Value, BeatZoneToLabel, "");
        }

        private void VisualSamplesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BeatZoneFromTrackBar.Maximum = (int)VisualSamplesNumericUpDown.Value;
            BeatZoneToTrackBar.Maximum = (int)VisualSamplesNumericUpDown.Value;
            UpdateSpectrumChart(SpectrumChart, SpectrumRedTextBox.Text, SpectrumGreenTextBox.Text, SpectrumBlueTextBox.Text, (int)VisualSamplesNumericUpDown.Value, SpectrumAutoScaleValuesCheckBox.Checked);
            UpdateSpectrumChart(WaveChart, WaveRedTextBox.Text, WaveGreenTextBox.Text, WaveBlueTextBox.Text, 255 * 3, WaveAutoScaleValuesCheckBox.Checked);
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
            if (VisualizationTypeComboBox.SelectedIndex == 3)
            {
                WavePanel.Enabled = true;
            }
            if (VisualizationTypeComboBox.SelectedIndex == 4)
            {
                FullSpectrumPanel.Enabled = true;
            }
        }

        private void UpdateSpectrumButton_Click(object sender, EventArgs e)
        {
            if (SpectrumPanel.Enabled)
            {
                UpdateSpectrumChart(SpectrumChart, SpectrumRedTextBox.Text, SpectrumGreenTextBox.Text, SpectrumBlueTextBox.Text, (int)VisualSamplesNumericUpDown.Value, SpectrumAutoScaleValuesCheckBox.Checked);
            }
        }

        private void UpdateWaveButton_Click(object sender, EventArgs e)
        {
            if (WavePanel.Enabled)
            {
                UpdateSpectrumChart(WaveChart, WaveRedTextBox.Text, WaveGreenTextBox.Text, WaveBlueTextBox.Text, 255 * 3, WaveAutoScaleValuesCheckBox.Checked);
            }
        }

        void UpdateSpectrumChart(Chart _Chart, string _Red, string _Green, string _Blue, int _XValues, bool _AutoScale)
        {
            _Chart.Series.Clear();
            Series SeriesRed = new Series { IsVisibleInLegend = false, IsXValueIndexed = false, ChartType = SeriesChartType.FastLine, Color = Color.Red, Tag = _Red };
            Series SeriesGreen = new Series { IsVisibleInLegend = false, IsXValueIndexed = false, ChartType = SeriesChartType.FastLine, Color = Color.Green, Tag = _Green };
            Series SeriesBlue = new Series { IsVisibleInLegend = false, IsXValueIndexed = false, ChartType = SeriesChartType.FastLine, Color = Color.Blue, Tag = _Blue };
            Series[] AllSeries = { SeriesRed, SeriesGreen, SeriesBlue };
            for (int i = 0; i < _XValues; i++)
            {
                foreach (Series InnerSeries in AllSeries)
                {
                    InnerSeries.Points.Add(0);
                }
            }

            for (int i = 0; i < _XValues; i++)
            {
                foreach(Series InnerSeries in AllSeries)
                {
                    if (((string)InnerSeries.Tag).Contains("PW["))
                    {
                        string CurColor = (string)InnerSeries.Tag;
                        List<string> RedInternals = new List<string>();
                        while (CurColor.Contains("PW["))
                        {
                            int StartIndex = CurColor.IndexOf('[');
                            int EndIndex = CurColor.IndexOf(']');
                            RedInternals.Add(CurColor.Substring(StartIndex + 1, EndIndex - StartIndex - 1));
                            CurColor = CurColor.Remove(EndIndex, 1);
                            CurColor = CurColor.Remove(StartIndex - 2, 3);
                        }
                        foreach (string s in RedInternals)
                        {
                            string[] InternalSplit = s.Split(':');
                            if (Int32.Parse(InternalSplit[1]) <= i && Int32.Parse(InternalSplit[2]) >= i)
                            {
                                double ColorValue = TransformToPoint(InternalSplit[0], i);
                                if (_AutoScale)
                                {
                                    if (ColorValue > 255)
                                    {
                                        InnerSeries.Points[i].YValues[0] = 255;
                                    }
                                    else
                                    {
                                        if (ColorValue < 0)
                                            InnerSeries.Points[i].YValues[0] = 0;
                                        else
                                            InnerSeries.Points[i].YValues[0] = ColorValue;
                                    }
                                }
                                else
                                    InnerSeries.Points[i].YValues[0] = ColorValue;
                            }
                        }
                    }
                    else
                    {
                        double ColorValue = TransformToPoint((string)InnerSeries.Tag, i);
                        if (_AutoScale)
                        {
                            if (ColorValue > 255)
                            {
                                InnerSeries.Points[i].YValues[0] = 255;
                            }
                            else
                            {
                                if (ColorValue < 0)
                                    InnerSeries.Points[i].YValues[0] = 0;
                                else
                                    InnerSeries.Points[i].YValues[0] = ColorValue;
                            }
                        }
                        else
                            InnerSeries.Points[i].YValues[0] = ColorValue;
                    }
                }
            }

            foreach (Series InnerSeries in AllSeries)
            {
                _Chart.Series.Add(InnerSeries);
            }
        }

        double TransformToPoint(string _InputEquation, int _XValue)
        {
            string TransformedInputString = _InputEquation.ToLower().Replace("x", _XValue.ToString()).Replace(".", ",").Replace(" ", "");
            string[] Split = System.Text.RegularExpressions.Regex.Split(TransformedInputString, @"(?<=[()^*/+-])");

            List<string> EquationParts = new List<string>();
            foreach(string s in Split)
            {
                EquationParts.Add(s);
            }

            if (EquationParts[0] == "-")
            {
                EquationParts[0] = "-" + EquationParts[1];
                EquationParts.RemoveAt(1);
            }
            if (EquationParts[0] == "+")
            {
                EquationParts.RemoveAt(0);
            }

            for (int i = 0; i < EquationParts.Count; i++)
            {
                if (EquationParts[i].Contains("(") && EquationParts[i].Length > 1)
                {
                    EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("(", ""), ""));
                    EquationParts[i] = EquationParts[i].Replace("(", "");
                    i = 0;
                }
                if (EquationParts[i].Contains(")") && EquationParts[i].Length > 1)
                {
                    EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace(")", ""), ""));
                    EquationParts[i] = EquationParts[i].Replace(")", "");
                    i = 0;
                }
                if (EquationParts[i].Contains("^") && EquationParts[i].Length > 1)
                {
                    EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("^", ""), ""));
                    EquationParts[i] = EquationParts[i].Replace("^", "");
                    i = 0;
                }
                if (EquationParts[i].Contains("*") && EquationParts[i].Length > 1)
                {
                    EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("*", ""), ""));
                    EquationParts[i] = EquationParts[i].Replace("*", "");
                    i = 0;
                }
                if (EquationParts[i].Contains("/") && EquationParts[i].Length > 1)
                {
                    EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("/", ""), ""));
                    EquationParts[i] = EquationParts[i].Replace("/", "");
                    i = 0;
                }
                if (EquationParts[i].Contains("+") && EquationParts[i].Length > 1)
                {
                    EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("+", ""), ""));
                    EquationParts[i] = EquationParts[i].Replace("+", "");
                    i = 0;
                }
                if (EquationParts[i].Contains("-") && EquationParts[i].Length > 1 && EquationParts[i].IndexOf('-') != 0)
                {
                    EquationParts.Insert(i + 1, EquationParts[i].Replace(EquationParts[i].Replace("-", ""), ""));
                    EquationParts[i] = EquationParts[i].Replace("-", "");
                    i = 0;
                }
            }

            try
            {
                while (EquationParts.Contains("("))
                {
                    int StartIndex = EquationParts.FindIndex(s => s.Equals("("));
                    int EndIndex = EquationParts.FindIndex(s => s.Equals(")"));
                    string ComputeString = "";
                    for (int i = StartIndex + 1; i < EndIndex; i++)
                        ComputeString += EquationParts[i];
                    EquationParts[StartIndex] = TransformToPoint(ComputeString, _XValue).ToString();
                    EquationParts.RemoveRange(StartIndex + 1, EndIndex - StartIndex);
                }
                while (EquationParts.Contains("^"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("^"));
                    EquationParts[Index] = (Math.Pow(Convert.ToDouble(EquationParts[Index - 1]), Convert.ToDouble(EquationParts[Index + 1]))).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("*"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("*"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) * Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("/"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("/"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) / Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("+"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("+"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) + Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }
                while (EquationParts.Contains("-"))
                {
                    int Index = EquationParts.FindIndex(s => s.Equals("-"));
                    EquationParts[Index] = (Convert.ToDecimal(EquationParts[Index - 1]) - Convert.ToDecimal(EquationParts[Index + 1])).ToString();
                    EquationParts.RemoveAt(Index + 1);
                    EquationParts.RemoveAt(Index - 1);
                }

                return Convert.ToDouble(EquationParts[0]);

            }
            catch
            {
                MessageBox.Show("Error in input string");
                return 0;
            }
        }

        void EnableBASS(bool setto)
        {
            if (setto)
            {
                if (BassWasapi.BASS_WASAPI_IsStarted())
                    BassWasapi.BASS_WASAPI_Stop(true);

                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();

                BassFirst = true;

                if (AudioDataTimer != null)
                    AudioDataTimer.IsEnabled = false;

                AudioData = new float[Int32.Parse(AudioSampleRateComboBox.SelectedItem.ToString())];
                BassProcess = new WASAPIPROC(Process);
                for (int i = 0; i < VisualSamplesNumericUpDown.Value; i++)
                    AudioDataPointStore.Add(new List<int>(new int[SmoothnessTrackBar.Value]));
                AudioDataTimer = new DispatcherTimer();
                AudioDataTimer.Tick += AudioDataTimer_Tick;
                AudioDataTimer.Interval = TimeSpan.FromMilliseconds(SampleTimeTrackBar.Value);

                BeatZoneSeries = new Series
                {
                    IsVisibleInLegend = false,
                    IsXValueIndexed = false,
                    ChartType = SeriesChartType.Column,
                };

                BassWasapi.BASS_WASAPI_Stop(true);
                var array = (AudioSourceComboBox.Items[AudioSourceComboBox.SelectedIndex] as string).Split(' ');
                int devindex = Convert.ToInt32(array[0]);
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                bool result = BassWasapi.BASS_WASAPI_Init(devindex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, BassProcess, IntPtr.Zero);
                if (!result)
                {
                    var error = Bass.BASS_ErrorGetCode();
                    MessageBox.Show(error.ToString());
                }

                BeatZoneChart.Series.Clear();
                BeatZoneChart.Series.Add(BeatZoneSeries);

                AudioDataTimer.IsEnabled = true;

                BassWasapi.BASS_WASAPI_Start();
            }
            else
            {
                if (AudioDataTimer != null)
                    AudioDataTimer.IsEnabled = false;

                if (BassWasapi.BASS_WASAPI_IsStarted())
                    BassWasapi.BASS_WASAPI_Stop(true);

                BassWasapi.BASS_WASAPI_Free();
                Bass.BASS_Free();
            }
        }

        private int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        private void AudioDataTimer_Tick(object sender, EventArgs e)
        {
            if (VisualSamplesNumericUpDown.Value != BeatZoneSeries.Points.Count)
            {
                BeatZoneSeries.Points.Clear();
                BassFirst = true;
                AudioDataPointStore.Clear();
                for (int i = 0; i < VisualSamplesNumericUpDown.Value; i++)
                    AudioDataPointStore.Add(new List<int>(new int[SmoothnessTrackBar.Value]));
            }
            if (AudioDataPointStore.Count != VisualSamplesNumericUpDown.Value | AudioDataPointStore[0].Count != SmoothnessTrackBar.Value)
            {
                AudioDataPointStore.Clear();
                for (int i = 0; i < VisualSamplesNumericUpDown.Value; i++)
                    AudioDataPointStore.Add(new List<int>(new int[SmoothnessTrackBar.Value]));
            }

            int ReturnValue = BassWasapi.BASS_WASAPI_GetData(AudioData, (int)(BASSData)Enum.Parse(typeof(BASSData), "BASS_DATA_FFT" + Int32.Parse(AudioSampleRateComboBox.SelectedItem.ToString())));
            if (ReturnValue < -1) return;
            int X, Y;
            int B0 = 0;
            for (X = 0; X < VisualSamplesNumericUpDown.Value; X++)
            {
                float Peak = 0;
                int B1 = (int)Math.Pow(2, X * 10.0 / ((int)VisualSamplesNumericUpDown.Value - 1));
                if (B1 > 1023) B1 = 1023;
                if (B1 <= B0) B1 = B0 + 1;
                for (; B0 < B1; B0++)
                {
                    if (Peak < AudioData[1 + B0]) Peak = AudioData[1 + B0];
                }
                Y = (int)(Math.Sqrt(Peak) * SensitivityTrackBar.Value * 255 - 4);
                if (Y > 255) Y = 255;
                if (Y < 1) Y = 1;

                if (AudioDataPointStore[0].Count != SmoothnessTrackBar.Value)
                    break;
                if (AudioDataPointStore.Count != VisualSamplesNumericUpDown.Value)
                    break;

                AudioDataPointStore[X].Add((byte)Y);
                while (AudioDataPointStore[X].Count > SmoothnessTrackBar.Value)
                    AudioDataPointStore[X].RemoveAt(0);

                int AverageValue = 0;
                for (int s = 0; s < SmoothnessTrackBar.Value; s++)
                {
                    AverageValue += AudioDataPointStore[X][s];
                }
                AverageValue = AverageValue / SmoothnessTrackBar.Value;
                if (AverageValue > 255)
                    AverageValue = 255;
                if (AverageValue < 0)
                    AverageValue = 0;
                if (BassFirst)
                {
                    BeatZoneSeries.Points.AddXY(X, AverageValue);
                }
                else
                {
                    BeatZoneSeries.Points.FindByValue(X, "X").YValues[0] = AverageValue;
                }
                BeatZoneSeries.Points.FindByValue(X, "X").Color = Color.FromArgb(0, 0, 0, 0);
                if (X >= BeatZoneFromTrackBar.Value && X <= BeatZoneToTrackBar.Value && BeatZoneSeries.Points[X].YValues[0] >= BeatZoneTriggerHeight.Value)
                {
                    BeatZoneSeries.Points.FindByValue(X, "X").Color = Color.FromArgb(255, 255 - AverageValue, 255 - AverageValue);
                }
                else
                {
                    BeatZoneSeries.Points.FindByValue(X, "X").Color = Color.FromArgb(0, 0, 0);
                }
            }
            if (BassFirst)
                BassFirst = false;

            if (VisualizationTypeComboBox.SelectedIndex == 0)
            {
                double Hit = 0;
                for (int i = BeatZoneFromTrackBar.Value; i < BeatZoneToTrackBar.Value; i++)
                {
                    if (BeatZoneSeries.Points[i].YValues[0] >= BeatZoneTriggerHeight.Value)
                        Hit++;
                }
                double OutValue = Math.Round(Math.Round((Hit / ((double)BeatZoneToTrackBar.Value - (double)BeatZoneFromTrackBar.Value)), 2) * 100, 0);
                AutoTrigger((OutValue / 100) * (255 * 3));
                string SerialOut = "B;" + VisualizerFromSeriesIDNumericUpDown.Value + ";" + VisualizerToSeriesIDNumericUpDown.Value + ";" + OutValue.ToString().Replace(',', '.') + ";E";
                SendDataBySerial(SerialOut);
            }
            if (VisualizationTypeComboBox.SelectedIndex == 1 | VisualizationTypeComboBox.SelectedIndex == 2)
            {
                double EndR = 0;
                double EndG = 0;
                double EndB = 0;
                int CountR = 0;
                int CountG = 0;
                int CountB = 0;
                int Hit = 0;
                for (int i = BeatZoneFromTrackBar.Value; i < BeatZoneToTrackBar.Value; i++)
                {
                    if (BeatZoneSeries.Points[i].YValues[0] >= BeatZoneTriggerHeight.Value)
                    {
                        if (SpectrumChart.Series[0].Points[i].YValues[0] <= 255)
                        {
                            if (SpectrumChart.Series[0].Points[i].YValues[0] >= 0)
                            {
                                EndR += SpectrumChart.Series[0].Points[i].YValues[0];
                                CountR++;
                            }
                        }
                        if (SpectrumChart.Series[1].Points[i].YValues[0] <= 255)
                        {
                            if (SpectrumChart.Series[1].Points[i].YValues[0] >= 0)
                            {
                                EndG += SpectrumChart.Series[1].Points[i].YValues[0];
                                CountG++;
                            }
                        }
                        if (SpectrumChart.Series[2].Points[i].YValues[0] <= 255)
                        {
                            if (SpectrumChart.Series[2].Points[i].YValues[0] >= 0)
                            {
                                EndB += SpectrumChart.Series[2].Points[i].YValues[0];
                                CountB++;
                            }
                        }
                        Hit++;
                    }
                }

                AutoTrigger(((float)Hit / ((float)BeatZoneToTrackBar.Value - (float)BeatZoneFromTrackBar.Value)) * (255 * 3));

                if (CountR > 0)
                {
                    EndR = EndR / CountR;
                }
                if (CountG > 0)
                {
                    EndG = EndG / CountG;
                }
                if (CountB > 0)
                {
                    EndB = EndB / CountB;
                }

                string SerialOut = "";
                if (VisualizationTypeComboBox.SelectedIndex == 1)
                    SerialOut = "F;" + VisualizerFromSeriesIDNumericUpDown.Value + ";" + VisualizerToSeriesIDNumericUpDown.Value + ";" + Math.Round(EndR, 0) + ";" + Math.Round(EndG, 0) + ";" + Math.Round(EndB, 0) + ";0;0;E";
                if (VisualizationTypeComboBox.SelectedIndex == 2)
                    SerialOut = "W;" + VisualizerFromSeriesIDNumericUpDown.Value + ";" + VisualizerToSeriesIDNumericUpDown.Value + ";" + Math.Round(EndR, 0) + ";" + Math.Round(EndG, 0) + ";" + Math.Round(EndB, 0) + ";E";
                SendDataBySerial(SerialOut);
            }
            if (VisualizationTypeComboBox.SelectedIndex == 3)
            {
                int EndR = 0;
                int EndG = 0;
                int EndB = 0;
                int Hit = 0;

                for (int i = BeatZoneFromTrackBar.Value; i < BeatZoneToTrackBar.Value; i++)
                {
                    if (BeatZoneSeries.Points[i].YValues[0] >= BeatZoneTriggerHeight.Value)
                    {
                        Hit++;
                    }
                }

                int EndValue = (int)(((float)255 * (float)3) * ((float)Hit / ((float)BeatZoneToTrackBar.Value - (float)BeatZoneFromTrackBar.Value)));
                if (EndValue >= 765)
                    EndValue = 764;
                if (EndValue < 0)
                    EndValue = 0;

                BeatWaveProgressBar.Value = EndValue;

                EndR = (int)WaveChart.Series[0].Points[EndValue].YValues[0];
                EndG = (int)WaveChart.Series[1].Points[EndValue].YValues[0];
                EndB = (int)WaveChart.Series[2].Points[EndValue].YValues[0];

                AutoTrigger(((float)Hit / ((float)BeatZoneToTrackBar.Value - (float)BeatZoneFromTrackBar.Value)) * (255 * 3));

                if (EndR > 255)
                    EndR = 0;

                if (EndG > 255)
                    EndG = 0;

                if (EndB > 255)
                    EndB = 0;

                if (EndR < 0)
                    EndR = 0;

                if (EndG < 0)
                    EndG = 0;

                if (EndB < 0)
                    EndB = 0;

                string SerialOut = "W;" + VisualizerFromSeriesIDNumericUpDown.Value + ";" + VisualizerToSeriesIDNumericUpDown.Value + ";" + EndR + ";" + EndG + ";" + EndB + ";E";
                SendDataBySerial(SerialOut);
            }
            if (VisualizationTypeComboBox.SelectedIndex == 4)
            {
                int Hit = 0;
                string SerialOut = "S;" + VisualizerFromSeriesIDNumericUpDown.Value + ";" + VisualizerToSeriesIDNumericUpDown.Value + ";" + FullSpectrumNumericUpDown.Value.ToString() + ";";
                for (int i = BeatZoneFromTrackBar.Value; i < BeatZoneToTrackBar.Value; i++)
                {
                    if (BeatZoneSeries.Points[i].YValues[0] >= BeatZoneTriggerHeight.Value)
                    {
                        SerialOut += Math.Round((BeatZoneSeries.Points[i].YValues[0] / 255) * (double)FullSpectrumNumericUpDown.Value, 0) + ";";
                        Hit++;
                    }
                    else
                        SerialOut += "0;";
                }

                AutoTrigger(((float)Hit / ((float)BeatZoneToTrackBar.Value - (float)BeatZoneFromTrackBar.Value)) * (255 * 3));

                SerialOut += "E";
                SendDataBySerial(SerialOut);
            }
        }

        void AutoTrigger(double _TriggerValue)
        {
            if (AutoTriggerCheckBox.Checked)
            {
                VisualizerCurrentValueLabel.Text = ((int)(_TriggerValue)).ToString();
                if (_TriggerValue >= (double)AutoTriggerDecreseAtNumericUpDown.Value)
                {
                    if (BeatZoneTriggerHeight.Value < AutoTriggerMaxNumericUpDown.Value)
                        BeatZoneTriggerHeight.Value = BeatZoneTriggerHeight.Value + 1;
                }
                if (_TriggerValue <= (double)AutoTriggerIncreseAtNumericUpDown.Value)
                {
                    if (BeatZoneTriggerHeight.Value > AutoTriggerMinNumericUpDown.Value)
                        BeatZoneTriggerHeight.Value = BeatZoneTriggerHeight.Value - 1;
                }

                FormatCustomText(BeatZoneTriggerHeight.Value, BeatZoneTriggerHeightLabel, "");
            }
            else
                VisualizerCurrentValueLabel.Text = "0";
        }

        void FormatCustomText(int _Value, Control _Control, string _Additional)
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            BeatZoneTriggerHeight.Enabled = !AutoTriggerCheckBox.Checked;
        }

        private void AudioSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AudioSourceComboBox.Visible)
                EnableBASS(true);
        }

        #endregion

        private void ConfigureSetupWorkingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            DragStart = MousePosition;
            Panel SenderPanel = sender as Panel;
            foreach (Control InnerControl in SenderPanel.Controls)
            {
                foreach (Control InnerInnerControl in InnerControl.Controls)
                {
                    InnerInnerControl.Visible = false;
                }
                Point3D[] MomentaryDataTag = (Point3D[])InnerControl.Tag;
                MomentaryDataTag[0] = new Point3D(InnerControl.Location.X, InnerControl.Location.Y, 1);
                InnerControl.Tag = MomentaryDataTag;
            }
        }

        private void ConfigureSetupWorkingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            Panel SenderPanel = sender as Panel;
            foreach (Control InnerControl in SenderPanel.Controls)
            {
                foreach (Control InnerInnerControl in InnerControl.Controls)
                {
                    InnerInnerControl.Visible = true;
                }
                Point3D[] MomentaryDataTag = (Point3D[])InnerControl.Tag;
                MomentaryDataTag[0] = new Point3D(InnerControl.Location.X, InnerControl.Location.Y, 0);
                InnerControl.Tag = MomentaryDataTag;
            }
        }

        private void ConfigureSetupWorkingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel SenderPanel = sender as Panel;
            foreach (Control InnerControl in SenderPanel.Controls)
            {
                Point3D[] MomentaryDataTag = (Point3D[])InnerControl.Tag;
                if (MomentaryDataTag[0].Z == 1)
                {
                    InnerControl.Location = new Point((int)MomentaryDataTag[0].X + (MousePosition.X - DragStart.X), (int)MomentaryDataTag[0].Y + (MousePosition.Y - DragStart.Y));
                }
            }
        }
    }
}
