using Monry.Sample.Client.Presenter;
using Monry.Sample.Client.Repository;
using Monry.Sample.Client.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Monry.Sample.Client.LifetimeScope
{
    public class SampleLifetimeScope : VContainer.Unity.LifetimeScope
    {
        [SerializeField] private bool useStub;
        [SerializeField] private PlayerView playerViewPrefab = default!;
        [SerializeField] private EnemyView enemyViewPrefab = default!;
        [SerializeField] private PortionView portionViewPrefab = default!;
        [SerializeField] private Transform playerParent = default!;
        [SerializeField] private Transform spawner = default!;

        protected override void Configure(IContainerBuilder builder)
        {
            if (useStub)
            {
                builder.Register<IRepository, StubRepository>(Lifetime.Scoped);
            }
            else
            {
                builder.Register<IRepository, SampleRepository>(Lifetime.Scoped);
            }
            builder.RegisterInstance(playerViewPrefab);
            builder.RegisterInstance(enemyViewPrefab);
            builder.RegisterInstance(portionViewPrefab);
            builder.RegisterEntryPoint<SamplePresenter>()
                .WithParameter(nameof(playerParent), playerParent)
                .WithParameter(nameof(spawner), spawner);
        }
    }
}
