using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct TransformMoveComponent : IComponent
    {
        public Transform transform;
        public float speed;
        public float directionX;
        public float directionY;
        public float directionZ;
    }
}