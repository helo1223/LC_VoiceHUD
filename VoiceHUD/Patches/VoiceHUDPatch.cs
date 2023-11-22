using Dissonance;
using HarmonyLib;
using UnityEngine;

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

            if (StartOfRound.Instance.voiceChatModule == null)
                return;
            VoicePlayerState player = StartOfRound.Instance.voiceChatModule.FindPlayer(StartOfRound.Instance.voiceChatModule.LocalPlayerName);
            if (player.IsSpeaking)
            {
                float detectedAmplitude = Mathf.Clamp(player.Amplitude * 35f, 0.0f, 1f);
                HUDManager.Instance.PTTIcon.enabled = detectedAmplitude > 0.01f;
            }
        }
    }
}
