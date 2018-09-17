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

            for (double i = 0; i <= 1; i += 0.05)
                FadeFactorPicker.Items.Add(i.ToString());

            for (int i = 0; i < MainMenu.TotalLEDCount; i++)
                FromIDPicker.Items.Add(i.ToString());

            for (int i = -1; i < MainMenu.TotalLEDCount; i++)
                ToIDPicker.Items.Add(i.ToString());

            MainMenu.SendData("GETTRACKBARVALUE(FadeColorsRedTrackBar,0)");
            RedSlider.Value = Convert.ToDouble(MainMenu.ReceiveData());
            MainMenu.SendData("GETTRACKBARVALUE(FadeColorsGreenTrackBar,0)");
            GreenSlider.Value = Convert.ToDouble(MainMenu.ReceiveData());
            MainMenu.SendData("GETTRACKBARVALUE(FadeColorsBlueTrackBar,0)");
            BlueSlider.Value = Convert.ToDouble(MainMenu.ReceiveData());
            MainMenu.SendData("GETCONTROLTEXT(FadeColorsFadeSpeedNumericUpDown,0)");
            string Recived = MainMenu.ReceiveData();
            for (int i = 0; i < FadeSpeedPicker.Items.Count; i++)
            {
                if (FadeSpeedPicker.Items[i].ToString() == Recived)
                {
                    FadeSpeedPicker.SelectedIndex = i;
                    break;
                }
            }
            MainMenu.SendData("GETCONTROLTEXT(FadeColorsFadeFactorNumericUpDown,0)");
            Recived = MainMenu.ReceiveData();
            for (int i = 0; i < FadeFactorPicker.Items.Count; i++)
            {
                if (Convert.ToDouble(FadeFactorPicker.Items[i].ToString().Replace(',', '.')) == Convert.ToDouble(Recived.Replace(',', '.')))
                {
                    FadeFactorPicker.SelectedIndex = i;
                    break;
                }
                else
                    if (Convert.ToDouble(FadeFactorPicker.Items[i].ToString().Replace('.', ',')) == Convert.ToDouble(Recived.Replace('.', ',')))
                    {
                        FadeFactorPicker.SelectedIndex = i;
                        break;
                    }
            }
            MainMenu.SendData("GETCONTROLTEXT(FadeLEDPanelFromIDNumericUpDown,0)");
            Recived = MainMenu.ReceiveData();
            for (int i = 0; i < FromIDPicker.Items.Count; i++)
            {
                if (FromIDPicker.Items[i].ToString() == Recived)
                {
                    FromIDPicker.SelectedIndex = i;
                    break;
                }
            }
            MainMenu.SendData("GETCONTROLTEXT(FadeLEDPanelToIDNumericUpDown,0)");
            Recived = MainMenu.ReceiveData();
            for (int i = 0; i < ToIDPicker.Items.Count; i++)
            {
                if (ToIDPicker.Items[i].ToString() == Recived)
                {
                    ToIDPicker.SelectedIndex = i;
                    break;
                }
            }

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
                    MainMenu.SendData("FADECOLOR(False, " +
                        Math.Round(Convert.ToDecimal(FromIDPicker.SelectedItem), 0) + "," +
                        Math.Round(Convert.ToDecimal(ToIDPicker.SelectedItem), 0) + "," +
                        Math.Round(RedSlider.Value, 0) + "," +
                        Math.Round(GreenSlider.Value, 0) + "," +
                        Math.Round(BlueSlider.Value, 0) + "," +
                        Math.Round(Convert.ToDecimal(FadeSpeedPicker.SelectedItem), 0) + "," +
                        Convert.ToDecimal(FadeFactorPicker.SelectedItem).ToString().Replace(',', '.') + ")");
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
                }
            }
            catch
            {
                DisplayAlert("Error", "Error in input", "OK");
            }
        }
    }
}