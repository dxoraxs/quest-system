using UnityEngine;

namespace QuestSystem.Data
{
    [CreateAssetMenu(fileName = "task_config_list", menuName = "Configs/" + nameof(TaskConfigList), order = 0)]
    public class TaskConfigList : ScriptableObject
    {
        [field: SerializeField] public BaseTaskConfig[] Tasks { get; private set; }
    }
}