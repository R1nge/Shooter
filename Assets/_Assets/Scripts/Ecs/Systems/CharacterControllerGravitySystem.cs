using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CharacterControllerGravitySystem))]
    public sealed class CharacterControllerGravitySystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _filter = World.Filter
                .With<CharacterControllerGravityComponent>()
                .With<CharacterControllerMoveComponent>()
                .Build();

            foreach (var entity in _filter)
            {
                ref var gravityComponent = ref entity.GetComponent<CharacterControllerGravityComponent>();
                ref var characterControllerMoveComponent = ref entity.GetComponent<CharacterControllerMoveComponent>();
                if (!gravityComponent.characterController.isGrounded)
                {
                    var gravity =
                        gravityComponent.animationCurve.Evaluate(gravityComponent.currentTime /
                                                                 gravityComponent.animationCurve.length);
                    gravityComponent.currentTime += deltaTime;
                    characterControllerMoveComponent.directionY = gravity * gravityComponent.gravity * deltaTime;
                }
                else
                {
                    gravityComponent.currentTime = 0f;
                }
            }
        }
    }
}