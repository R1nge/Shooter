using System;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct InputComponent : IComponent
    {
        public float directionX;
        public float directionY;
        public bool shoot;
        public bool jump;
    }
}