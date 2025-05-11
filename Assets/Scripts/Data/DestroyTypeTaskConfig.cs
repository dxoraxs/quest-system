using UnityEngine;

namespace QuestSystem.Data
{
    [CreateAssetMenu(fileName = "destroy_type_task_config",
        menuName = "Configs/Tasks/" + nameof(DestroyTypeTaskConfig), order = 0)]
    public class DestroyTypeTaskConfig : BaseTaskConfig
    {
        [field: SerializeField] public ObjectType TargetType { get; private set; }
        [field: SerializeField] public int TargetAmount { get; private set; }
    }
}