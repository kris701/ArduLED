using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArduLED_Serial_Protocol;

namespace ArduLEDNameSpace
{
    public class IndividualLEDSection
    {
        private MainForm MainFormClass;

        public IndividualLEDSection(MainForm _MainFormClass)
        {
            this.MainFormClass = _MainFormClass;
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
                            MainFormClass.IndividalLEDRedTrackBar.Invoke((MethodInvoker)delegate {
                                MainFormClass.IndividalLEDGreenTrackBar.Invoke((MethodInvoker)delegate {
                                    MainFormClass.IndividalLEDBlueTrackBar.Invoke((MethodInvoker)delegate {
                                        WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)Button.Parent.Tag;
                                        Button.BackColor = Color.FromArgb(MainFormClass.IndividalLEDRedTrackBar.Value, MainFormClass.IndividalLEDGreenTrackBar.Value, MainFormClass.IndividalLEDBlueTrackBar.Value);
                                        Color AfterShuffel = MainFormClass.ShuffleColors(Color.FromArgb(MainFormClass.IndividalLEDRedTrackBar.Value, MainFormClass.IndividalLEDGreenTrackBar.Value, MainFormClass.IndividalLEDBlueTrackBar.Value));
                                        MainFormClass.Serial.Write(new IndividualLEDs(AfterShuffel.R, AfterShuffel.G, AfterShuffel.B, MomentaryDataTag.PinID, Int32.Parse(Button.Text)));
                                    });
                                });
                            });
                            await Task.Delay(10);
                        }
                    }
                }
            });
        }

        public void ColorSingleLED(Button SenderButton)
        {
            WorkingPanelBox MomentaryDataTag = (WorkingPanelBox)SenderButton.Parent.Tag;
            SenderButton.BackColor = Color.FromArgb(MainFormClass.IndividalLEDRedTrackBar.Value, MainFormClass.IndividalLEDGreenTrackBar.Value, MainFormClass.IndividalLEDBlueTrackBar.Value);
            Color AfterShuffel = MainFormClass.ShuffleColors(Color.FromArgb(MainFormClass.IndividalLEDRedTrackBar.Value, MainFormClass.IndividalLEDGreenTrackBar.Value, MainFormClass.IndividalLEDBlueTrackBar.Value));
            MainFormClass.Serial.Write(new IndividualLEDs(AfterShuffel.R, AfterShuffel.G, AfterShuffel.B, MomentaryDataTag.PinID, Int32.Parse(SenderButton.Text)));
        }
    }
}
