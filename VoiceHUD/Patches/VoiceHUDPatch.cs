using Dissonance;
using HarmonyLib;

namespace VoiceHUD.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class VoiceHUDPatch
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void Update()
        {
            if (!IngamePlayerSettings.Instance.settings.micEnabled || IngamePlayerSettings.Instance.settings.pushToTalk) 
                return;

            if ((UnityEngine.Object)StartOfRound.Instance.voiceChatModule == (UnityEngine.Object)null)
                return;
            VoicePlayerState player = StartOfRound.Instance.voiceChatModule.FindPlayer(StartOfRound.Instance.voiceChatModule.LocalPlayerName);
            HUDManager.Instance.PTTIcon.enabled = player.IsSpeaking;
        }
    }
}
