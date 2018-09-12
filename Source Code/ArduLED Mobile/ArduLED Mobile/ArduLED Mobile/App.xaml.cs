using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Sockets;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArduLED_Mobile
{
    public partial class App : Application
    {
        public TcpClient Client = new TcpClient();

        public App()
        {
            InitializeComponent();

            Client.ReceiveTimeout = 1000;
            Client.SendTimeout = 1000;
        }

        protected override void OnStart()
        {
            MainPage = new NavigationPage(new MainMenuPage(this));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#404040");
        }

        protected override void OnSleep()
        {
            Client.Close();
        }

        protected override void OnResume()
        {
            MainPage = new NavigationPage(new MainMenuPage(this));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#404040");
        }
    }
}
