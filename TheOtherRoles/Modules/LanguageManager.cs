using System.Threading.Tasks;
using AmongUs.Data.Legacy;
using HarmonyLib;

namespace TheOtherRoles.Modules;

internal class LanguageManager : ManagerBase<LanguageManager>
{
    internal SupportedLangs? CurrentLang;
    private bool Loaded = false;
    
    private async void Load()
    {
        
    }

    internal void LoadLanguage()
    {
        if (Loaded)
            return;

        CurrentLang ??= (SupportedLangs)LegacySaveManager.LastLanguage;
        
        Task.Run(Load);
        Loaded = true;
    }

    internal string GetString(string Key)
    {
        if (!Loaded)
            LoadLanguage();
        
        return $"null {Key}";
    }
}

[Harmony]
internal static class LanguageExtension
{
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.Initialize)), HarmonyPostfix]
    private static void OnTranslationController_Initialize(TranslationController __instance)
    {
        LanguageManager.Instance.CurrentLang = __instance.currentLanguage.languageID;
        LanguageManager.Instance.LoadLanguage();
    }
    
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.SetLanguage)), HarmonyPrefix]
    private static void OnTranslationController_SetLanguage([HarmonyArgument(0)]TranslatedImageSet lang) => 
        LanguageManager.Instance.CurrentLang = lang.languageID;

    internal static string Translate(this string key) => LanguageManager.Instance.GetString(key);
}