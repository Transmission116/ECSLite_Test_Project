using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECS_Lite_Test
{
    internal sealed class UpdateMoveSystem : IEcsRunSystem
    {

        private EcsCustomInject<GameConfiguration> _gameComponent;

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
                    destPoint.Value, 1/t*Time.deltaTime);

                
                
                if ((destPoint.Value - positionComponent.Value).sqrMagnitude < _gameComponent.Value.StopDistance)
                {
                    world.GetPool<DestinationPointComponent>().Del(entity);
                }
            }
        }
    }
}