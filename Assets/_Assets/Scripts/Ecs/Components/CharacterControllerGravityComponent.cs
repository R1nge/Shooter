using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct CharacterControllerGravityComponent : IComponent
    {
        public CharacterController characterController;
        public float gravity;
        public AnimationCurve animationCurve;
        public float currentTime;
    }
}