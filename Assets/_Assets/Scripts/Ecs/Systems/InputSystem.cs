using _Assets.Scripts.Ecs.Components;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Systems
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputSystem))]
    public sealed class InputSystem : UpdateSystem
    {
        private Filter _inputFilter;
        
        public override void OnAwake()
        {
            
        }

        public override void OnUpdate(float deltaTime)
        {
            _inputFilter = World.Filter.With<InputComponent>().With<NetworkComponent>().Build();
            foreach (var entity in _inputFilter)
            {
                if (entity.GetComponent<NetworkComponent>().isOwner)
                {
                    ref var inputComponent = ref entity.GetComponent<InputComponent>();
                    inputComponent.directionX = Input.GetAxis("Horizontal");
                    inputComponent.directionZ = Input.GetAxis("Vertical");
                    inputComponent.mouseX = Input.GetAxis("Mouse X");
                    inputComponent.mouseY = -Input.GetAxis("Mouse Y");
                    inputComponent.jump = Input.GetKeyDown(KeyCode.Space);
                    inputComponent.shoot = Input.GetMouseButton(0);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}