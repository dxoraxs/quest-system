using System;
using System.Collections.Generic;
using QuestSystem.TaskModel;
using UnityEngine.Scripting;

namespace QuestSystem.GameCore
{
    public class KillableObjectRegistry
    {
        public event Action<TaskReportData> OnTaskReport;
        private readonly Dictionary<KillableObject, ObjectType> _objects = new();

        public IEnumerable<KillableObject> All => _objects.Keys;

        [Preserve]
        public KillableObjectRegistry()
        {
        }

        public void Register(KillableObject obj, ObjectType type)
        {
            _objects.Add(obj, type);
        }

        public void NotifyKilled(KillableObject obj, ObjectType type)
        {
            _objects.Remove(obj);
            
            var reportData = new TaskReportData(obj,type);
            OnTaskReport?.Invoke(reportData);
        }
    }
}