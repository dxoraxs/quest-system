using UnityEngine;

namespace QuestSystem.Data
{
    [CreateAssetMenu(fileName = "lillable_object_spawn_config",
        menuName = "Configs/" + nameof(KillableObjectSpawnConfig), order = 0)]
    public class KillableObjectSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public KillableObjectSpawnData[] Spawns { get; private set; }
        [field: SerializeField] public Vector3 AreaSize { get; private set; } = new Vector3(10, 0, 10);
    }
}