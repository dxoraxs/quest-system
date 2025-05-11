using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace QuestSystem.GameCore
{
    public class GameTimerService : IInitializable, IGameTimerService
    {
        private readonly List<ITickable> _tickables = new();
        private bool _isRunning;

        public void Register(ITickable tickable)
        {
            _tickables.Add(tickable);
        }

        private async UniTaskVoid Run()
        {
            while (_isRunning)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));

                foreach (var t in _tickables)
                    t.Tick();
            }
        }

        public void Stop() => _isRunning = false;
        
        public void Initialize()
        {
            if (_isRunning) return;
            _isRunning = true;
            Run().Forget();
        }
    }
}