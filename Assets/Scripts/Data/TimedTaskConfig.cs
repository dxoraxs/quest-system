using UnityEngine;

namespace QuestSystem.Data
{
    [CreateAssetMenu(fileName = "timed_task_config", menuName = "Configs/Tasks/" + nameof(TimedTaskConfig),
        order = 0)]
    public class TimedTaskConfig : BaseTaskConfig
    {
        [field: SerializeField] public float DurationInSeconds { get; private set; }
    }
}