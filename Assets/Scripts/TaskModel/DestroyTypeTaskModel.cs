using QuestSystem.GameCore;
using UniRx;

namespace QuestSystem.TaskModel
{
    public class DestroyTypeTaskModel : DestroyAnyTaskModel
    {
        private readonly ObjectType _targetType;

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