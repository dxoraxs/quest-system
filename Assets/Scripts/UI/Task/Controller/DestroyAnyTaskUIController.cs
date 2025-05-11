using QuestSystem.TaskModel;
using QuestSystem.UI.Views;

namespace QuestSystem.UI.Controllers
{
    public class DestroyAnyTaskUIController : BaseTaskUIController<DestroyAnyTaskModel>
    {
        public DestroyAnyTaskUIController(DestroyAnyTaskModel model, TaskUIView view)
            : base(model, view) { }

        protected override string Description => base.Description.Replace("{0}", _model.TargetCount.ToString());
    }
}