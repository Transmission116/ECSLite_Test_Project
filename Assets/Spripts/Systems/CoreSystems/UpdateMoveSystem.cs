using System;
using System.Numerics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECS_Lite_Test
{
    internal sealed class UpdateMoveSystem : IEcsRunSystem
    {

        private EcsCustomInject<GameConfiguration> _gameComponent;
        private EcsCustomInject<ITimeService> _timeService;

        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter moveFilter = world.Filter<DestinationPointComponent>()
                .Inc<PositionComponent>()
                .Inc<MoveSpeedComponent>()
                .End();
            
            foreach (int entity in moveFilter)
            {
                
                ref PositionComponent positionComponent = ref world.GetPool<PositionComponent>().Get(entity);
                ref MoveSpeedComponent moveSpeedComponent = ref world.GetPool<MoveSpeedComponent>().Get(entity);
                ref DestinationPointComponent destPoint = ref world.GetPool<DestinationPointComponent>().Get(entity);

                float t = Vector3.Distance(destPoint.Value ,positionComponent.Value) /
                          moveSpeedComponent.Value;
                
                positionComponent.Value = Vector3.Lerp(positionComponent.Value,
                    destPoint.Value, 1 / t* _timeService.Value.DeltaTime);

                if (world.GetPool<MovingTag>().Has(entity)==false)
                {
                    world.GetPool<MovingTag>().Add(entity);
                }
                
                if (Vector3.Distance(destPoint.Value, positionComponent.Value) < _gameComponent.Value.StopDistance)
                {
                    world.GetPool<DestinationPointComponent>().Del(entity);
                    world.GetPool<MovingTag>().Del(entity);
                }
            }
        }
    }
}