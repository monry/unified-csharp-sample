using System.Threading;
using Cysharp.Threading.Tasks;
using Monry.UnifiedCSharpSample.Model;

namespace Monry.Sample.Client.Repository
{
    public class StubRepository : IRepository
    {
        public UniTask<Player> FetchPlayerAsync(CancellationToken cancellationToken = default)
        {
            return UniTask.FromResult(new Player("Player", 1, 100));
        }
    }
}
