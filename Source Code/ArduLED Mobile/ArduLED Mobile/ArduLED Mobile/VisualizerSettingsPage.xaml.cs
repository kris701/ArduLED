using System;
using System.Text;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduLED_Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VisualizerSettingsPage : ContentPage
	{
        MainMenuPage MainMenu;

        public VisualizerSettingsPage(MainMenuPage _MainMenu)
		{
			InitializeComponent();
            MainMenu = _MainMenu;

            MainMenu.SendData("GETVISUALIZERCONFIGS()$");
            string Response = MainMenu.ReceiveData();

            VisualizerConfigNamePicker.Items.Clear();
            VisualizerConfigNamePicker.Items.Add("None");
            VisualizerConfigNamePicker.SelectedIndex = 0;
            foreach (string Config in Response.Split(';'))
            {
                if (Config != "")
                    VisualizerConfigNamePicker.Items.Add(Config);
            }
        }

        private void StartVisualizerButton_Clicked(object sender, EventArgs e)
        {
            if (VisualizerConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("VISUALIZER(True,False,)$");
            else
                MainMenu.SendData("VISUALIZER(True,False," + VisualizerConfigNamePicker.SelectedItem + ")$");
        }

        private void StopVisualizerButton_Clicked(object sender, EventArgs e)
        {
            if (VisualizerConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("VISUALIZER(False,True,)$");
            else
                MainMenu.SendData("VISUALIZER(False,True," + VisualizerConfigNamePicker.SelectedItem + ")$");
        }

        private void SendConfigButton_Clicked(object sender, EventArgs e)
        {
            if (VisualizerConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("VISUALIZER(False,False,)$");
            else
                MainMenu.SendData("VISUALIZER(False,False," + VisualizerConfigNamePicker.SelectedItem + ")$");
        }
    }
}