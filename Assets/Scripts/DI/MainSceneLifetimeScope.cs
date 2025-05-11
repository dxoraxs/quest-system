using QuestSystem.Data;
using QuestSystem.DI.Factories;
using QuestSystem.GameCore;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<VContainerFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.RegisterInstance(_taskConfigList);
            builder.RegisterInstance(_visualSet);
            builder.RegisterInstance(_spawnConfig);
            builder.RegisterInstance(_spawnContainer);
            
            builder.RegisterEntryPoint<GameTimerService>().As<IGameTimerService>();
            builder.Register<KillableObjectRegistry>(Lifetime.Singleton);
            builder.Register<KillableObjectFactory>(Lifetime.Singleton);
            builder.Register<KillableObjectSpawner>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameController>();
        }
    }
}