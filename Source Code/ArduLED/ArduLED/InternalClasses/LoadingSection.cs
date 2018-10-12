using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.BassWasapi;

namespace ArduLEDNameSpace
{
    public class LoadingSection
    {
        private MainForm MainFormClass;
        public Loading LoadingForm;
        private Update UpdateForm;
        public bool IsLoading = false;
        private bool IsVisualsInitialized = false;

        public LoadingSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
        }

        public async Task MainLoadingSection()
        {
            ShowLoadingScreen();

            while (LoadingForm == null) { }
            while (!LoadingForm.Visible) { }

            SetLoadingLabelTo("Checking for new version");

            if (File.Exists(Directory.GetCurrentDirectory() + "\\Version.txt"))
            {

                if (File.Exists(Directory.GetCurrentDirectory() + "\\Temp.txt"))
                    MainFormClass.RemoveFile(Directory.GetCurrentDirectory() + "\\Temp.txt");

                DownloadFile("https://raw.githubusercontent.com/kris701/ArduLED/master/Stable%20version/ArduLED/Version.txt", Directory.GetCurrentDirectory() + "\\Temp.txt");

                string NewVersion = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Temp.txt")[0];
                string CurrentVersion = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Version.txt")[0];

                MainFormClass.Text = "ArduLED " + CurrentVersion;

                if (CurrentVersion != NewVersion)
                {
                    LoadingForm.Name = "DoHide";
                    UpdateForm = new Update();
                    UpdateForm.Show();
                    while (UpdateForm.Visible) { UpdateForm.Refresh(); await Task.Delay(10); }
                    if (UpdateForm.Name == "PerformUpdate")
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start www.github.com/kris701/ArduLED") { CreateNoWindow = true, UseShellExecute = true, WorkingDirectory = "C:\\" });
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\Temp.txt"))
                            MainFormClass.RemoveFile(Directory.GetCurrentDirectory() + "\\Temp.txt");
                        Environment.Exit(0);
                    }
                    UpdateForm.Dispose();
                    LoadingForm.Name = "DoShow";
                }

                LoadingForm.LoadingScreenLoadingLabel.Invoke((MethodInvoker)delegate { LoadingForm.LoadingScreenLoadingLabel.Text = "Your Version: " + CurrentVersion + " Newest Version: " + NewVersion; });

                if (File.Exists(Directory.GetCurrentDirectory() + "\\Temp.txt"))
                    MainFormClass.RemoveFile(Directory.GetCurrentDirectory() + "\\Temp.txt");
            }
            else
            {
                MessageBox.Show("Warning, could not find Version.txt, consider reinstalling ArduLED.");
            }

            SetLoadingLabelTo("Serial port settings");

            MainFormClass.Serial.SerialPort1.Encoding = System.Text.Encoding.ASCII;
            MainFormClass.Serial.SerialPort1.NewLine = "\n";

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

            SetLoadingLabelTo("Visualizer settings folder");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\VisualizerSettings"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\VisualizerSettings");
            }

            SetLoadingLabelTo("Ambilight settings folder");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\AmbilightSettings"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AmbilightSettings");
            }

            SetLoadingLabelTo("Animations folder");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Animations"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Animations");
            }

            SetLoadingLabelTo("Language Packs");

            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Languages"))
            {
                if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Languages").Length > 0)
                {
                    foreach (string f in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Languages"))
                    {
                        MainFormClass.LanguageComboBox.Items.Add(f.Substring(f.Length - 6, 2));
                    }
                }
                else
                    MessageBox.Show("No language packs found! Using default preset");
            }
            else
                MessageBox.Show("No language packs folder found! Using default preset");

            SetLoadingLabelTo("Visuals");

            MainFormClass.MaximumSize = new Size(MainFormClass.Sizex, MainFormClass.Sizey);
            MainFormClass.MinimumSize = new Size(MainFormClass.Sizex, MainFormClass.Sizey);
            MainFormClass.Location = new Point(Screen.PrimaryScreen.Bounds.Width - MainFormClass.Sizex, 0);
            MainFormClass.InstructionsPanel.Size = new Size(786, 710);
            MainFormClass.InstructionsAddVisualizerPanel.Location = new Point(219, 497);
            MainFormClass.InstructionsAddAmbilightPanel.Location = new Point(219, 497);
            MainFormClass.InstructionsAddFadeColorsPanel.Location = new Point(219, 497);
            MainFormClass.InstructionsAddIndividualLEDPanel.Location = new Point(219, 497);
            MainFormClass.InstructionsAddDelayPanel.Location = new Point(219, 497);
            MainFormClass.InstructionsAddWaitUntilPanel.Location = new Point(219, 497);

            MainFormClass.InstructionsPanel.Location = new Point(165, 21);
            MainFormClass.MenuPanel.Location = new Point(950, 21);
            MainFormClass.ConfigureSetupHiddenProgressBar.Location = new Point(1336, -1);
            MainFormClass.MenuButton.Location = new Point(1336, -1);
            MainFormClass.AmbiLightModePanel.Location = new Point(264, 21);
            MainFormClass.IndividualLEDPanel.Location = new Point(81, 21);
            MainFormClass.VisualizerPanel.Location = new Point(4, 21);
            MainFormClass.ConfigureSetupPanel.Location = new Point(79, 21);
            MainFormClass.ServerSettingsPanel.Location = new Point(80, 21);
            MainFormClass.AnimationModePanel.Location = new Point(80, 21);
            MainFormClass.GeneralSettingsPanel.Location = new Point(596, 21);

            SetLoadingLabelTo("Save/Load Mechanisms");

            MainFormClass.SaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            MainFormClass.LoadFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            SetLoadingLabelTo("Charts");

            MainFormClass.BeatZoneChart.ChartAreas[0].AxisY.Maximum = 255;
            MainFormClass.SpectrumChart.ChartAreas[0].AxisY.Maximum = 255;
            MainFormClass.WaveChart.ChartAreas[0].AxisY.Maximum = 255;
            MainFormClass.BeatZoneChart.ChartAreas[0].AxisY.Minimum = 0;
            MainFormClass.SpectrumChart.ChartAreas[0].AxisY.Minimum = 0;
            MainFormClass.WaveChart.ChartAreas[0].AxisY.Minimum = 0;

            MainFormClass.BeatZoneChart.ChartAreas[0].AxisX.Minimum = 0;
            MainFormClass.SpectrumChart.ChartAreas[0].AxisX.Minimum = 0;
            MainFormClass.WaveChart.ChartAreas[0].AxisX.Minimum = 0;
            MainFormClass.BeatZoneChart.ChartAreas[0].AxisX.Maximum = MainFormClass.BeatZoneToTrackBar.Maximum;
            MainFormClass.SpectrumChart.ChartAreas[0].AxisX.Maximum = MainFormClass.BeatZoneToTrackBar.Maximum;

            SetLoadingLabelTo("Presetting Combobox indexes");

            for (int i = 0; i < 9; i++)
                MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            for (int i = 0; i < 9; i++)
                MainFormClass.GeneralSettingsStartAtModeComboBox.Items.Add(" ");

            for (int i = 0; i < 6; i++)
                MainFormClass.VisualizationTypeComboBox.Items.Add(" ");

            MainFormClass.PixelTypeComboBox.Items.Add(" ");
            MainFormClass.PixelTypeComboBox.Items.Add(" ");
            MainFormClass.PixelBitstreamComboBox.Items.Add(" ");
            MainFormClass.PixelBitstreamComboBox.Items.Add(" ");

            SetLoadingLabelTo("Indexing Comboboxes");

            MainFormClass.AudioSourceComboBox.SelectedIndex = 0;
            MainFormClass.VisualizationTypeComboBox.SelectedIndex = 0;
            MainFormClass.AudioSampleRateComboBox.SelectedIndex = 6;
            MainFormClass.PixelTypeComboBox.SelectedIndex = 0;
            MainFormClass.PixelBitstreamComboBox.SelectedIndex = 0;
            MainFormClass.GeneralSettingsStartAtModeComboBox.SelectedIndex = 0;

            SetLoadingLabelTo("Screen index");

            MainFormClass.AmbiLightModeScreenIDNumericUpDown.Maximum = SystemInformation.MonitorCount - 1;

            SetLoadingLabelTo("Last Setup");

            MainFormClass.ConfigureSetupSectionClass.AutoloadLastSetup();

            SetLoadingLabelTo("Last instructions");

            MainFormClass.InstructionsSectionClass.AutoloadLastInstructions();

            SetLoadingLabelTo("Last animation");

            MainFormClass.AnimationModeSectionClass.AutoloadLastAnimation();

            if (MainFormClass.LanguageComboBox.Items.Count > 0)
            {
                SetLoadingLabelTo("Default language pack");

                if (MainFormClass.LanguageComboBox.Items.Contains("EN"))
                    MainFormClass.LanguageComboBox.SelectedIndex = MainFormClass.LanguageComboBox.FindString("EN");
                else
                    MainFormClass.LanguageComboBox.SelectedIndex = 0;
            }

            SetLoadingLabelTo("Visual sections");

            MainFormClass.Serial.Wait = true;
            IsLoading = true;

            await InitializeAllVisualSections();

            IsLoading = false;
            MainFormClass.Serial.Wait = false;

            SetLoadingLabelTo("Previus settings");

            MainFormClass.AutoLoadAllSettings();

            SetLoadingLabelTo("Formating layout");

            MainFormClass.FormatLayout();

            SetLoadingLabelTo("Complete!");

            MainFormClass.ShowLoadingScreen = false;

            for (double i = 0; i <= 100; i += 2)
            {
                MainFormClass.Opacity = i / 100;
                await Task.Delay(10);
            }
            if (MainFormClass.GeneralSettingsAutoSendCheckBox.Checked)
            {
                if (MainFormClass.ComPortsComboBox.Items.Count > 0)
                {
                    MainFormClass.GeneralSettingsAutoSendCheckBox.Enabled = false;
                    MainFormClass.ConfigureSetupHiddenProgressBar.Visible = true;
                    for (int i = MainFormClass.Width; i > MainFormClass.Width - MainFormClass.MenuButton.Width; i--)
                    {
                        MainFormClass.ConfigureSetupHiddenProgressBar.Location = new Point(i, 0);
                        await Task.Delay(5);
                    }
                    await MainFormClass.MenuSectionClass.ConnectToComDevice();
                }
                else
                    MessageBox.Show("Error, saved COM port not found!");

                MainFormClass.MenuPanel.Visible = MainFormClass.GeneralSettingsStartAtModeOpenMenuAswellCheckBox.Checked;

                if (MainFormClass.ModeSelectrionComboBox.SelectedIndex != 8)
                {
                    await Task.Delay(500);
                    if (MainFormClass.GeneralSettingsStartAtModeComboBox.SelectedIndex != 0)
                    {
                        MainFormClass.ModeSelectrionComboBox.SelectedIndex = MainFormClass.GeneralSettingsStartAtModeComboBox.SelectedIndex;
                    }
                    else
                    {
                        MainFormClass.MenuSectionClass.ModeIndexChange(MainFormClass.GeneralSettingsStartAtModeComboBox.SelectedIndex);
                        MainFormClass.ModeSelectrionComboBox.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MainFormClass.MenuPanel.Visible = true;
                MainFormClass.ModeSelectrionComboBox.SelectedIndex = 8;
            }

            if (MainFormClass.GeneralSettingsEnableServerMode.Checked)
            {
                MainFormClass.ServerAPISectionClass.InitializeServer();
            }

            MainFormClass.AnimationModeLoopCheckBox.Checked = MainFormClass.GeneralSettingsAutostartAutoloadedAnimationLoop.Checked;
            MainFormClass.InstructionsLoopCheckBox.Checked = MainFormClass.GeneralSettingsAutostartAutoloadedInstructionsLoop.Checked;

            if (MainFormClass.GeneralSettingsAutostartAutoloadedInstructions.Checked)
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
            else
            {
                if (MainFormClass.GeneralSettingsAutostartAutoloadedAnimation.Checked)
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
            }

            if (!MainFormClass.GeneralSettingsStartAtModeOpenMenuAswellCheckBox.Checked)
                if (MainFormClass.GeneralSettingsAutoHideCheckBox.Checked)
                    MainFormClass.MenuSectionClass.HideTimer.Start();
        }

        private void ShowLoadingScreen()
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

                while (MainFormClass.ShowLoadingScreen)
                {
                    Application.DoEvents();
                    if (LoadingForm.Name == "Closing")
                        Environment.Exit(0);
                    if (LoadingForm.Name == "DoHide")
                    {
                        LoadingForm.Hide();
                        LoadingForm.Name = "";
                    }
                    if (LoadingForm.Name == "DoShow")
                    {
                        LoadingForm.Show();
                        LoadingForm.Name = "";
                    }
                    Thread.Sleep(10);
                }

                for (double i = 100; i >= 0; i -= 4)
                {
                    LoadingForm.Opacity = i / 100;
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                LoadingForm.Dispose();
            });
        }

        private void SetLoadingLabelTo(string _Input)
        {
            if (LoadingForm.Name == "Closing")
                Environment.Exit(0);

            LoadingForm.LoadingScreenLabel.Invoke((MethodInvoker)delegate { LoadingForm.LoadingScreenLabel.Text = "Loading: " + _Input; });
        }

        public void DownloadFile(string _SourceURL, string _DestinationPath)
        {
            try
            {
                if (File.Exists(_DestinationPath))
                    MainFormClass.RemoveFile(_DestinationPath);

                using (var Client = new System.Net.WebClient())
                {
                    Client.Headers.Add("user-agent", "Anything");
                    Client.DownloadFile(_SourceURL, _DestinationPath);
                }
            }
            catch
            {
                MessageBox.Show("Error Connecting To servers!");
            }
        }

        public void InitializeBass()
        {
            MainFormClass.AudioSourceComboBox.Items.Clear();
            int DeviceCount = BassWasapi.BASS_WASAPI_GetDeviceCount();
            for (int i = 0; i < DeviceCount; i++)
            {
                SetLoadingLabelTo("BASS.NET: Device " + i + " out of " + DeviceCount);
                var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                if (device.IsEnabled && device.IsLoopback)
                {
                    MainFormClass.AudioSourceComboBox.Items.Add(string.Format("{0} - {1}", i, device.name));
                }
            }

            foreach (string s in SerialPort.GetPortNames())
            {
                MainFormClass.ComPortsComboBox.Items.Add(s);
            }
        }

        public async Task InitializeAllVisualSections()
        {
            if (!IsVisualsInitialized)
            {
                int PreIndex = MainFormClass.ModeSelectrionComboBox.SelectedIndex;
                if (PreIndex < 0) PreIndex = 0;
                for (int i = 0; i < MainFormClass.ModeSelectrionComboBox.Items.Count; i++)
                {
                    MainFormClass.ModeSelectrionComboBox.SelectedIndex = i;
                    await Task.Delay(100);
                }
                MainFormClass.ModeSelectrionComboBox.SelectedIndex = PreIndex;

                IsVisualsInitialized = true;
            }
        }
    }
}
