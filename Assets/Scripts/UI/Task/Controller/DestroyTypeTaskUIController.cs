using QuestSystem.TaskModel;
using QuestSystem.UI.Views;

namespace QuestSystem.UI.Controllers
{
    public class DestroyTypeTaskUIController : BaseTaskUIController<DestroyTypeTaskModel>
    {
        public DestroyTypeTaskUIController(DestroyTypeTaskModel model, TaskUIView view)
            : base(model, view)
        {
        }

        protected override string Description =>
            base.Description
                .Replace("{0}", _model.TargetCount.ToString())
                .Replace("{1}", _model.TargetType.ToString());
    }
}