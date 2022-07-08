using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECS_Lite_Test
{
    internal sealed class UnityMouseInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorldInject _world = default;
        private EcsFilterInject<Inc<MouseInputComponent>> _mouseInputCompFilter = default;
        private EcsPoolInject<MouseInputComponent> _mouseInputCompPool = default;
        
        
        public void Init(EcsSystems systems)
        {
            CheckInputDataExists();
        }
        public void Run(EcsSystems systems)
        {
            UpdateMousePressPosition();
        }
        
        private void CheckInputDataExists()
        {
            int entity = _world.Value.NewEntity();
            _mouseInputCompPool.Value.Add(entity);
        }
       
        
        private void UpdateMousePressPosition()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    foreach (int dataEntity in _mouseInputCompFilter.Value)
                    {
                        ref MouseInputComponent inputDataComponent = ref _mouseInputCompPool.Value.Get(dataEntity);
                        inputDataComponent.Value = hit.point;
                        inputDataComponent.IsPressed = true;
                    }
                }
            }
            else
            {
                foreach (int dataEntity in _mouseInputCompFilter.Value)
                {
                    ref MouseInputComponent inputDataComponent = ref _mouseInputCompPool.Value.Get(dataEntity);
                    inputDataComponent.IsPressed = false;
                }
            }
        }

       
    }
}