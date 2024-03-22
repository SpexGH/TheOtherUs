using System.Threading.Tasks;

namespace TheOtherRoles.Modules;

public class LanguageLoaderBase
{
    public virtual ValueTask Load(LanguageManager _manager)
    {
        return ValueTask.CompletedTask;
    }
}