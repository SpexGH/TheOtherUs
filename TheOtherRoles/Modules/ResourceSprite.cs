using System.Linq;
using System.Reflection;
using UnityEngine;

namespace TheOtherRoles.Modules;

#nullable enable
public class ResourceSprite(string pathName, float pixel, bool cache = true)
{
    private Sprite? _sprite;
    
    public readonly string _pathName = pathName;

    public readonly float _pixel = pixel;
    
    public readonly bool _cache = cache;
    
    private const string ResourcePath = "TheOtherRoles.Resources.";

    private static Assembly assembly = Assembly.GetExecutingAssembly();
    
    public static implicit operator Sprite(ResourceSprite rs) => rs.GetSprite();
    
    public string Path => GetPath();

    public Sprite GetSprite()
    {
        if (_sprite != null)
            return _sprite;

        _sprite = Helpers.loadSpriteFromResources(GetPath(), _pixel, _cache);
        return _sprite;
    }

    private string GetPath()
    {
        if (assembly.GetManifestResourceNames().Contains(ResourcePath + _pathName))
        {
            return ResourcePath + _pathName;
        }

        return _pathName;
    }
}