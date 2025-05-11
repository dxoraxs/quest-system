using System;
using System.Collections.Generic;
using QuestSystem.TaskModel;
using QuestSystem.UI.Controllers;
using QuestSystem.UI.Views;
using UnityEngine.Scripting;

namespace QuestSystem.UI
{
    public class TaskUIFactory
    {
        private readonly Dictionary<Type, Func<BaseTaskModel, TaskUIView, IBaseTaskUIController>> _creators = new();

        [Preserve]
        public TaskUIFactory()
        {
            Register<TimedTaskModel>((model, view) =>
                new TimedTaskUIController(model, view));

            Register<DestroyAnyTaskModel>((model, view) =>
                new DestroyAnyTaskUIController(model, view));

            Register<DestroyTypeTaskModel>((model, view) =>
                new DestroyTypeTaskUIController(model, view));
        }

        public void Register<TModel>(Func<TModel, TaskUIView, IBaseTaskUIController> creator)
            where TModel : BaseTaskModel
        {
            _creators[typeof(TModel)] = (model, view) => creator((TModel)model, view);
        }

        public IBaseTaskUIController Create(BaseTaskModel model, TaskUIView view)
        {
            var type = model.GetType();
            if (_creators.TryGetValue(type, out var creator))
            {
                return creator(model, view);
            }

            throw new ArgumentException($"[TaskUIFactory] No factory registered for {type}");
        }
    }
}