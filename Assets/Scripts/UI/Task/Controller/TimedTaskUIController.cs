using QuestSystem.TaskModel;
using QuestSystem.UI.Views;
using UnityEngine;

namespace QuestSystem.UI.Controllers
{
    public class TimedTaskUIController : BaseTaskUIController<TimedTaskModel>
    {
        public TimedTaskUIController(TimedTaskModel model, TaskUIView view)
            : base(model, view) { }

        protected override string Description =>
            base.Description.Replace("{0}", Mathf.RoundToInt(_model.TargetDurationSeconds).ToString());
    }
}