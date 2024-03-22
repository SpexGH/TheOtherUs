using System.Collections.Generic;
using TheOtherRoles.Modules;

namespace TheOtherRoles.Roles;

public class CustomRoleManager : ManagerBase<CustomRoleManager>
{
    public List<RoleBase> _RoleBases = [];

    public void Register(RoleBase role)
    {
        _RoleBases.Add(role);
    }
}