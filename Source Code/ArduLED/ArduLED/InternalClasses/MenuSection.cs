using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ArduLEDNameSpace
{
    public class MenuSection : IDisposable
    {
        public bool IsDisposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private System.Windows.Forms.Timer HideTimer;
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
                HideTimer.Dispose();
            }

            IsDisposed = true;
        }

        public MenuSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
            HideTimer = new System.Windows.Forms.Timer();
            HideTimer.Interval = 5000;
            HideTimer.Tick += HideTimer_Tick;
        }

        public async Task ConnectToComDevice()
        {
            try
            {
                if (MainFormClass.SerialPort1.IsOpen)
                    MainFormClass.SerialPort1.Close();
                MainFormClass.SerialPort1.PortName = MainFormClass.ComPortsComboBox.Text;
                MainFormClass.SerialPort1.BaudRate = MainFormClass.BaudRate;
                MainFormClass.SerialPort1.Open();
                MainFormClass.UnitReady = false;
            }
            catch
            {
                MainFormClass.MenuPanel.Visible = true;
                MainFormClass.ModeSelectrionComboBox.SelectedIndex = 8;
                MessageBox.Show("COM Port already in use!");
            }

            if (MainFormClass.SerialPort1.IsOpen)
            {
                int DelayCount = 0;
                bool NoError = true;
                while (!MainFormClass.UnitReady)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                    DelayCount++;
                    if (DelayCount >= 100)
                    {
                        if (MainFormClass.GeneralSettingsAutoSendCheckBox.Checked)
                            MainFormClass.ConfigureSetupHiddenProgressBar.Visible = false;
                        MessageBox.Show("Error, unit timed out!");
                        NoError = false;
                        break;
                    }
                }
                if (NoError)
                {
                    MainFormClass.ModeSelectrionComboBox.Enabled = true;
                    if (!MainFormClass.GeneralSettingsAutoSendCheckBox.Checked)
                        MainFormClass.ModeSelectrionComboBox.SelectedIndex = 7;
                    else
                        await MainFormClass.ConfigureSetupSectionClass.SendSetup();
                }
            }
        }

        public void ShowHideMenu()
        {
            if (MainFormClass.MenuPanel.Visible)
            {
                MainFormClass.MenuPanel.Visible = false;
                MainFormClass.IndividualLEDPanel.Visible = false;
                MainFormClass.VisualizerPanel.Visible = false;
                MainFormClass.ConfigureSetupPanel.Visible = false;
                MainFormClass.InstructionsPanel.Visible = false;
                MainFormClass.AmbiLightModePanel.Visible = false;
                MainFormClass.ServerSettingsPanel.Visible = false;
                MainFormClass.AnimationModePanel.Visible = false;
                MainFormClass.GeneralSettingsPanel.Visible = false;
                MainFormClass.AutoSaveAllSettings();
                if (MainFormClass.MenuAutoHideCheckBox.Checked)
                    HideTimer.Start();
            }
            else
            {
                if (MainFormClass.MenuAutoHideCheckBox.Checked)
                {
                    HideTimer.Stop();
                    MainFormClass.Opacity = 1;
                }
                MainFormClass.MenuPanel.Visible = true;
            }
        }

        public void LanguageIndexChange()
        {
            string[] Lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Languages\\" + MainFormClass.LanguageComboBox.SelectedItem + ".txt");
            for (int i = 0; i < Lines.Length; i++)
            {
                try
                {
                    string[] Split = Lines[i].Split(';');
                    if (Split[0] != "")
                    {
                        if (Split[0].ToUpper() == "INDEXNAMES")
                        {
                            Control[] ControlText = MainFormClass.Controls.Find(Split[1], true);
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
                                Control[] ControlText = MainFormClass.Controls.Find(Split[0], true);
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
                                Control[] ControlText = MainFormClass.Controls.Find(Split[0], true);
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
                catch { }
            }

            MainFormClass.FormatLayout();
        }

        public void ModeIndexChange(int _Index)
        {
            MainFormClass.FadeLEDPanel.Enabled = false;
            MainFormClass.VisualizerPanel.Visible = false;
            MainFormClass.IndividualLEDPanel.Visible = false;
            MainFormClass.InstructionsPanel.Visible = false;
            MainFormClass.ConfigureSetupPanel.Visible = false;
            MainFormClass.AmbiLightModePanel.Visible = false;
            MainFormClass.ServerSettingsPanel.Visible = false;
            MainFormClass.AnimationModePanel.Visible = false;
            MainFormClass.GeneralSettingsPanel.Visible = false;
            MainFormClass.VisualizerEnabled = false;
            MainFormClass.VisualizerSectionClass.EnableBASS(false);

            MainFormClass.AnimationModeSectionClass.AutoSave();
            MainFormClass.InstructionsSectionClass.AutoSave();
            MainFormClass.ConfigureSetupSectionClass.AutoSave();

            if (_Index == 0)
            {
                MainFormClass.FadeLEDPanel.Enabled = true;
                MainFormClass.FadeLEDPanel.BringToFront();
                if (!MainFormClass.InstructionsSectionClass.ContinueInstructionsLoop)
                {
                    MainFormClass.FadeColorsSectionClass.FadeColorsSendData(
                        true,
                        (int)MainFormClass.FadeLEDPanelFromIDNumericUpDown.Value,
                        (int)MainFormClass.FadeLEDPanelToIDNumericUpDown.Value,
                        Color.FromArgb(MainFormClass.FadeColorsRedTrackBar.Value, MainFormClass.FadeColorsGreenTrackBar.Value, MainFormClass.FadeColorsBlueTrackBar.Value),
                        (int)MainFormClass.FadeColorsFadeSpeedNumericUpDown.Value,
                        (double)MainFormClass.FadeColorsFadeFactorNumericUpDown.Value
                        );
                }
            }
            if (_Index == 1)
            {
                MainFormClass.AmbiLightSectionClass.StopAmbilight();

                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.VisualizerPanel.Visible = true;
                MainFormClass.VisualizerPanel.BringToFront();
                if (!MainFormClass.InstructionsSectionClass.ContinueInstructionsLoop)
                {

                    MainFormClass.VisualizerEnabled = true;

                    MainFormClass.VisualizerSectionClass.EnableBASS(true);
                }
            }
            if (_Index == 2)
            {
                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.IndividualLEDPanel.Visible = true;
                MainFormClass.IndividualLEDPanel.BringToFront();
                if (!MainFormClass.InstructionsSectionClass.ContinueInstructionsLoop)
                {
                    MainFormClass.FadeColorsSectionClass.FadeColorsSendData(
                        false,
                        (int)MainFormClass.FadeLEDPanelFromIDNumericUpDown.Value,
                        (int)MainFormClass.FadeLEDPanelToIDNumericUpDown.Value,
                        Color.FromArgb(MainFormClass.FadeColorsRedTrackBar.Value, MainFormClass.FadeColorsGreenTrackBar.Value, MainFormClass.FadeColorsBlueTrackBar.Value),
                        (int)MainFormClass.FadeColorsFadeSpeedNumericUpDown.Value,
                        (double)MainFormClass.FadeColorsFadeFactorNumericUpDown.Value
                        );
                }
            }
            if (_Index == 3)
            {
                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.InstructionsPanel.Visible = true;
                MainFormClass.InstructionsPanel.BringToFront();
                if (!MainFormClass.InstructionsSectionClass.ContinueInstructionsLoop)
                {
                    MainFormClass.FadeColorsSectionClass.FadeColorsSendData(
                        false,
                        (int)MainFormClass.FadeLEDPanelFromIDNumericUpDown.Value,
                        (int)MainFormClass.FadeLEDPanelToIDNumericUpDown.Value,
                        Color.FromArgb(MainFormClass.FadeColorsRedTrackBar.Value, MainFormClass.FadeColorsGreenTrackBar.Value, MainFormClass.FadeColorsBlueTrackBar.Value),
                        (int)MainFormClass.FadeColorsFadeSpeedNumericUpDown.Value,
                        (double)MainFormClass.FadeColorsFadeFactorNumericUpDown.Value
                        );
                }
            }
            if (_Index == 4)
            {
                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.AmbiLightModePanel.Visible = true;
                MainFormClass.AmbiLightModePanel.BringToFront();
            }
            if (_Index == 5)
            {
                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.ServerSettingsPanel.Visible = true;
                MainFormClass.ServerSettingsPanel.BringToFront();
            }
            if (_Index == 6)
            {
                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.AnimationModePanel.Visible = true;
                MainFormClass.AnimationModePanel.BringToFront();
            }
            if (_Index == 7)
            {
                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.ConfigureSetupPanel.Visible = true;
                MainFormClass.ConfigureSetupPanel.BringToFront();
            }
            if (_Index == 8)
            {
                if (MainFormClass.MenuPanel.Visible)
                    MainFormClass.GeneralSettingsPanel.Visible = true;
                MainFormClass.GeneralSettingsPanel.BringToFront();
            }
        }

        private async void HideTimer_Tick(object sender, EventArgs e)
        {
            if (!MainFormClass.MenuPanel.Visible)
            {
                for (double i = 100; i >= 0; i -= 2)
                {
                    MainFormClass.Opacity = i / 100;
                    await Task.Delay(10);
                    if (MainFormClass.MenuPanel.Visible)
                    {
                        MainFormClass.Opacity = 1;
                        break;
                    }
                }
            }
            HideTimer.Stop();
        }

        public async Task ShowArduLED()
        {
            if (MainFormClass.MenuAutoHideCheckBox.Checked)
            {
                if (!MainFormClass.MenuPanel.Visible)
                {
                    if (MainFormClass.Opacity != 1)
                    {
                        if (!MainFormClass.ShowLoadingScreen)
                        {
                            HideTimer.Stop();
                            bool BreakInside = false;
                            for (double i = 0; i <= 100; i += 2)
                            {
                                if (MainFormClass.Opacity == 1)
                                {
                                    BreakInside = true;
                                    break;
                                }
                                MainFormClass.Opacity = i / 100;
                                await Task.Delay(10);
                            }
                            if (!BreakInside)
                                HideTimer.Start();
                        }
                    }
                }
            }
            if (MainFormClass.Opacity != 1)
            {
                MainFormClass.Opacity = 1;
            }
        }
    }
}
