using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduLED_Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AmbilightSettingsPage : ContentPage
	{
        MainMenuPage MainMenu;

        public AmbilightSettingsPage(MainMenuPage _MainMenu)
		{
			InitializeComponent();

            MainMenu = _MainMenu;

            MainMenu.SendData("GETAMBILIGHTCONFIGS()");
            string Response = MainMenu.ReceiveData();

            AmbilightConfigNamePicker.Items.Clear();
            AmbilightConfigNamePicker.Items.Add("None");
            AmbilightConfigNamePicker.SelectedIndex = 0;
            foreach (string Config in Response.Split(';'))
            {
                if (Config != "")
                    AmbilightConfigNamePicker.Items.Add(Config);
            }
            AmbilightConfigNamePicker.Items.RemoveAt(AmbilightConfigNamePicker.Items.Count - 1);
        }

        private void ShowBlocksButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("AMBILIGHT(False,False,True,False,)$");
            else
                MainMenu.SendData("AMBILIGHT(False,False,True,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void AutosetOffsetsButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("AMBILIGHT(False,False,False,True,)$");
            else
                MainMenu.SendData("AMBILIGHT(False,False,False,True," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void StartAmbilightButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("AMBILIGHT(True,False,False,False,)$");
            else
                MainMenu.SendData("AMBILIGHT(True,False,False,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void StopAmbilightButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("AMBILIGHT(False,True,False,False,)$");
            else
                MainMenu.SendData("AMBILIGHT(False,True,False,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void SendConfigButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("AMBILIGHT(False,False,False,False,)$");
            else
                MainMenu.SendData("AMBILIGHT(False,False,False,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }
    }
}