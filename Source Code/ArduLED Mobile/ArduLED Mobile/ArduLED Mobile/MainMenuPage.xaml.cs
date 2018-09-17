using System;
using System.Text;
using Xamarin.Forms;
using System.Net;
using System.Net.Sockets;
using ArduLED_Mobile.Helpers;
using System.IO;
using System.Threading;

namespace ArduLED_Mobile
{
    public partial class MainMenuPage : ContentPage
    {
        public IPAddress IPAddress = IPAddress.Parse("127.0.0.1");

        public App SourceApp;

        public int PortNumber = 8888;

        public int TotalLEDCount = 0;

        public MainMenuPage(App _SourceApp)
        {
            InitializeComponent();

            SourceApp = _SourceApp;

            AutoReconnect();
        }

        private void FadeColorsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new FadeColorsPage(this)));
        }

        private void ConnectionSettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new ConnectPage(this)));
        }

        private void IndividualColorsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new IndividualLEDPage(this)));
        }

        private void VisualizerSettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new VisualizerSettingsPage(this)));
        }

        private void AmbilightSettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new AmbilightSettingsPage(this)));
        }

        private void AnimationsSettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new AnimationSettingsPage(this)));
        }

        private void InstructionsSettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new InstructionsPage(this)));
        }

        public void AutoReconnect()
        {
            if (UserSettings.ConnectionSettingsDefaultIP != "" && UserSettings.ConnectionSettingsDefaultPort != 0)
            {
                try
                {
                    if (SourceApp.Client.Connected)
                        SourceApp.Client.Close();

                    IPAddress = IPAddress.Parse(UserSettings.ConnectionSettingsDefaultIP);
                    PortNumber = UserSettings.ConnectionSettingsDefaultPort;
                    SourceApp.Client = new TcpClient();

                    var result = SourceApp.Client.BeginConnect(IPAddress, PortNumber, null, null);

                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                    if (!success)
                    {
                        DisplayAlert("Error", "Failed to connect to ip: " + IPAddress + ":" + PortNumber, "OK");
                        throw new Exception("Failed to connect.");
                    }

                    SourceApp.Client.EndConnect(result);

                    ReceiveData();

                    SendData("GETTOTALLEDCOUNT()");
                    TotalLEDCount = Int32.Parse(ReceiveData());

                    SendData("GETSERVERNAME()");
                    ServerIDLabel.Text = "Connected to server: " + ReceiveData();
                }
                catch
                {
                    Navigation.PushAsync(new NavigationPage(new ConnectPage(this)));
                }
            }
            else
                Navigation.PushAsync(new NavigationPage(new ConnectPage(this)));
        }

        public void SendData(string _ToSend)
        {
            try
            {
                ASCIIEncoding Encodings = new ASCIIEncoding();
                Stream DataStream = SourceApp.Client.GetStream();
                DataStream.WriteTimeout = 1000;
                byte[] WriteBytes = Encodings.GetBytes(_ToSend + "$");
                DataStream.Write(WriteBytes, 0, WriteBytes.Length);
                DataStream = SourceApp.Client.GetStream();
            }
            catch
            {
                DisplayAlert("Error", "Error with connection!", "OK");
            }
        }

        public string ReceiveData()
        {
            try
            { 
                Stream DataStream = SourceApp.Client.GetStream();
                DataStream.ReadTimeout = 1000;
                byte[] ReadBytes = new byte[1024];
                DataStream.Read(ReadBytes, 0, 1024);
                string[] Out = Encoding.ASCII.GetString(ReadBytes).Split('\0');
                return Out[0];
            }
            catch
            {
                DisplayAlert("Error", "Error with connection!", "OK");
                return "Null";
            }
        }
    }
}
