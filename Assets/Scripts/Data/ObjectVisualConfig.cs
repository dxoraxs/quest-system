using System;
using UnityEngine;

namespace QuestSystem.Data
{
    [Serializable]
    public class ObjectVisualConfig
    {
        [field: SerializeField] public ObjectType Type { get; private set; }
        [field: SerializeField] public Material Material { get; private set; }
    }
}