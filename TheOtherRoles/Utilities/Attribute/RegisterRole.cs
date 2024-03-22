using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using TheOtherRoles.Roles;

namespace TheOtherRoles.Utilities.Attribute;

[UsedImplicitly]
[AttributeUsage(AttributeTargets.Class)]
public class RegisterRole : System.Attribute
{
    public static void Register(Assembly assembly, CustomRoleManager _customRoleManager)
    {
        var types = assembly.GetTypes()
            .Where(n => n.IsSubclassOf(typeof(RoleBase)) && n.IsDefined(typeof(RegisterRole)));

        foreach (var _type in types) _customRoleManager.Register((RoleBase)AccessTools.CreateInstance(_type));
    }
}