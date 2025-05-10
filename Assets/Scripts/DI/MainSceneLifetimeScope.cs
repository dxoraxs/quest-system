using QuestSystem.DI.Factories;
using VContainer;
using VContainer.Unity;

namespace QuestSystem.DI
{
    public class MainSceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<VContainerFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}