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

        public static int FadeColorsFromIDPickerValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsFromIDPickerValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsFromIDPickerValue), value);
        }

        public static int FadeColorsToIDPickerValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsToIDPickerValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsToIDPickerValue), value);
        }
        public static int FadeColorsRedSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsRedSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsRedSliderValue), value);
        }
        public static int FadeColorsGreenSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsGreenSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsGreenSliderValue), value);
        }
        public static int FadeColorsBlueSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsBlueSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsBlueSliderValue), value);
        }
        public static int FadeColorsFadeSpeedPickerValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsFadeSpeedPickerValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsFadeSpeedPickerValue), value);
        }
        public static int FadeColorsFadeFactorPickerValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsFadeFactorPickerValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsFadeFactorPickerValue), value);
        }

        public static int IndividualPinID
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsToIDPickerValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsToIDPickerValue), value);
        }
        public static int InvididualHardwareID
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsRedSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsRedSliderValue), value);
        }
        public static int IndividualRedSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsGreenSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsGreenSliderValue), value);
        }
        public static int IndividualGreenSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsBlueSliderValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsBlueSliderValue), value);
        }
        public static int IndividualBlueSliderValue
        {
            get => AppSettings.GetValueOrDefault(nameof(FadeColorsFadeSpeedPickerValue), -1);
            set => AppSettings.AddOrUpdateValue(nameof(FadeColorsFadeSpeedPickerValue), value);
        }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }

    }
}