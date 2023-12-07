using System.Threading;
using Cysharp.Threading.Tasks;
using Monry.UnifiedCSharpSample.Model;

namespace Monry.Sample.Client.Repository
{
    public class SampleRepository : IRepository
    {
        public UniTask<Player> FetchPlayerAsync(CancellationToken cancellationToken = default)
        {
            // サーバから取得するとか
            throw new System.NotImplementedException();
        }
    }
}
