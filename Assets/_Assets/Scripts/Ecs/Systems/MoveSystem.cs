using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh.Systems;
using Unity.Netcode;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MoveSystem))]
    public sealed class MoveSystem : UpdateSystem
    {
        public World World { get; set; }
        private Filter _moveFilter;


        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            if (NetworkManager.Singleton.IsServer)
            {
                _moveFilter = World.Filter.With<MoveComponent>().Build();
                foreach (var entity in _moveFilter)
                {
                    ref var move = ref entity.GetComponent<MoveComponent>();
                    move.transform.position += new Vector3(move.directionX, move.directionY, move.directionZ) *
                                               move.speed *
                                               deltaTime;

                    Debug.Log("MoveSystem: " + move.transform.position);
                }
            }
        }

    }
}