using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECS_Lite_Test
{
    internal sealed class PlayerDestinationSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<MouseInputComponent>> _mouseInputCompFilter = default;

        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<ControlledByPlayerTag>()
                .Inc<MoveSpeedComponent>()
                .Inc<PositionComponent>()
                .End();
            
            foreach (int playerEntity in filter)
            {
                foreach (int inputEntity in _mouseInputCompFilter.Value)
                {
                    MouseInputComponent mouseInputComp = _mouseInputCompFilter.Pools.Inc1.Get(inputEntity);

                    if (mouseInputComp.IsPressed)
                    {
                        if (world.GetPool<DestinationPointComponent>().Has(playerEntity) == false)
                        {
                            world.GetPool<DestinationPointComponent>().Add(playerEntity);
                        }
                        
                        ref DestinationPointComponent destinationPoint = ref world.GetPool<DestinationPointComponent>().Get(playerEntity);
                        destinationPoint.Value = mouseInputComp.Value;
                    }
                    
                }
            }
        }
    }
}