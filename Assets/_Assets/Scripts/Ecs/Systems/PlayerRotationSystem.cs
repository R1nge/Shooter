using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerRotationSystem))]
    public sealed class PlayerRotationSystem : UpdateSystem
    {
        [SerializeField] private float rotationLimit = 90f;
        private Filter _filter;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _filter = World.Filter.With<PlayerRotationComponent>().With<InputComponent>().Build();

            foreach (var entity in _filter)
            {
                ref var rotationComponent = ref entity.GetComponent<PlayerRotationComponent>();
                var inputComponent = entity.GetComponent<InputComponent>();
                rotationComponent.rotationX = Mathf.Clamp(rotationComponent.rotationX + inputComponent.mouseY,
                    -rotationLimit, rotationLimit);
                rotationComponent.camera.localRotation = Quaternion.Euler(rotationComponent.rotationX, 0, 0);
                rotationComponent.transform.rotation *= Quaternion.Euler(0, inputComponent.mouseX, 0);
            }
        }
    }
}