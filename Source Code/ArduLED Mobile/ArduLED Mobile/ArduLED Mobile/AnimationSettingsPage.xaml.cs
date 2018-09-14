using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduLED_Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnimationSettingsPage : ContentPage
	{
        MainMenuPage MainMenu;

        public AnimationSettingsPage(MainMenuPage _MainMenu)
        {
            InitializeComponent();
            MainMenu = _MainMenu;

            MainMenu.SendData("GETANIMATIONCONFIGS()");
            string Response = MainMenu.ReceiveData();

            AnimationConfigNamePicker.Items.Clear();
            AnimationConfigNamePicker.Items.Add("None");
            AnimationConfigNamePicker.SelectedIndex = 0;
            foreach (string Config in Response.Split(';'))
            {
                if (Config != "")
                    AnimationConfigNamePicker.Items.Add(Config);
            }
        }

        private void AnimationLoopSwitch_Switch(object sender, EventArgs e)
        {
            MainMenu.SendData("ANIMATION(False,False," + AnimationLoopSwitch.IsToggled + ",)$");
        }

        private void StartAnimationButton_Clicked(object sender, EventArgs e)
        {
            if (AnimationConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("ANIMATION(True,False," + AnimationLoopSwitch.IsToggled + ",)$");
            else
                MainMenu.SendData("ANIMATION(True,False," + AnimationLoopSwitch.IsToggled + "," + AnimationConfigNamePicker.SelectedItem + ")$");
        }

        private void StopAnimationButton_Clicked(object sender, EventArgs e)
        {
            MainMenu.SendData("ANIMATION(False,True," + AnimationLoopSwitch.IsToggled + ",)$");
        }

        private void SendConfigButton_Clicked(object sender, EventArgs e)
        {
            if (AnimationConfigNamePicker.SelectedItem.ToString() == "None")
                MainMenu.SendData("ANIMATION(False,False," + AnimationLoopSwitch.IsToggled + ",)$");
            else
                MainMenu.SendData("ANIMATION(False,False," + AnimationLoopSwitch.IsToggled + "," + AnimationConfigNamePicker.SelectedItem + ")$");
        }
    }
}