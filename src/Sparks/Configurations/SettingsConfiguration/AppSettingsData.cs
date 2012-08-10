namespace Sparks.Configurations.SettingsConfiguration
{
    using System.Configuration;

    public static class AppSettingsData
    {
        public static object GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}