using QuestSystem.Data;
using QuestSystem.GameCore.Tasks;
using QuestSystem.Tasks;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace QuestSystem.GameCore
{
    public class GameController : IInitializable
    {
        private readonly KillableObjectSpawner _killableObjectSpawner;
        private readonly TaskConfigList _taskConfigList;
        private readonly TaskManager _taskManager;
        private readonly TaskInstaller _taskInstaller;
        
        [Preserve]
        public GameController(KillableObjectSpawner killableObjectSpawner, TaskManager taskManager, TaskInstaller taskInstaller, TaskConfigList taskConfigList)
        {
            _killableObjectSpawner = killableObjectSpawner;
            _taskManager = taskManager;
            _taskInstaller = taskInstaller;
            _taskConfigList = taskConfigList;
        }
        
        public void Initialize()
        {
            _killableObjectSpawner.SpawnAll();
            
            _taskInstaller.Install(_taskConfigList);
        }
    }
}