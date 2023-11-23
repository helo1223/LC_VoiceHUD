using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using VoiceHUD.Patches;

namespace VoiceHUD
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class VoiceHUD : BaseUnityPlugin
    {
        private const string modGUID = "5Bit.VoiceHUD";
        private const string modName = "VoiceHUD";
        private const string modVersion = "1.0.2";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static VoiceHUD Instance;

        internal static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            harmony.PatchAll();
        }
    }


}