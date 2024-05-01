using BepInEx.Unity.IL2CPP.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UnityEngine;
using UnityEngine.Networking;
using static TheOtherRoles.Modules.CustomHats.CustomHatManager;

namespace TheOtherRoles.Modules.CustomHats;

public class HatsLoader : MonoBehaviour
{
    private bool isRunning;

    private static readonly HashSet<string> RepositoryUrls = 
    [
        "https://raw.githubusercontent.com/TheOtherRolesAU/TheOtherHats/master"
    ];

    public void FetchHats()
    {
        if (isRunning) return;
        foreach (var url in RepositoryUrls)
        {
            this.StartCoroutine(CoFetchHats(url.GithubUrl()));
        }
    }

    [HideFromIl2Cpp]
    private IEnumerator CoFetchHats(string RepositoryUrl)
    {
        isRunning = true;
        var www = new UnityWebRequest();
        www.SetMethod(UnityWebRequest.UnityWebRequestMethod.Get);
        Message($"Download manifest at: {RepositoryUrl}/{ManifestFileName}");
        www.SetUrl($"{RepositoryUrl}/{ManifestFileName}");
        www.downloadHandler = new DownloadHandlerBuffer();
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        if (www.isNetworkError || www.isHttpError)
        {
            Error(www.error);
            yield break;
        }

        var response = JsonSerializer.Deserialize<SkinsConfigFile>(www.downloadHandler.text, new JsonSerializerOptions
        {
            AllowTrailingCommas = true
        });
        www.downloadHandler.Dispose();
        www.Dispose();

        if (!Directory.Exists(HatsDirectory)) Directory.CreateDirectory(HatsDirectory);

        UnregisteredHats.AddRange(SanitizeHats(response));
        var toDownload = GenerateDownloadList(UnregisteredHats);

        Message($"I'll download {toDownload.Count} hat files");

        foreach (var fileName in toDownload)
        {
            yield return CoDownloadHatAsset(fileName, RepositoryUrl);
        }

        isRunning = false;
    }

    private static IEnumerator CoDownloadHatAsset(string fileName, string RepositoryUrl)
    {
        var www = new UnityWebRequest();
        www.SetMethod(UnityWebRequest.UnityWebRequestMethod.Get);
        fileName = fileName.Replace(" ", "%20");
        Message($"downloading hat: {fileName}");
        www.SetUrl($"{RepositoryUrl}/hats/{fileName}");
        www.downloadHandler = new DownloadHandlerBuffer();
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        if (www.isNetworkError || www.isHttpError)
        {
            Error(www.error);
            yield break;
        }

        var filePath = Path.Combine(HatsDirectory, fileName);
        filePath = filePath.Replace("%20", " ");
        var persistTask = File.WriteAllBytesAsync(filePath, www.downloadHandler.data);
        while (!persistTask.IsCompleted)
        {
            if (persistTask.Exception != null)
            {
                Error(persistTask.Exception.Message);
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        www.downloadHandler.Dispose();
        www.Dispose();
    }
}