using QuestSystem.GameCore;
using UniRx;
using UnityEngine.Scripting;

namespace QuestSystem.TaskModel
{
    public class DestroyTypeTaskModel : DestroyAnyTaskModel
    {
        private readonly ObjectType _targetType;

        [Preserve]
        public DestroyTypeTaskModel(string description, ObjectType targetType, int targetCount)
            : base(description, targetCount)
        {
            _targetType = targetType;
        }

        public override void ReportProgress(TaskReportData taskReportData)
        {
            if (_isCompleted.Value)
            {
                return;
            }
            if (taskReportData.ObjectType != _targetType)
            {
                return;
            }

            base.ReportProgress(taskReportData);
        }
    }

}