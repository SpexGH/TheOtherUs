using System;
using System.IO;
using Csv;

namespace TheOtherRoles.Modules.Languages;

public class CsvLoader : LanguageLoaderBase
{
    public CsvLoader()
    {
        Filter = [".csv", ".Csv"];
    }
    
    public override void Load(LanguageManager _manager, Stream stream, string FileName)
    {
        var options = new CsvOptions
        {
            HeaderMode = HeaderMode.HeaderPresent,
            AllowNewLineInEnclosedFieldValues = false,
        };
        foreach (var line in CsvReader.ReadFromStream(stream, options))
        {
            if (line.Values[0][0] == '#') continue;
            try
            {
                for (var i = 1; i < line.ColumnCount; i++)
                {
                    _manager.AddToMap(line.Headers[i].PareIndexToLangId(), line.Values[0], line.Values[i]);
                }
            }
            catch (Exception ex)
            {
                Exception(ex);
            }
        }
    }
}