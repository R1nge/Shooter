using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MoveSystem))]
    public sealed class MoveSystem : UpdateSystem
    {
        private Filter _moveFilter;


        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _moveFilter = World.Filter.With<TransformMoveComponent>().Without<PlayerComponent>().Build();

            foreach (var entity in _moveFilter)
            {
                var move = entity.GetComponent<TransformMoveComponent>();

                var moveX = Mathf.Clamp(move.directionX, -1, 1);
                var moveY = Mathf.Clamp(move.directionY, -1, 1);
                var moveZ = Mathf.Clamp(move.directionZ, -1, 1);

                move.transform.position += new Vector3(moveX, moveY, moveZ) * move.speed * deltaTime;
            }
        }
    }
}