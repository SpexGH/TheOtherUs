using System.IO;

namespace TheOtherRoles.Modules.Languages;

public abstract class LanguageLoaderBase
{
    public string[] Filter { get; protected set; }
    
    public abstract void Load(LanguageManager _manager, Stream stream, string FileName);
}