using System;
using System.Collections.Generic;
using System.Linq;

namespace TheOtherRoles.Roles;

public class CustomRoleManager : ManagerBase<CustomRoleManager>
{
    public readonly List<RoleBase> _RoleBases = [];

    public readonly List<RoleBase> _AllActiveRole = [];

    public readonly Dictionary<RoleBase, List<PlayerControl>> PlayerAndRoles = new();

    public RoleBase LocalRoleBase;

    public void Register(RoleBase role)
    {
        _RoleBases.Add(role);
    }

    public T Get<T>() where T : RoleBase
    {
        return _RoleBases.FirstOrDefault(n => n is T) as T;
    }

    public T Get<T>(Type type) where T : RoleBase
    {
        return _RoleBases.FirstOrDefault(n => n.RoleType == type) as T;
    }
}