using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CharacterControllerGravitySystem))]
    public sealed class CharacterControllerGravitySystem : FixedUpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _filter = World.Filter.With<CharacterControllerGravityComponent>().Build();

            foreach (var entity in _filter)
            {
                var gravityComponent = entity.GetComponent<CharacterControllerGravityComponent>();
                gravityComponent.characterController.Move(Vector3.down * -gravityComponent.gravity * deltaTime);
            }
        }
    }
}