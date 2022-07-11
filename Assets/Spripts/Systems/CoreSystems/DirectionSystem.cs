using System.Numerics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;


namespace ECS_Lite_Test 
{
    sealed class DirectionSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<PositionComponent, DestinationPointComponent, DirectionComponent>> _movingObjectFilterInject = default;
        
       
        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            foreach (var movingEntity in _movingObjectFilterInject.Value)
            {
                ref PositionComponent positionComponent = ref world.GetPool<PositionComponent>().Get(movingEntity);
                ref DestinationPointComponent destinationPointComponent =
                    ref world.GetPool<DestinationPointComponent>().Get(movingEntity);

                Vector3 direction = destinationPointComponent.Value - positionComponent.Value;

                EcsPool<DirectionComponent> directionPool = world.GetPool<DirectionComponent>();
                ref DirectionComponent directionComponent = ref directionPool.Get(movingEntity);

                directionComponent.Value = direction;
            }
        }
    }
}