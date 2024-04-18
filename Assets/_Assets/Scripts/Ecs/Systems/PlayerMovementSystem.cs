using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerMovementSystem))]
    public sealed class PlayerMovementSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _filter = World.Filter
                .With<CharacterControllerMoveComponent>()
                .With<InputComponent>()
                .With<PlayerRotationComponent>().Build();

            foreach (var entity in _filter)
            {
                var input = entity.GetComponent<InputComponent>();
                var move = entity.GetComponent<CharacterControllerMoveComponent>();
                var moveX = Mathf.Clamp(input.directionX, -1, 1);
                var moveY = Mathf.Clamp(move.directionY, -1, 1);
                var moveZ = Mathf.Clamp(input.directionZ, -1, 1);
                var direction = new Vector3(moveX, moveY, moveZ);
                
                var forward = move.characterController.transform.TransformDirection(Vector3.forward);
                var right = move.characterController.transform.TransformDirection(Vector3.right);
                var facingDirection = forward * direction.z + right * direction.x;

                move.characterController.Move(facingDirection * move.speed * deltaTime);
            }
        }
    }
}