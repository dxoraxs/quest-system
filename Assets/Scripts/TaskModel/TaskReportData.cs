using QuestSystem.GameCore;

namespace QuestSystem.TaskModel
{
    public struct TaskReportData
    {
        public readonly KillableObject KillableObject;
        public readonly ObjectType ObjectType;

        public TaskReportData(KillableObject killableObject, ObjectType objectType)
        {
            KillableObject = killableObject;
            ObjectType = objectType;
        }
    }
}