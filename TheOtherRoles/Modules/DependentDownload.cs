using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BepInEx;

namespace TheOtherRoles.Modules;

public class DependentDownload : ManagerBase<DependentDownload>
{
    private readonly HttpClient _client = new();
    private static readonly string DllPath = Path.Combine(Paths.BepInExRootPath, "Dependent");
    
    public async void CheckDependent(string fileName, string url, bool formDownload = true)
    {
        if (AppDomain.CurrentDomain.GetAssemblies().Any(n => n.GetName().Name == fileName))
            return;

        var stream = formDownload ? await DownloadDependent(url) :  await ReadDependent(fileName);
        if (!Directory.Exists(DllPath))
            Directory.CreateDirectory(DllPath);

        var filePath = Path.Combine(DllPath, fileName);
        var file = File.Open(filePath, FileMode.OpenOrCreate);
        await stream.CopyToAsync(file);
        stream.Close();
        file.Close();
        
        Assembly.LoadFile(filePath);
    }

    public async Task<Stream> DownloadDependent(string url)
    {
        var stream = await _client.GetStreamAsync(url);
        return await Task.FromResult(stream);
    }
    
    public async Task<Stream> ReadDependent(string fileName)
    {
        var path = "TheOtherRoles.Resources.Dependent."+ fileName;
        var stream = typeof(DependentDownload).Assembly.GetManifestResourceStream(path);
        return await Task.FromResult(stream);
    }
}