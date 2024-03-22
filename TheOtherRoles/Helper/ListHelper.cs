using System;
using Il2CppSystem.Collections.Generic;

namespace TheOtherRoles.Helper;

public static class ListHelper
{
    public static Random rnd { get; } = new((int)DateTime.Now.Ticks);

    public static T Get<T>(this List<T> list, int index)
    {
        return list._items[index];
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