using System;

namespace TheOtherRoles.Roles;


public abstract class RoleBase : IDisposable
{
    public RoleInfo RoleInfo { get; protected set; }

    public Type RoleType { get; protected set; }
    
    public RoleControllerBase Controller { get; protected set; }
    
    #nullable enable
    public Type? PathType { get; protected set; }
    #nullable disable

    public virtual bool CanAssign()
    {
        return true;
    }

    public virtual void Dispose()
    {
    }

    public virtual void ClearAndReload()
    {
    }

    public virtual void OptionCreate()
    {
    }

    public virtual void ButtonCreate()
    {
    }

    public virtual void Update()
    {
        
    }

    public virtual void setCustomButtonCoolDownS()
    {
    }
}