using System;
using System.Collections.Generic;
using System.Linq;
using TheOtherRoles.Modules;

namespace TheOtherRoles.Roles;

public class CustomRoleManager : ManagerBase<CustomRoleManager>
{
    public readonly List<RoleBase> _RoleBases = [];

    public void Register(RoleBase role)
    {
        _RoleBases.Add(role);
    }

    public T Get<T>() where T : RoleBase => _RoleBases.FirstOrDefault(n => n is T) as T;

    public T Get<T>(Type type) where T : RoleBase => _RoleBases.FirstOrDefault(n => n.RoleType == type) as T;
}