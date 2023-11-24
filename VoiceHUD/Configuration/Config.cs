using System.IO;
using BepInEx;
using BepInEx.Configuration;

namespace VoiceHUD.Configuration
{
    internal static class Config
    {
        private const string CONFIG_FILE_NAME = "VoiceHUD.cfg";

        private static ConfigFile config;
        private static ConfigEntry<bool> colorsEnabled;

        public static void Init()
        {
            var filePath = Path.Combine(Paths.ConfigPath, CONFIG_FILE_NAME);
            config = new ConfigFile(filePath, true);
            colorsEnabled = config.Bind("Config", "Colors enabled", false, "Change icon color based on volume.");
        }

        public static bool ColorsEnabled => colorsEnabled.Value;
    }
}
