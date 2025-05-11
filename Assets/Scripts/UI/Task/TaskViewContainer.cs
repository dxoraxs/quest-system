using QuestSystem.UI.Views;
using UnityEngine;

namespace QuestSystem.UI.Task
{
    public class TaskViewContainer : MonoBehaviour
    {
        [field: SerializeField] public Transform TaskViewParent { get; set; }
        [field: SerializeField] public TaskUIView TaskViewPrefab { get; set; }
    }
}