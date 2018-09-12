using System;
using System.Text;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArduLED_Mobile.Helpers;

namespace ArduLED_Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndividualLEDPage : ContentPage
	{
        MainMenuPage MainMenu;

        private bool Loading = true;

		public IndividualLEDPage(MainMenuPage _MainMenu)
		{
			InitializeComponent();
            MainMenu = _MainMenu;

            if (UserSettings.IndividualPinID != -1)
                PinIDEntry.Text = UserSettings.IndividualPinID.ToString();
            if (UserSettings.InvididualHardwareID != -1)
                HardwareIDEntry.Text = UserSettings.InvididualHardwareID.ToString();
            if (UserSettings.IndividualRedSliderValue != -1)
                SingleRedSlider.Value = UserSettings.IndividualRedSliderValue;
            if (UserSettings.IndividualGreenSliderValue != -1)
                SingleGreenSlider.Value = UserSettings.IndividualGreenSliderValue;
            if (UserSettings.IndividualBlueSliderValue != -1)
                SingleBlueSlider.Value = UserSettings.IndividualBlueSliderValue;

            SingleRedSliderValueLabel.Text = Math.Round(SingleRedSlider.Value, 0).ToString();
            SingleGreenSliderValueLabel.Text = Math.Round(SingleGreenSlider.Value, 0).ToString();
            SingleBlueSliderValueLabel.Text = Math.Round(SingleBlueSlider.Value, 0).ToString();

            Loading = false;
        }

        private void SetColorsButton_Clicked(object sender, EventArgs e)
        {
            if (MainMenu.SourceApp.Client.Connected)
            {
                try
                {
                    String TextboxString = "INDIVIDUALCOLOR(" +
                        Math.Round(Convert.ToDecimal(PinIDEntry.Text), 0) + "," +
                        Math.Round(Convert.ToDecimal(HardwareIDEntry.Text), 0) + "," +
                        Math.Round(SingleRedSlider.Value, 0) + "," +
                        Math.Round(SingleGreenSlider.Value, 0) + "," +
                        Math.Round(SingleBlueSlider.Value, 0) + ")$";

                    Stream DataStream = MainMenu.SourceApp.Client.GetStream();
                    DataStream.ReadTimeout = 1000;
                    DataStream.WriteTimeout = 1000;

                    ASCIIEncoding Encodings = new ASCIIEncoding();
                    byte[] WriteBytes = Encodings.GetBytes(TextboxString);

                    DataStream.Write(WriteBytes, 0, WriteBytes.Length);

                    byte[] ReadBytes = new byte[1024];
                    int Good = DataStream.Read(ReadBytes, 0, 1024);

                    string Response = Encoding.ASCII.GetString(ReadBytes);
                }
                catch
                {
                    Console.WriteLine("Error in transmitting!");
                }
            }
        }

        private void UpdateValueLabels(object sender, EventArgs e)
        {
            SetValueLabels();
        }

        void SetValueLabels()
        {
            try
            {
                if (!Loading)
                {
                    SingleRedSliderValueLabel.Text = Math.Round(SingleRedSlider.Value, 0).ToString();
                    SingleGreenSliderValueLabel.Text = Math.Round(SingleGreenSlider.Value, 0).ToString();
                    SingleBlueSliderValueLabel.Text = Math.Round(SingleBlueSlider.Value, 0).ToString();

                    if (PinIDEntry.Text != "")
                        UserSettings.IndividualPinID = Int32.Parse(PinIDEntry.Text);
                    if (HardwareIDEntry.Text != "")
                        UserSettings.InvididualHardwareID = Int32.Parse(HardwareIDEntry.Text);
                    if (SingleRedSlider.Value != -1)
                        UserSettings.IndividualRedSliderValue = (int)SingleRedSlider.Value;
                    if (SingleGreenSlider.Value != -1)
                        UserSettings.IndividualGreenSliderValue = (int)SingleGreenSlider.Value;
                    if (SingleBlueSlider.Value != -1)
                        UserSettings.IndividualBlueSliderValue = (int)SingleBlueSlider.Value;
                }
            }
            catch
            {
                DisplayAlert("Error", "Error in input", "OK");
            }
        }
    }
}