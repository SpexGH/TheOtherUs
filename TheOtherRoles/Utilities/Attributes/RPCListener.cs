using System;

namespace TheOtherRoles.Utilities.Attributes;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class RPCListener : Attribute
{
    
}