using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AmongUs.GameOptions;
using TheOtherRoles.CustomGameModes;
using TheOtherRoles.Modules;
using TheOtherRoles.Utilities;
using TMPro;
using UnityEngine;

namespace TheOtherRoles.Patches;

[HarmonyPatch]
public static class CredentialsPatch
{
    public static string fullCredentialsVersion =
$@"<size=130%><color=#ff351f>TheOtherUs</color></size> v{TheOtherRolesPlugin.Version.ToString() + (TheOtherRolesPlugin.betaDays > 0 ? "-BETA" : "")}";

    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    internal static class PingTrackerPatch
    {
        private static float DeltaTime;

        static void Postfix(PingTracker __instance)
        {
            DeltaTime += (Time.deltaTime - DeltaTime) * 0.1f;
            var fps = Mathf.Ceil(1f / DeltaTime);
            var PingText = $"<size=80%>Ping: {AmongUsClient.Instance.Ping}ms {(TORMapOptions.showFPS ? $"FPS: {fps}" : "")}</size>";
            __instance.text.SetOutlineThickness(0.01f);
            var position = __instance.GetComponent<AspectPosition>();
            var gameModeText = TORMapOptions.gameMode switch
            {
                CustomGamemodes.HideNSeek => "PingTrackerPatchHns".Translate(),
                CustomGamemodes.Guesser => "PingTrackerPatchGuesser".Translate(),
                CustomGamemodes.PropHunt => "PingTrackerPatchPh".Translate(),
                _ => ""
            };
            gameModeText = string.IsNullOrEmpty(gameModeText) ? "" : cs(Color.yellow, gameModeText) + "\n";
            if (AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started)
            {
                __instance.text.alignment = TextAlignmentOptions.TopRight;
                position.Alignment = AspectPosition.EdgeAlignments.RightTop;
                __instance.text.text = $"<size=130%><color=#ff351f>TheOtherUs</color></size> v{Main.Version.ToString() + (Main.betaDays > 0 ? "-BETA" : "")}\n<size=90%>{gameModeText}{PingText}\n</size>";
                position.DistanceFromEdge = new Vector3(2.7f, 0.1f, 0);
            }
            else
            {
                __instance.text.alignment = TextAlignmentOptions.TopLeft;
                position.Alignment = AspectPosition.EdgeAlignments.LeftTop;
                __instance.text.text = $"{fullCredentialsVersion}\n{gameModeText}{"fullCredentials".Translate()}\n{PingText}";
                position.DistanceFromEdge = new(0.4f, 0.06f);

                try
                {
                    UpdateGameModeText(gameModeText);
                }
                catch { }
            }
            position.AdjustPosition();
        }

        private static void UpdateGameModeText(string gameModeText)
        {
            var GameModeText = GameObject.Find("GameModeText")?.GetComponent<TextMeshPro>();
            GameModeText.text = string.IsNullOrEmpty(gameModeText) 
                ? (GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek 
                    ? "UpdateGameModeText1".Translate() : "UpdateGameModeText2".Translate()) : gameModeText;
            var modeLabel = GameObject.Find("ModeLabel")?.GetComponentInChildren<TextMeshPro>();
            modeLabel.text = "UpdateGameModeText".Translate();
        }
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class LogoPatch
    {
        public static SpriteRenderer renderer;
        public static Sprite bannerSprite;
        public static Sprite horseBannerSprite;
        public static Sprite banner2Sprite;
        private static PingTracker instance;

        public static GameObject motdObject;
        public static TextMeshPro motdText;

        static void Postfix(PingTracker __instance)
        {
            var torLogo = new GameObject("bannerLogo_TOR");
            torLogo.transform.SetParent(GameObject.Find("RightPanel").transform, false);
            torLogo.transform.localPosition = new Vector3(-0.4f, 1f, 5f);

            renderer = torLogo.AddComponent<SpriteRenderer>();
            loadSprites();
            renderer.sprite = loadSpriteFromResources("TheOtherRoles.Resources.Banner.png", 300f);

            instance = __instance;
            loadSprites();
            // renderer.sprite = TORMapOptions.enableHorseMode ? horseBannerSprite : bannerSprite;
            renderer.sprite = EventUtility.isEnabled ? banner2Sprite : bannerSprite;
            var credentialObject = new GameObject("credentialsTOR");
            var credentials = credentialObject.AddComponent<TextMeshPro>();
            credentials.SetText($"v{TheOtherRolesPlugin.Version.ToString() + (TheOtherRolesPlugin.betaDays > 0 ? "-BETA" : "")}\n<size=30f%>\n</size>{"mainMenuCredentials".Translate()}\n<size=30%>\n</size>{"contributorsCredentials".Translate()}");
            credentials.alignment = TextAlignmentOptions.Center;
            credentials.fontSize *= 0.05f;

            credentials.transform.SetParent(torLogo.transform);
            credentials.transform.localPosition = Vector3.down * 1.25f;
            motdObject = new GameObject("torMOTD");
            motdText = motdObject.AddComponent<TextMeshPro>();
            motdText.alignment = TextAlignmentOptions.Center;
            motdText.fontSize *= 0.04f;

            motdText.transform.SetParent(torLogo.transform);
            motdText.enableWordWrapping = true;
            var rect = motdText.gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(5.2f, 0.25f);

            motdText.transform.localPosition = Vector3.down * 2.25f;
            motdText.color = new Color(1, 53f / 255, 31f / 255);
            Material mat = motdText.fontSharedMaterial;
            mat.shaderKeywords = new string[] { "OUTLINE_ON" };
            motdText.SetOutlineColor(Color.white);
            motdText.SetOutlineThickness(0.025f);
        }

        public static void loadSprites()
        {
            if (bannerSprite == null) bannerSprite = loadSpriteFromResources("TheOtherRoles.Resources.Banner.png", 300f);
            if (banner2Sprite == null) banner2Sprite = loadSpriteFromResources("TheOtherRoles.Resources.Banner2.png", 300f);
            if (horseBannerSprite == null) horseBannerSprite = loadSpriteFromResources("TheOtherRoles.Resources.bannerTheHorseRoles.png", 300f);
        }

        public static void updateSprite()
        {
            loadSprites();
            if (renderer != null)
            {
                float fadeDuration = 1f;
                instance.StartCoroutine(Effects.Lerp(fadeDuration, new Action<float>((p) =>
                {
                    renderer.color = new Color(1, 1, 1, 1 - p);
                    if (p == 1)
                    {
                        renderer.sprite = TORMapOptions.enableHorseMode ? horseBannerSprite : bannerSprite;
                        instance.StartCoroutine(Effects.Lerp(fadeDuration, new Action<float>((p) =>
                        {
                            renderer.color = new Color(1, 1, 1, p);
                        })));
                    }
                })));
            }
        }
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.LateUpdate))]
    public static class MOTD
    {
        public static List<string> motds = new();
        private static float timer;
        private static float maxTimer = 5f;
        private static int currentIndex;

        public static void Postfix()
        {
            if (motds.Count == 0)
            {
                timer = maxTimer;
                return;
            }
            if (motds.Count > currentIndex && LogoPatch.motdText != null)
                LogoPatch.motdText.SetText(motds[currentIndex]);
            else return;

            // fade in and out:
            float alpha = Mathf.Clamp01(Mathf.Min(new float[] { timer, maxTimer - timer }));
            if (motds.Count == 1) alpha = 1;
            LogoPatch.motdText.color = LogoPatch.motdText.color.SetAlpha(alpha);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = maxTimer;
                currentIndex = (currentIndex + 1) % motds.Count;
            }
        }

        public static async Task loadMOTDs()
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/TheOtherRolesAU/MOTD/main/motd.txt");
            response.EnsureSuccessStatusCode();
            string motds = await response.Content.ReadAsStringAsync();
            foreach (string line in motds.Split("\n", StringSplitOptions.RemoveEmptyEntries))
            {
                MOTD.motds.Add(line);
            }
        }
    }
}
