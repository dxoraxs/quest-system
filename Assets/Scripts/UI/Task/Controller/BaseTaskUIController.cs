using System;
using QuestSystem.TaskModel;
using QuestSystem.UI.Views;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace QuestSystem.UI
{
    public interface IBaseTaskUIController : IDisposable
    {
        void Initialize();
    }

    public class BaseTaskUIController<TModel> : IBaseTaskUIController where TModel : BaseTaskModel
    {
        protected readonly TModel _model;
        protected readonly TaskUIView _view;
        private readonly CompositeDisposable _disposables = new();

        protected BaseTaskUIController(TModel model, TaskUIView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _view.SetDescription(Description);

            _model.Progress
                .Subscribe(p => _view.SetProgress(p))
                .AddTo(_disposables);

            _model.IsCompleted
                .Subscribe(done => _view.SetCompleted(done))
                .AddTo(_disposables);
        }

        protected virtual string Description => _model.Description;

        public void Dispose()
        {
            Object.Destroy(_view);
            _disposables.Dispose();
        }
    }
}