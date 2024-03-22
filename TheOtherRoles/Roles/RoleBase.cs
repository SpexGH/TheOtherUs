using System;

namespace TheOtherRoles.Roles;

public abstract class RoleBase : IDisposable
{

    public RoleInfo RoleInfo { get; protected set; }
    
    public Type RoleType { get; protected set; }
    
    public virtual void ClearAndReload()
    {
        
    }

    public virtual void OptionCreate()
    {
        
    }
    
    public virtual void Dispose()
    {
    }
}