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
                    if (MenuPage.SourceApp.Client.Client.Connected)
                        MenuPage.SourceApp.Client.Client.Close();

                    MenuPage.IPAddress = IPAddress.Parse(IpEntry.Text);
                    MenuPage.PortNumber = Int32.Parse(PortEntry.Text);
                    MenuPage.SourceApp.Client = new TcpClient();

                    var result = MenuPage.SourceApp.Client.BeginConnect(MenuPage.IPAddress, MenuPage.PortNumber, null, null);

                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                    if (!success)
                    {
                        DisplayAlert("Error", "Failed to connect to ip: " + MenuPage.IPAddress + ":" + MenuPage.PortNumber, "OK");
                        throw new Exception("Failed to connect.");
                    }

                    MenuPage.SourceApp.Client.EndConnect(result);

                    UserSettings.ConnectionSettingsDefaultIP = IpEntry.Text;
                    UserSettings.ConnectionSettingsDefaultPort = Int32.Parse(PortEntry.Text);

                    MenuPage.ReceiveData();

                    MenuPage.SendData("GETTOTALLEDCOUNT()");
                    MenuPage.TotalLEDCount = Int32.Parse(MenuPage.ReceiveData());

                    MenuPage.SendData("GETSERVERNAME()");
                    MenuPage.ServerIDLabel.Text = "Connected to server: " + MenuPage.ReceiveData();

                    Application.Current.MainPage.Navigation.PopAsync();
                }
                catch
                {
                    Console.WriteLine("Error in input!");
                }
            }
        }
    }
}