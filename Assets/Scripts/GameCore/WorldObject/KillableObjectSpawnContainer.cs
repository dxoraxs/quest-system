using QuestSystem.Data;
using UnityEngine;

namespace QuestSystem.GameCore
{
    public class KillableObjectSpawnContainer : MonoBehaviour
    {
        [field: SerializeField] public Transform ObjectParent { get; private set; }
    }
}