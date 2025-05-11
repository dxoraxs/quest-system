using System;
using UnityEngine;

namespace QuestSystem.GameCore
{
    [RequireComponent(typeof(Collider)), RequireComponent(typeof(MeshRenderer))]
    public class KillableObject : MonoBehaviour
    {
        public event Action OnKilled;
        [SerializeField] private MeshRenderer _renderer;

        public void Setup(Material material)
        {
            _renderer.material = material;
        }
        
        private void OnMouseDown()
        {
            Kill();
        }

        public void Kill()
        {
            OnKilled?.Invoke();
            Destroy(gameObject);
        }
    }
}