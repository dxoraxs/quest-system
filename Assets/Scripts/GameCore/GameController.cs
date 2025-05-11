using UnityEngine.Scripting;
using VContainer.Unity;

namespace QuestSystem.GameCore
{
    public class GameController : IInitializable
    {
        private readonly KillableObjectSpawner _killableObjectSpawner;
        
        [Preserve]
        public GameController(KillableObjectSpawner killableObjectSpawner)
        {
            _killableObjectSpawner = killableObjectSpawner;
        }
        
        public void Initialize()
        {
            _killableObjectSpawner.SpawnAll();
        }
    }
}