using QuestSystem.GameCore;
using UniRx;

namespace QuestSystem.TaskModel
{
    public abstract class BaseTaskModel
    {
        protected readonly ReactiveProperty<float> _progress = new(0f);
        protected readonly ReactiveProperty<bool> _isCompleted = new(false);

        public string Description { get; }
        public IReadOnlyReactiveProperty<float> Progress => _progress;
        public IReadOnlyReactiveProperty<bool> IsCompleted => _isCompleted;

        protected BaseTaskModel(string description)
        {
            Description = description;
        }

        public abstract void Start();
        public abstract void ReportProgress(TaskReportData taskReportData);
    }

}