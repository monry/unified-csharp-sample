using System.Threading;
using Cysharp.Threading.Tasks;
using Monry.UnifiedCSharpSample.Model;

namespace Monry.Sample.Client.Repository
{
    public interface IRepository
    {
        UniTask<Player> FetchPlayerAsync(CancellationToken cancellationToken = default);
    }
}
