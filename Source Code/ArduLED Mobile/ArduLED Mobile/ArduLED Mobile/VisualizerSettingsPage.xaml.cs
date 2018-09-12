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

            string Response = SendData("GETVISUALIZERCONFIGS()$");

            VisualizerConfigNamePicker.Items.Clear();
            VisualizerConfigNamePicker.Items.Add("None");
            VisualizerConfigNamePicker.SelectedIndex = 0;
            foreach (string Config in Response.Split(';'))
            {
                VisualizerConfigNamePicker.Items.Add(Config);
            }
            VisualizerConfigNamePicker.Items.RemoveAt(VisualizerConfigNamePicker.Items.Count - 1);
        }

        private void StartVisualizerButton_Clicked(object sender, EventArgs e)
        {
            if (VisualizerConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("VISUALIZER(True,False,)$");
            else
                SendData("VISUALIZER(True,False," + VisualizerConfigNamePicker.SelectedItem + ")$");
        }

        private void StopVisualizerButton_Clicked(object sender, EventArgs e)
        {
            if (VisualizerConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("VISUALIZER(False,True,)$");
            else
                SendData("VISUALIZER(False,True," + VisualizerConfigNamePicker.SelectedItem + ")$");
        }

        private void SendConfigButton_Clicked(object sender, EventArgs e)
        {
            if (VisualizerConfigNamePicker.SelectedItem.ToString() == "None")
                SendData("VISUALIZER(False,False,)$");
            else
                SendData("VISUALIZER(False,False," + VisualizerConfigNamePicker.SelectedItem + ")$");
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