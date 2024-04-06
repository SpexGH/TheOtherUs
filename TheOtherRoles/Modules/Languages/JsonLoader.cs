using System.IO;
using System.Text.Json;

namespace TheOtherRoles.Modules.Languages;

public class JsonLoader : LanguageLoaderBase
{
    public JsonLoader()
    {
        Filter = [".json", ".Json"];
    }
    
    public override void Load(LanguageManager _manager, Stream stream, string FileName)
    {
        var jsonDocument = JsonDocument.Parse(stream);
        foreach (var element in jsonDocument.RootElement.EnumerateObject())
        {
            var key = element.Name;
            foreach (var obj in element.Value.EnumerateObject())
            {
                var langId = obj.Name.PareIndexToLangId();
                var value = obj.Value.ToString();
                
                _manager.AddToMap(langId, key, value);
            }
        }
    }
}