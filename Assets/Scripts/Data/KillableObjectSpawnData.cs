using UnityEngine;

namespace QuestSystem.Data
{
    [System.Serializable]
    public class KillableObjectSpawnData
    {
        [field: SerializeField] public ObjectType Type { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
    }
}