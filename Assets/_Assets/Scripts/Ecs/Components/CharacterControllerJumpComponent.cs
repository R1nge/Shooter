using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct CharacterControllerJumpComponent : IComponent
    {
        public CharacterController characterController;
        public float jumpForce;
        public float jumpDuration;
        public float currentJumpTime;
        public AnimationCurve animationCurve;
        public bool jumped;
    }
}