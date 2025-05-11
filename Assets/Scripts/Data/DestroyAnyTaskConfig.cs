using UnityEngine;

namespace QuestSystem.Data
{
    [CreateAssetMenu(fileName = "destroy_any_task_config",
        menuName = "Configs/Tasks/" + nameof(DestroyAnyTaskConfig), order = 0)]
    public class DestroyAnyTaskConfig : BaseTaskConfig
    {
        [field: SerializeField] public int TargetAmount { get; private set; }
    }
}