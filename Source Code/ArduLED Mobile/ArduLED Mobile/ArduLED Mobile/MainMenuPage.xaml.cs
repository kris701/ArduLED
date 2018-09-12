using System;
using System.Text;
using Xamarin.Forms;
using System.Net;
using System.Net.Sockets;
using ArduLED_Mobile.Helpers;

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
                    SourceApp.Client.Close();
                    SourceApp.Client = new TcpClient();

                    var result = SourceApp.Client.BeginConnect(IPAddress, PortNumber, null, null);

                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                    if (!success)
                    {
                        DisplayAlert("Error", "Failed to connect to ip: " + IPAddress + ":" + PortNumber, "OK");
                        throw new Exception("Failed to connect.");
                    }

                    SourceApp.Client.EndConnect(result);

                    NetworkStream DataStream = SourceApp.Client.GetStream();
                    DataStream.ReadTimeout = 1000;
                    byte[] ReadBytes = new byte[1024];
                    DataStream.Read(ReadBytes, 0, 1024);
                    string ClientData = Encoding.ASCII.GetString(ReadBytes);
                    ServerIDLabel.Text = "Connected to server: " + ClientData.Split(';')[0];
                    TotalLEDCount = Int32.Parse(ClientData.Split(';')[1]);
                }
                catch
                {
                    Navigation.PushAsync(new NavigationPage(new ConnectPage(this)));
                }
            }
            else
                Navigation.PushAsync(new NavigationPage(new ConnectPage(this)));
        }
    }
}
