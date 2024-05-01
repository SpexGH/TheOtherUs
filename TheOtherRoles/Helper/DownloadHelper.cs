using System.Globalization;
using AmongUs.Data.Legacy;
using TheOtherRoles.Modules.Languages;

namespace TheOtherRoles.Helper;

public static class DownloadHelper
{
    public static bool IsCN()
    {
        return RegionInfo.CurrentRegion.ThreeLetterISORegionName == "CHN" 
               || 
               (SupportedLangs)LegacySaveManager.LastLanguage == SupportedLangs.SChinese
               || LanguageManager.Instance.CurrentLang == SupportedLangs.SChinese;
    }

    public static string GithubUrl(this string url)
    {
        if (IsCN() && !url.Contains("github.moeyy.xyz"))
        {
            return url
                .Replace("https://github.com", "https://github.moeyy.xyz/https://github.com")
                .Replace("https://raw.githubusercontent.com", "https://github.moeyy.xyz/https://raw.githubusercontent.com");
        }

        return url;
    }
}