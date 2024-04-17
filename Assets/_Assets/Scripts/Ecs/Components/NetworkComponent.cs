using System;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Components
{
    [Serializable]
    public struct NetworkComponent : IComponent
    {
        public ulong netId;
    }
}