using UnityEngine;

namespace QuestSystem.Data
{
    public abstract class BaseTaskConfig : ScriptableObject
    {
        [field: SerializeField] public string Description { get; private set; }
    }
}