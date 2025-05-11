using System;
using UniRx;
using Cysharp.Threading.Tasks;
using QuestSystem.GameCore;
using UnityEngine;
using UnityEngine.Scripting;

namespace QuestSystem.TaskModel
{
    public class TimedTaskModel : BaseTaskModel, ITickable
    {
        private readonly float _durationSeconds;
        private float _elapsedSeconds;

        public float TargetDurationSeconds => _durationSeconds;
        
        [Preserve]
        public TimedTaskModel(string description, float durationSeconds) : base(description)
        {
            _durationSeconds = durationSeconds;
        }

        public override void Start()
        {
            _elapsedSeconds = 0;
            _progress.Value = 0f;
            _isCompleted.Value = false;
        }

        public override void ReportProgress(TaskReportData _) { }
        
        public void Tick()
        {
            if (_isCompleted.Value)
            {
                return;
            }
            
            _elapsedSeconds++;
            _progress.Value = Mathf.Clamp01(_elapsedSeconds / _durationSeconds);
            
            Debug.Log($"[TimedTaskModel] quest {_elapsedSeconds} / {_durationSeconds}");

            if (_elapsedSeconds >= _durationSeconds)
            {
                _progress.Value = 1f;
                _isCompleted.Value = true;
            }
        }
    }

}