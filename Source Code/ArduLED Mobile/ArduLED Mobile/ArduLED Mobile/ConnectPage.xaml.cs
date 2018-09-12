using System;
using System.Text;
using Xamarin.Forms;
using System.Net;
using System.Net.Sockets;
using ArduLED_Mobile.Helpers;

namespace ArduLED_Mobile
{
	public partial class ConnectPage : ContentPage
	{
        MainMenuPage MenuPage;

        public ConnectPage(MainMenuPage _MenuPage)
		{
			InitializeComponent();
            MenuPage = _MenuPage;
            if (UserSettings.ConnectionSettingsDefaultIP != "" && UserSettings.ConnectionSettingsDefaultPort != 0)
            {
                IpEntry.Text = UserSettings.ConnectionSettingsDefaultIP;
                PortEntry.Text = UserSettings.ConnectionSettingsDefaultPort.ToString();
            }
        }

        private void ConnectButtonClicked(object sender, EventArgs e)
        {
            if (IpEntry.Text != null && PortEntry.Text != null)
            {
                try
                {
                    MenuPage.IPAddress = IPAddress.Parse(IpEntry.Text);
                    MenuPage.PortNumber = Int32.Parse(PortEntry.Text);
                    MenuPage.SourceApp.Client.Close();
                    MenuPage.SourceApp.Client = new TcpClient();

                    var result = MenuPage.SourceApp.Client.BeginConnect(MenuPage.IPAddress, MenuPage.PortNumber, null, null);

                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                    if (!success)
                    {
                        DisplayAlert("Error","Failed to connect to ip: " + MenuPage.IPAddress + ":" + MenuPage.PortNumber,"OK");
                        throw new Exception("Failed to connect.");
                    }

                    MenuPage.SourceApp.Client.EndConnect(result);

                    NetworkStream DataStream = MenuPage.SourceApp.Client.GetStream();
                    DataStream.ReadTimeout = 1000;
                    byte[] ReadBytes = new byte[1024];
                    DataStream.Read(ReadBytes, 0, 1024);
                    string ClientData = Encoding.ASCII.GetString(ReadBytes);

                    UserSettings.ConnectionSettingsDefaultIP = IpEntry.Text;
                    UserSettings.ConnectionSettingsDefaultPort = MenuPage.PortNumber;

                    MenuPage.ServerIDLabel.Text = "Connected to server: " + ClientData.Split(';')[0];
                    MenuPage.TotalLEDCount = Int32.Parse(ClientData.Split(';')[1]);

                    Navigation.PopModalAsync();
                }
                catch
                {
                    Console.WriteLine("Error in input!");
                }
            }
        }
    }
}