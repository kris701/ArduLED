using System;
using System.Text;
using System.IO;
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

            string Response = SendData("GETAMBILIGHTCONFIGS()$");

            AmbilightConfigNamePicker.Items.Clear();
            AmbilightConfigNamePicker.Items.Add("None");
            AmbilightConfigNamePicker.SelectedIndex = 0;
            foreach (string Config in Response.Split(';'))
            {
                AmbilightConfigNamePicker.Items.Add(Config);
            }
            AmbilightConfigNamePicker.Items.RemoveAt(AmbilightConfigNamePicker.Items.Count - 1);
        }

        private void ShowBlocksButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("AMBILIGHT(False,False,True,False,)$");
            else
                SendData("AMBILIGHT(False,False,True,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void AutosetOffsetsButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("AMBILIGHT(False,False,False,True,)$");
            else
                SendData("AMBILIGHT(False,False,False,True," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void StartAmbilightButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("AMBILIGHT(True,False,False,False,)$");
            else
                SendData("AMBILIGHT(True,False,False,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void StopAmbilightButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("AMBILIGHT(False,True,False,False,)$");
            else
                SendData("AMBILIGHT(False,True,False,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        private void SendConfigButton_Clicked(object sender, EventArgs e)
        {
            if (AmbilightConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("AMBILIGHT(False,False,False,False,)$");
            else
                SendData("AMBILIGHT(False,False,False,False," + AmbilightConfigNamePicker.SelectedItem + ")$");
        }

        string SendData(string _ToSend)
        {
            try
            {
                Stream DataStream = MainMenu.SourceApp.Client.GetStream();
                DataStream.ReadTimeout = 1000;
                DataStream.WriteTimeout = 1000;

                ASCIIEncoding Encodings = new ASCIIEncoding();
                byte[] WriteBytes = Encodings.GetBytes(_ToSend);

                DataStream.Write(WriteBytes, 0, WriteBytes.Length);

                byte[] ReadBytes = new byte[1024];
                int Good = DataStream.Read(ReadBytes, 0, 1024);

                return Encoding.ASCII.GetString(ReadBytes);
            }
            catch
            {
                DisplayAlert("Error", "Error with connection", "OK");
                return "";
            }
        }
    }
}