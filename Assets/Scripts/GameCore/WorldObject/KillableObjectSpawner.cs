using QuestSystem.Data;
using UnityEngine;
using UnityEngine.Scripting;

namespace QuestSystem.GameCore
{
    public class KillableObjectSpawner
    {
        private readonly KillableObjectFactory _factory;
        private readonly KillableObjectSpawnConfig _config;

        [Preserve]
        public KillableObjectSpawner(KillableObjectFactory factory, KillableObjectSpawnConfig config)
        {
            _factory = factory;
            _config = config;
        }

        public void SpawnAll()
        {
            foreach (var data in _config.Spawns)
                Spawn(data.Type, data.Count);
        }

        private void Spawn(ObjectType type, int count)
        {
            var area = _config.AreaSize;

            for (var i = 0; i < count; i++)
            {
                var pos = new Vector3(
                    Random.Range(-area.x, area.x),
                    0,
                    Random.Range(-area.z, area.z)
                );

                _factory.Spawn(pos, type);
            }
        }
    }

}