using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduLEDNameSpace
{
    public class LoadingSection
    {
        private MainForm MainFormClass;
        public Loading LoadingForm;
        private Update UpdateForm;

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
                    File.Delete(Directory.GetCurrentDirectory() + "\\Temp.txt");

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
                            File.Delete(Directory.GetCurrentDirectory() + "\\Temp.txt");
                        Environment.Exit(0);
                    }
                    UpdateForm.Dispose();
                    LoadingForm.Name = "DoShow";
                }

                LoadingForm.LoadingScreenLoadingLabel.Invoke((MethodInvoker)delegate { LoadingForm.LoadingScreenLoadingLabel.Text = "Your Version: " + CurrentVersion + " Newest Version: " + NewVersion; });

                if (File.Exists(Directory.GetCurrentDirectory() + "\\Temp.txt"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\Temp.txt");
            }
            else
            {
                MessageBox.Show("Warning, could not find Version.txt, consider reinstalling ArduLED.");
            }

            SetLoadingLabelTo("Serial port settings");

            MainFormClass.SerialPort1.Encoding = System.Text.Encoding.ASCII;
            MainFormClass.SerialPort1.NewLine = "\n";

            SetLoadingLabelTo("BASS.NET");

            MainFormClass.VisualizerSectionClass.InitializeBass();

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

            if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Languages").Length > 0)
            {
                foreach (string f in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Languages"))
                {
                    MainFormClass.LanguageComboBox.Items.Add(f.Substring(f.Length - 6, 2));
                }
            }
            else
                MessageBox.Show("No language packs found! Using default preset");

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

            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.ModeSelectrionComboBox.Items.Add(" ");
            MainFormClass.VisualizationTypeComboBox.Items.Add(" ");
            MainFormClass.VisualizationTypeComboBox.Items.Add(" ");
            MainFormClass.VisualizationTypeComboBox.Items.Add(" ");
            MainFormClass.VisualizationTypeComboBox.Items.Add(" ");
            MainFormClass.VisualizationTypeComboBox.Items.Add(" ");
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

            SetLoadingLabelTo("Screen index");

            MainFormClass.AmbiLightModeScreenIDNumericUpDown.Maximum = SystemInformation.MonitorCount - 1;

            SetLoadingLabelTo("Last Setup");

            MainFormClass.ConfigureSetupSectionClass.AutoloadLastSetup();

            SetLoadingLabelTo("Last instructions");

            MainFormClass.InstructionsSectionClass.AutoloadLastInstructions();

            SetLoadingLabelTo("Default language pack");

            if (MainFormClass.LanguageComboBox.Items.Contains("EN"))
                MainFormClass.LanguageComboBox.SelectedIndex = MainFormClass.LanguageComboBox.FindString("EN");
            else
                MainFormClass.LanguageComboBox.SelectedIndex = 0;

            SetLoadingLabelTo("Previus settings");

            MainFormClass.AutoLoadAllSettings();

            if (MainFormClass.ConfigureSetupEnableServerMode.Checked)
            {
                SetLoadingLabelTo("Server Thread");
                MainFormClass.ServerAPISectionClass.InitializeServer();
            }

            SetLoadingLabelTo("Formating layout");

            MainFormClass.FormatLayout();

            SetLoadingLabelTo("Complete!");

            MainFormClass.ShowLoadingScreen = false;

            for (double i = 0; i <= 100; i += 2)
            {
                MainFormClass.Opacity = i / 100;
                await Task.Delay(10);
            }
            if (MainFormClass.ConfigureSetupAutoSendCheckBox.Checked)
            {
                if (MainFormClass.ComPortsComboBox.Items.Count > 0)
                {
                    MainFormClass.ConfigureSetupAutoSendCheckBox.Enabled = false;
                    MainFormClass.ConfigureSetupHiddenProgressBar.Visible = true;
                    for (int i = MainFormClass.Width; i > MainFormClass.Width - MainFormClass.MenuButton.Width; i--)
                    {
                        MainFormClass.ConfigureSetupHiddenProgressBar.Location = new Point(i, 0);
                        await Task.Delay(5);
                    }
                    MainFormClass.MenuSectionClass.ConnectToComDevice();
                }
                else
                    MessageBox.Show("Error, saved COM port not found!");
            }
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

        public static void DownloadFile(string _SourceURL, string _DestinationPath)
        {
            try
            {
                if (File.Exists(_DestinationPath))
                    File.Delete(_DestinationPath);

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
    }
}
