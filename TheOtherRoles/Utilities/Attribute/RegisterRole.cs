using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using TheOtherRoles.Roles;

namespace TheOtherRoles.Utilities.Attribute;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Class)]
public class RegisterRole(bool isTemplate = false) : System.Attribute
{
    public bool IsTemplate = isTemplate;
    
    public static void Register(Assembly assembly, CustomRoleManager _customRoleManager)
    {
        var types = assembly.GetTypes()
            .Where(n =>
            {
                if (!n.IsSubclassOf(typeof(RoleBase)))
                    return false;

                var attribute = n.GetCustomAttribute<RegisterRole>();

                if (attribute == null)
                    return false;

                if (attribute.IsTemplate)
                    return false;

                return true;
            });

        foreach (var _type in types) _customRoleManager.Register((RoleBase)AccessTools.CreateInstance(_type));
    }
}