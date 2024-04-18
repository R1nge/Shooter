using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CharacterControllerJumpSystem))]
    public sealed class CharacterControllerJumpSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _filter = World.Filter
                .With<CharacterControllerJumpComponent>()
                .With<InputComponent>()
                .With<CharacterControllerMoveComponent>()
                .Build();

            foreach (var entity in _filter)
            {
                ref var jumpComponent = ref entity.GetComponent<CharacterControllerJumpComponent>();
                var inputComponent = entity.GetComponent<InputComponent>();
                ref var moveComponent = ref entity.GetComponent<CharacterControllerMoveComponent>();

                if (inputComponent.jump && !jumpComponent.jumped && jumpComponent.characterController.isGrounded)
                {
                    jumpComponent.jumped = true;
                }

                if (jumpComponent.jumped && jumpComponent.currentJumpTime < jumpComponent.jumpDuration)
                {
                    var force = jumpComponent.animationCurve.Evaluate(jumpComponent.currentJumpTime /
                                                                      jumpComponent.jumpDuration);
                    moveComponent.directionY = force * jumpComponent.jumpForce * deltaTime;
                    jumpComponent.currentJumpTime += deltaTime;
                }
                else
                {
                    jumpComponent.currentJumpTime = 0f;
                    jumpComponent.jumped = false;
                }
            }
        }
    }
}