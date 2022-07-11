using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECS_Lite_Test {
    sealed class MonoDirectionViewSystem : IEcsRunSystem 
    {        
        private EcsFilterInject<Inc<
            DirectionComponent,
            TransformComponent>> _directionObjectFilter = default;
        
        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            foreach (var entity in _directionObjectFilter.Value)
            {
                ref DirectionComponent directionComponent = ref world.GetPool<DirectionComponent>().Get(entity);
                ref TransformComponent transformComponent = ref world.GetPool<TransformComponent>().Get(entity);

                transformComponent.Transform.forward = directionComponent.Value.ToUnityVector3();
            }
        }
    }
}