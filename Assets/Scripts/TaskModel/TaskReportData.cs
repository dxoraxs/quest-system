using QuestSystem.GameCore;
using UnityEngine.Scripting;

namespace QuestSystem.TaskModel
{
    public struct TaskReportData
    {
        public readonly KillableObject KillableObject;
        public readonly ObjectType ObjectType;

        [Preserve]
        public TaskReportData(KillableObject killableObject, ObjectType objectType)
        {
            KillableObject = killableObject;
            ObjectType = objectType;
        }
    }
}