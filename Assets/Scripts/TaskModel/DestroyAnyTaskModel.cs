using QuestSystem.GameCore;
using UniRx;
using UnityEngine;

namespace QuestSystem.TaskModel
{
    public class DestroyAnyTaskModel : BaseTaskModel
    {
        protected readonly int _targetCount;
        protected int _currentCount;

        public DestroyAnyTaskModel(string description, int targetCount) : base(description)
        {
            _targetCount = targetCount;
        }

        public override void Start()
        {
        }

        public override void ReportProgress(TaskReportData _)
        {
            if (_isCompleted.Value)
            {
                return;
            }

            _currentCount++;
            _progress.Value = Mathf.Clamp01((float)_currentCount / _targetCount);

            if (_currentCount >= _targetCount)
            {
                _progress.Value = 1f;
                _isCompleted.Value = true;
            }
        }
    }
}