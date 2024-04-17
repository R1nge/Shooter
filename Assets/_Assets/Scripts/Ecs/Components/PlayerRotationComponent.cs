using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct PlayerRotationComponent : IComponent
    {
        public Transform transform;
        public Transform camera;
        public float rotationX;
    }
}