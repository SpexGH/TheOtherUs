using System.Collections.Generic;
using System.Threading.Tasks;
using AmongUs.Data.Legacy;
using HarmonyLib;

namespace TheOtherRoles.Modules;

public class LanguageManager : ManagerBase<LanguageManager>
{
    internal SupportedLangs? CurrentLang;
    private bool Loaded;

    private List<LanguageLoaderBase> _AllLoader = [];

    private static readonly HashSet<LanguageLoaderBase> DefLoaders = new()
    {

    };

    private async void Load()
    {
        foreach (var _loader in DefLoaders)
        {
            if (_AllLoader.Contains(_loader))
                continue;
            
            await _loader.Load(this);
            _AllLoader.Add(_loader);
        }
    }

    internal void LoadLanguage(LanguageLoaderBase loader)
    {
    }

    internal void ReLoadLanguage()
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
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.Initialize))]
    [HarmonyPostfix]
    private static void OnTranslationController_Initialize(TranslationController __instance)
    {
        LanguageManager.Instance.CurrentLang = __instance.currentLanguage.languageID;
        LanguageManager.Instance.LoadLanguage();
    }

    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.SetLanguage))]
    [HarmonyPrefix]
    private static void OnTranslationController_SetLanguage([HarmonyArgument(0)] TranslatedImageSet lang)
    {
        LanguageManager.Instance.CurrentLang = lang.languageID;
    }

    internal static string Translate(this string key)
    {
        return LanguageManager.Instance.GetString(key);
    }
}