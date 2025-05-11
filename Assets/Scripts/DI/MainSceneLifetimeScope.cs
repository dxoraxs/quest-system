using QuestSystem.Data;
using QuestSystem.DI.Factories;
using QuestSystem.GameCore;
using QuestSystem.GameCore.Tasks;
using QuestSystem.Tasks;
using QuestSystem.UI;
using QuestSystem.UI.Task;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace QuestSystem.DI
{
    public class MainSceneLifetimeScope : LifetimeScope
    {
        [SerializeField] private TaskConfigList _taskConfigList;
        [SerializeField] private ObjectVisualSet _visualSet;
        [SerializeField] private KillableObjectSpawnConfig _spawnConfig;
        [SerializeField] private KillableObjectSpawnContainer _spawnContainer;
        [SerializeField] private TaskViewContainer _taskViewContainer;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<VContainerFactory>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterInstance(_taskConfigList);
            builder.RegisterInstance(_visualSet);
            builder.RegisterInstance(_spawnConfig);
            builder.RegisterInstance(_spawnContainer);
            builder.RegisterInstance(_taskViewContainer);

            builder.RegisterEntryPoint<GameTimerService>().As<IGameTimerService>();

            builder.Register<KillableObjectRegistry>(Lifetime.Singleton);
            builder.Register<KillableObjectFactory>(Lifetime.Singleton);
            builder.Register<KillableObjectSpawner>(Lifetime.Singleton);

            builder.Register<TaskFactory>(Lifetime.Singleton);
            builder.Register<TaskManager>(Lifetime.Singleton);
            builder.Register<TaskInstaller>(Lifetime.Singleton);
            builder.Register<TaskUIFactory>(Lifetime.Singleton);

            builder.Register<TaskViewsController>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GameController>();
        }
    }
}