using QuestSystem.Data;
using QuestSystem.GameCore.Tasks;
using UnityEngine.Scripting;

namespace QuestSystem.Tasks
{
    public class TaskInstaller
    {
        private readonly TaskManager _taskManager;
        private readonly TaskFactory _taskFactory;

        [Preserve]
        public TaskInstaller(TaskManager taskManager, TaskFactory taskFactory)
        {
            _taskManager = taskManager;
            _taskFactory = taskFactory;
        }

        public void Install(TaskConfigList configList)
        {
            var models = _taskFactory.CreateAll(configList);
            _taskManager.AddMany(models);
        }
    }
}