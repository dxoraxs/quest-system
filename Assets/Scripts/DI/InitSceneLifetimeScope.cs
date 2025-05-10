using QuestSystem.Initialization;
using VContainer;
using VContainer.Unity;

namespace QuestSystem.DI
{
    public class InitSceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<InitializationController>();
        }
    }
}