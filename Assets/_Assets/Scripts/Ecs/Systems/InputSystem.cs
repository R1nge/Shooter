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
            _inputFilter = World.Filter.With<InputComponent>().With<NetworkComponent>().With<MoveComponent>().Build();
            foreach (var entity in _inputFilter)
            {
                if (entity.GetComponent<NetworkComponent>().isOwner)
                {
                    Debug.Log("Update Input");
                    ref var inputComponent = ref entity.GetComponent<InputComponent>();
                    inputComponent.directionX = Input.GetAxis("Horizontal");
                    inputComponent.directionY = Input.GetAxis("Vertical");
                    inputComponent.jump = Input.GetKeyDown(KeyCode.Space);
                    inputComponent.shoot = Input.GetMouseButton(0);
                    
                    ref var moveComponent = ref entity.GetComponent<MoveComponent>();
                    moveComponent.directionX = inputComponent.directionX;
                    moveComponent.directionY = inputComponent.directionY;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}