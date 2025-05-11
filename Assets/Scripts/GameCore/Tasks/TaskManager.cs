using System;
using System.Collections.Generic;
using QuestSystem.TaskModel;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;

namespace QuestSystem.GameCore.Tasks
{
    public class TaskManager
    {
        private readonly ReactiveCollection<BaseTaskModel> _tasks = new();
        private readonly KillableObjectRegistry _killableObjectRegistry; 
        
        public IEnumerable<BaseTaskModel> Tasks => _tasks;
        public IReadOnlyReactiveCollection<BaseTaskModel> TasksStream => _tasks;
        
        [Preserve]
        public TaskManager(KillableObjectRegistry killableObjectRegistry)
        {
            _killableObjectRegistry = killableObjectRegistry;
            _killableObjectRegistry.OnTaskReport += OnTaskReport;
        }
        
        public void Add(BaseTaskModel task)
        {
            _tasks.Add(task);
            task.Start();
        }

        public void AddMany(IEnumerable<BaseTaskModel> tasks)
        {
            foreach (var task in tasks)
                Add(task);
        }

        private void OnTaskReport(TaskReportData data)
        {
            foreach (var taskModel in Tasks)
            {
                taskModel.ReportProgress(data);
            }
        }
    }
}