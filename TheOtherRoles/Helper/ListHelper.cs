using System;
using System.Linq;
using Il2CppSystem.Collections.Generic;

namespace TheOtherRoles.Helper;

public static class ListHelper
{
    public static T Get<T>(this Il2CppSystem.Collections.Generic.List<T> list, int index) => list._items[index];
    
    public static Random rnd { get; } = new((int)DateTime.Now.Ticks);
    

    public static List<T> ToIl2cppList<T>(this System.Collections.Generic.List<T> list)
    {
        var il2cpList = new List<T>();
        foreach (var value in list)
        {
            il2cpList.Add(value);
        }
        return il2cpList;
    }


    public static T Random<T>(this List<T> list)
    {
        return list.Get(rnd.Next(list.Count - 1));
    }

    public static T Random<T>(this List<T> list, int Max)
    {
        return list.Get(rnd.Next(Max));
    }

    public static T Random<T>(this List<T> list, int Min, int Max)
    {
        return list.Get(rnd.Next(Min, Max));
    }

    public static T Random<T>(this System.Collections.Generic.List<T> list)
    {
        return list[rnd.Next(list.Count - 1)];
    }

    public static T Random<T>(this System.Collections.Generic.List<T> list, int Max)
    {
        return list[rnd.Next(Max)];
    }

    public static T Random<T>(this System.Collections.Generic.List<T> list, int Min, int Max)
    {
        return list[rnd.Next(Min, Max)];
    }
    
    public static IOrderedEnumerable<T> RandomSort<T>(this System.Collections.Generic.IEnumerable<T> list)
    {
        return list.OrderBy(n => Guid.NewGuid());
    }

    public static int Random(int Min, int Max)
    {
        return rnd.Next(Min, Max);
    }

    public static int Random(int Max)
    {
        return rnd.Next(Max);
    }

    public static int Random()
    {
        return rnd.Next();
    }
}