using QuestSystem.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

namespace QuestSystem.GameCore
{
    public class KillableObjectFactory
    {
        private readonly ObjectVisualSet _visualSet;
        private readonly KillableObjectRegistry _registry;
        private readonly Transform _transformParent;

        [Preserve]
        public KillableObjectFactory(ObjectVisualSet visualSet, KillableObjectRegistry registry, KillableObjectSpawnContainer transformParent)
        {
            _visualSet = visualSet;
            _registry = registry;
            _transformParent = transformParent.ObjectParent;
        }

        public void Spawn(Vector3 position, ObjectType type)
        {
            var config = _visualSet.GetConfig(type);
            var killable = Object.Instantiate(_visualSet.Prefab, position, Quaternion.identity, _transformParent);

            killable.Setup(config.Material);

            _registry.Register(killable, type);

            killable.OnKilled += () => _registry.NotifyKilled(killable, type);
        }
    }
}