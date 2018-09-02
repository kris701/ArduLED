using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                                        string SerialOut = "4;" + MomentaryDataTag.PinID + ";" + Button.Text + ";" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B;
                                        MainFormClass.SendDataBySerial(SerialOut);
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
            string SerialOut = "4;" + MomentaryDataTag.PinID + ";" + SenderButton.Text + ";" + AfterShuffel.R + ";" + AfterShuffel.G + ";" + AfterShuffel.B;
            MainFormClass.SendDataBySerial(SerialOut);
        }
    }
}
