using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct MoveComponent : IComponent
    {
        public Transform transform;
        public float speed;
        public float directionX;
        public float directionY;
        public float directionZ;
    }
}