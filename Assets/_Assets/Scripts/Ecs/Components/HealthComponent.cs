using System;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct HealthComponent : IComponent
    {
        public float health;
        public float maxHealth;
    }
}