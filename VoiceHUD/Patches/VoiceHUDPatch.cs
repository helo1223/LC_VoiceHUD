using Dissonance;
using HarmonyLib;
using UnityEngine;

namespace VoiceHUD.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class VoiceHUDPatch
    {

        private static Color Start = new(0.0f, 255.0f, 0.0f, 255.0f);
        private static Color Center = new(165.0f, 255.0f, 0.0f, 255.0f);
        private static Color End = new(255.0f, 0.0f, 0.0f, 255.0f);

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
                HUDManager.Instance.PTTIcon.color = GetColorByVolume(detectedAmplitude * 100);
                HUDManager.Instance.PTTIcon.enabled = detectedAmplitude > 0.01f;
            }
        }

        public static Color GetColorByVolume(float volume)
        {
            if (volume < 20)
                return Start;
            else if (volume > 70)
            {
                return End;
            }
            else
                return Center;
        }
    }
}
