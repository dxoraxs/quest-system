using System.Linq;
using QuestSystem.GameCore;
using UnityEngine;

namespace QuestSystem.Data
{
    [CreateAssetMenu(fileName = "object_visual_set",
        menuName = "Configs/" + nameof(ObjectVisualSet), order = 0)]
    public class ObjectVisualSet : ScriptableObject
    {
        [field: SerializeField] public KillableObject Prefab { get; private set; }
        [field: SerializeField] public ObjectVisualConfig[] Configs { get; private set; }

        public ObjectVisualConfig GetConfig(ObjectType type)
        {
            return Configs.FirstOrDefault(c => c.Type == type);
        }
    }
}