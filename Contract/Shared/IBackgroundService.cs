using System.Threading;
using System.Threading.Tasks;

namespace Safehaus.IntranetGaming.Contract.Shared
{
    public interface IBackgroundService
    {
        Task Run();
    }
}
