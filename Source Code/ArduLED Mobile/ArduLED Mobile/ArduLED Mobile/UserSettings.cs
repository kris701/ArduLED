using Plugin.Settings;  
using Plugin.Settings.Abstractions;

namespace ArduLED_Mobile.Helpers
{
    /// <summary>  
    /// This is the Settings static class that can be used in your Core solution or in any  
    /// of your client applications. All settings are laid out the same exact way with getters  
    /// and setters.   
    /// </summary>  
    public static class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string ConnectionSettingsDefaultIP
        {
            get => AppSettings.GetValueOrDefault(nameof(ConnectionSettingsDefaultIP), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ConnectionSettingsDefaultIP), value);
        }

        public static int ConnectionSettingsDefaultPort
        {
            get => AppSettings.GetValueOrDefault(nameof(ConnectionSettingsDefaultPort), 0);
            set => AppSettings.AddOrUpdateValue(nameof(ConnectionSettingsDefaultPort), value);
        }

        public static int IndividualPinID
        {
            get => AppSettings.GetValueOrDefault(nameof(IndividualPinID), -1);
            set => AppSettings.AddOrUpdateValue(nameof(IndividualPinID), value);
        }
        public static int InvididualHardwareID
        {
            get => AppSettings.GetValueOrDefault(nameof(InvididualHardwareID), -1);
            set => AppSettings.AddOrUpdateValue(nameof(InvididualHardwareID), value);
        }
        public static int IndividualRedSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(IndividualRedSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(IndividualRedSliderValue), value);
        }
        public static int IndividualGreenSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(IndividualGreenSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(IndividualGreenSliderValue), value);
        }
        public static int IndividualBlueSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(IndividualBlueSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(IndividualBlueSliderValue), value);
        }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }

    }
}