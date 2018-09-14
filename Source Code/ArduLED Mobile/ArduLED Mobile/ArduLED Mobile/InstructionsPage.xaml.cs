using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduLED_Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InstructionsPage : ContentPage
	{
        MainMenuPage MainMenu;

        public InstructionsPage(MainMenuPage _MainMenu)
		{
			InitializeComponent();
            MainMenu = _MainMenu;

            MainMenu.SendData("GETINSTRUCTIONSCONFIGS()");
            string Response = MainMenu.ReceiveData();

            InstructionsConfigNamePicker.Items.Clear();
            InstructionsConfigNamePicker.Items.Add("None");
            InstructionsConfigNamePicker.SelectedIndex = 0;
            foreach (string Config in Response.Split(';'))
            {
                if (Config != "")
                    InstructionsConfigNamePicker.Items.Add(Config);
            }
        }

        private void InstructionsLoopSwitch_Switch(object sender, EventArgs e)
        {
            MainMenu.SendData("INSTRUCTIONS(False,False," + InstructionsLoopSwitch.IsToggled + ",)$");
        }

        private void StartInstructionsButton_Clicked(object sender, EventArgs e)
        {
            if (InstructionsConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("INSTRUCTIONS(True,False," + InstructionsLoopSwitch.IsToggled + ",)$");
            else
                MainMenu.SendData("INSTRUCTIONS(True,False," + InstructionsLoopSwitch.IsToggled + "," + InstructionsConfigNamePicker.SelectedItem + ")$");
        }

        private void StopInstructionsButton_Clicked(object sender, EventArgs e)
        {
            MainMenu.SendData("INSTRUCTIONS(False,True," + InstructionsLoopSwitch.IsToggled + ",)$");
        }

        private void SendConfigButton_Clicked(object sender, EventArgs e)
        {
            if (InstructionsConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("INSTRUCTIONS(False,False," + InstructionsLoopSwitch.IsToggled + ",)$");
            else
                MainMenu.SendData("INSTRUCTIONS(False,False," + InstructionsLoopSwitch.IsToggled + "," + InstructionsConfigNamePicker.SelectedItem + ")$");
        }
    }
}