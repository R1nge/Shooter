using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct RotationComponent : IComponent
    {
        public Transform transform;
    }
}