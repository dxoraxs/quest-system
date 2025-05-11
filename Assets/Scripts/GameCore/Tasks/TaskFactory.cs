using System;
using System.Collections.Generic;
using QuestSystem.Data;
using QuestSystem.DI.Factories;
using QuestSystem.TaskModel;
using UnityEngine.Scripting;

namespace QuestSystem.GameCore.Tasks
{
    public class TaskFactory
    {
        private readonly Dictionary<Type, Func<BaseTaskConfig, BaseTaskModel>> _creators = new();
        private readonly IGameTimerService _gameTimerService;
        
        [Preserve]
        public TaskFactory(IGameTimerService gameTimerService)
        {
            _gameTimerService = gameTimerService;
            Register<DestroyTypeTaskConfig>(cfg =>
                new DestroyTypeTaskModel(cfg.Description, cfg.TargetType, cfg.TargetAmount));

            Register<DestroyAnyTaskConfig>(cfg =>
                new DestroyAnyTaskModel(cfg.Description, cfg.TargetAmount));

            Register<TimedTaskConfig>(CreateTimedTaskModel);
        }

        public List<BaseTaskModel> CreateAll(TaskConfigList configList)
        {
            var result = new List<BaseTaskModel>();
            foreach (var config in configList.Tasks)
            {
                var model = Create(config);
                if (model != null)
                    result.Add(model);
            }

            return result;
        }

        private TimedTaskModel CreateTimedTaskModel(TimedTaskConfig config)
        {
            var timedTaskModel = new TimedTaskModel(config.Description, config.DurationInSeconds);
            _gameTimerService.Register(timedTaskModel);
            return timedTaskModel;
        }

        private void Register<TConfig>(Func<TConfig, BaseTaskModel> createFunc) where TConfig : BaseTaskConfig
        {
            _creators[typeof(TConfig)] = config => createFunc((TConfig)config);
        }

        private BaseTaskModel Create(BaseTaskConfig config)
        {
            if (_creators.TryGetValue(config.GetType(), out var creator))
                return creator(config);

            throw new ArgumentException("Unknown config type");
        }
    }
}