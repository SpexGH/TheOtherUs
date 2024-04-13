using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Data.Legacy;
using HarmonyLib;

namespace TheOtherRoles.Modules.Languages;

#nullable enable
public class LanguageManager : ManagerBase<LanguageManager>
{
    private static readonly HashSet<LanguageLoaderBase> DefLoaders = 
    [
        new DataLoader(),
        new JsonLoader(),
        new CsvLoader(),
        new ExcelLoader()
    ];
    private static readonly HashSet<string> DefLanguageFile = [];

    private readonly List<LanguageLoaderBase> _AllLoader = [];
    private readonly Dictionary<SupportedLangs, Dictionary<string, string>> StringMap = [];
    internal SupportedLangs? CurrentLang;
    private bool Loaded;
    private const string ResourcePath = "TheOtherRoles.Resources.Languages.";
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();
    
    public LanguageManager()
    {
        _AllLoader.AddRange(DefLoaders);
    }

    public LanguageLoaderBase? GetLoader(string extensionName) =>
        _AllLoader.FirstOrDefault(n => n.Filter.Contains(extensionName));

    private bool TryGetResourceFile(string Path, out Stream? stream)
    {
        stream = null;
        if (!_assembly.GetManifestResourceNames().Contains(Path))
            return false;
        
        stream = _assembly.GetManifestResourceStream(Path);

        return true;
    }

    private void Load()
    {
        foreach (var FileName in DefLanguageFile)
        {
            var extension = Path.GetExtension(FileName);
            var Loader = GetLoader(extension);
            if (Loader == null || !TryGetResourceFile(ResourcePath + FileName, out var stream)) continue;
            Loader.Load(this, stream, FileName);
        }
    }

    public void AddLoader(LanguageLoaderBase _loader)
    {
        _AllLoader.Add(_loader);
    }

    internal void LoadLanguage(string path,bool formResource = true)
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

    internal void AddToMap(SupportedLangs lang,string key, string value) => StringMap[lang][key] = value;

    internal string GetString(string Key)
    {
        if (!Loaded)
            LoadLanguage();

        if (CurrentLang == null)
            goto NullString;
        
        var lang = (SupportedLangs)CurrentLang;
        if (!StringMap.ContainsKey(lang))
            goto NullString;
        
        var langMap = StringMap[lang];
        if (!langMap.ContainsKey(Key))
            goto NullString;

        return langMap[Key];
        
        NullString:
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