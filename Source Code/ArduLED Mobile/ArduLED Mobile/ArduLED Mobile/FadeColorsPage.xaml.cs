using System;
using System.Text;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArduLED_Mobile.Helpers;

namespace ArduLED_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FadeColorsPage : ContentPage
    {
        MainMenuPage MainMenu;
        bool Loading = true;

        public FadeColorsPage(MainMenuPage _MainMenu)
        {
            InitializeComponent();
            MainMenu = _MainMenu;

            FadeSpeedPicker.Items.Clear();
            FadeFactorPicker.Items.Clear();
            FromIDPicker.Items.Clear();
            ToIDPicker.Items.Clear();

            for (int i = 0; i < 100; i++)
                FadeSpeedPicker.Items.Add(i.ToString());

            for (int i = 0; i < 500; i++)
                FadeFactorPicker.Items.Add(i.ToString());

            for (int i = 0; i < MainMenu.TotalLEDCount; i++)
                FromIDPicker.Items.Add(i.ToString());

            for (int i = -1; i < MainMenu.TotalLEDCount; i++)
                ToIDPicker.Items.Add(i.ToString());

            if (UserSettings.FadeColorsFromIDPickerValue != -1)
                FromIDPicker.SelectedIndex = UserSettings.FadeColorsFromIDPickerValue;
            if (UserSettings.FadeColorsToIDPickerValue != -1)
                ToIDPicker.SelectedIndex = UserSettings.FadeColorsToIDPickerValue;
            if(UserSettings.FadeColorsRedSliderValue != -1)
                RedSlider.Value = UserSettings.FadeColorsRedSliderValue;
            if(UserSettings.FadeColorsGreenSliderValue != -1)
                GreenSlider.Value = UserSettings.FadeColorsGreenSliderValue;
            if(UserSettings.FadeColorsBlueSliderValue != -1)
                BlueSlider.Value = UserSettings.FadeColorsBlueSliderValue;
            if (UserSettings.FadeColorsFadeSpeedPickerValue != -1)
                FadeSpeedPicker.SelectedIndex = UserSettings.FadeColorsFadeSpeedPickerValue;
            if (UserSettings.FadeColorsFadeFactorPickerValue != -1)
                FadeFactorPicker.SelectedIndex = UserSettings.FadeColorsFadeFactorPickerValue;

            RedSliderValueLabel.Text = Math.Round(RedSlider.Value, 0).ToString();
            GreenSliderValueLabel.Text = Math.Round(GreenSlider.Value, 0).ToString();
            BlueSliderValueLabel.Text = Math.Round(BlueSlider.Value, 0).ToString();

            Loading = false;
        }

        private void FadeColorsButton_Clicked(object sender, EventArgs e)
        {
            if (MainMenu.SourceApp.Client.Connected)
            {
                try
                {
                    String TextboxString = "FADECOLOR(False, " +
                        Math.Round(Convert.ToDecimal(FromIDPicker.SelectedItem), 0) + "," +
                        Math.Round(Convert.ToDecimal(ToIDPicker.SelectedItem), 0) + "," +
                        Math.Round(RedSlider.Value, 0) + "," +
                        Math.Round(GreenSlider.Value, 0) + "," +
                        Math.Round(BlueSlider.Value, 0) + "," +
                        Math.Round(Convert.ToDecimal(FadeSpeedPicker.SelectedItem), 0) + "," +
                        Math.Round(Convert.ToDecimal(FadeFactorPicker.SelectedItem), 0) + ")$";

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
                    RedSliderValueLabel.Text = Math.Round(RedSlider.Value, 0).ToString();
                    GreenSliderValueLabel.Text = Math.Round(GreenSlider.Value, 0).ToString();
                    BlueSliderValueLabel.Text = Math.Round(BlueSlider.Value, 0).ToString();

                    if (FromIDPicker.SelectedIndex != -1)
                        UserSettings.FadeColorsFromIDPickerValue = FromIDPicker.SelectedIndex;
                    if (ToIDPicker.SelectedIndex != -1)
                        UserSettings.FadeColorsToIDPickerValue = ToIDPicker.SelectedIndex;
                    if (RedSlider.Value != -1)
                        UserSettings.FadeColorsRedSliderValue = (int)RedSlider.Value;
                    if (GreenSlider.Value != -1)
                        UserSettings.FadeColorsGreenSliderValue = (int)GreenSlider.Value;
                    if (BlueSlider.Value != -1)
                        UserSettings.FadeColorsBlueSliderValue = (int)BlueSlider.Value;
                    if (FadeSpeedPicker.SelectedIndex != -1)
                        UserSettings.FadeColorsFadeSpeedPickerValue = FadeSpeedPicker.SelectedIndex;
                    if (FadeFactorPicker.SelectedIndex != -1)
                        UserSettings.FadeColorsFadeFactorPickerValue = FadeFactorPicker.SelectedIndex;
                }
            }
            catch
            {
                DisplayAlert("Error", "Error in input", "OK");
            }
        }
    }
}