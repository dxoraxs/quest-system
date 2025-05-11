using System;
using System.Collections.Generic;
using QuestSystem.GameCore.Tasks;
using QuestSystem.TaskModel;
using UniRx;
using UnityEngine;
using UnityEngine.Scripting;
using Object = UnityEngine.Object;

namespace QuestSystem.UI.Task
{
    public class TaskViewsController
    {
        private readonly TaskManager _taskManager;
        private readonly TaskViewContainer _taskViewContainer;
        private readonly TaskUIFactory _taskUIFactory;
        private readonly CompositeDisposable _disposables = new ();
        private readonly Dictionary<BaseTaskModel, IBaseTaskUIController> _controllers = new();

        [Preserve]
        public TaskViewsController(TaskManager taskManager, TaskViewContainer taskViewContainer, TaskUIFactory taskUIFactory)
        {
            _taskManager = taskManager;
            _taskViewContainer = taskViewContainer;
            _taskUIFactory = taskUIFactory;

            Debug.Log("Subscribe to task view container");
            _taskManager.TasksStream.ObserveAdd().Subscribe(OnAddNewTask).AddTo(_disposables);
            _taskManager.TasksStream.ObserveRemove().Subscribe(OnRemoveTask).AddTo(_disposables);
        }

        private void OnAddNewTask(CollectionAddEvent<BaseTaskModel> addEvent)
        {
            Debug.Log($"OnAddNewTask {addEvent.Value.GetType()}");
            var model = addEvent.Value;
            CreateNewController(model);
        }

        private void CreateNewController(BaseTaskModel model)
        {
            var view = Object.Instantiate(_taskViewContainer.TaskViewPrefab, _taskViewContainer.TaskViewParent);
            
            var controller = _taskUIFactory.Create(model, view);
            controller.Initialize();

            _controllers[model] = controller;
        }

        private void OnRemoveTask(CollectionRemoveEvent<BaseTaskModel> removeEvent)
        {
            Debug.Log($"OnRemoveTask {removeEvent.Value.GetType()}");
            var controller = _controllers[removeEvent.Value];
            controller.Dispose();
            _controllers.Remove(removeEvent.Value);
        }
    }
}