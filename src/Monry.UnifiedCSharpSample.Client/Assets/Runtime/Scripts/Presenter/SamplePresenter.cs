using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Monry.Sample.Client.Repository;
using Monry.Sample.Client.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Monry.Sample.Client.Presenter
{
    public class SamplePresenter : IAsyncStartable
    {
        public SamplePresenter(
            IRepository repository,
            PlayerView playerViewPrefab,
            EnemyView enemyViewPrefab,
            PortionView portionViewPrefab,
            Transform playerParent,
            Transform spawner,
            IObjectResolver objectResolver
        )
        {
            Repository = repository;
            PlayerViewPrefab = playerViewPrefab;
            EnemyViewPrefab = enemyViewPrefab;
            PortionViewPrefab = portionViewPrefab;
            PlayerParent = playerParent;
            Spawner = spawner;
            ObjectResolver = objectResolver;
        }

        private IRepository Repository { get; }
        private PlayerView PlayerViewPrefab { get; }
        private EnemyView EnemyViewPrefab { get; }
        private PortionView PortionViewPrefab { get; }
        private Transform PlayerParent { get; }
        private Transform Spawner { get; }
        private IObjectResolver ObjectResolver { get; }

        private IScopedObjectResolver GameScope { get; set; }

        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, Application.exitCancellationToken).Token;
            var player = await Repository.FetchPlayerAsync(cancellationToken);
            GameScope = ObjectResolver.CreateScope(builder =>
            {
                builder.RegisterInstance(player);
            });
            GameScope.Instantiate(PlayerViewPrefab, PlayerParent);
            await SpawnAsync(cancellationToken);
        }

        private async UniTask SpawnAsync(CancellationToken cancellationToken = default)
        {
            var prefabs = new MonoBehaviour[]
            {
                EnemyViewPrefab,
                PortionViewPrefab,
            };
            while (!cancellationToken.IsCancellationRequested)
            {
                GameScope.Instantiate(prefabs[Random.Range(0, prefabs.Length)], Spawner);
                await UniTask.Delay(TimeSpan.FromMilliseconds(Random.Range(500, 3000)), cancellationToken: cancellationToken);
            }
        }
    }
}
