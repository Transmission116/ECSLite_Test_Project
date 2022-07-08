using System;
using System.Numerics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine.Assertions.Must;
using Vector3 = UnityEngine.Vector3;

namespace ECS_Lite_Test
{
    sealed class UpdateDestPointInLinkedElementsSystem : IEcsRunSystem
    {
        private EcsFilterInject<
            Inc<LinkedIdComponent,
            CanBeActiveLinkedComponent,
            PositionComponent,
            StartPositionComponent,
            DeltaMoveComponent>> _canBeActiveCompFilter = default;

        private EcsPoolInject<DestinationPointComponent> _poolDestination = default;
        private EcsPoolInject<StartPositionComponent> _poolStartPosition = default;
        private EcsPoolInject<DeltaMoveComponent> _poolDeltaMove = default;
        
        public void Run(EcsSystems systems)
        {
            foreach (var canBeActEnt in _canBeActiveCompFilter.Value)
            {
                ref var canBeActiveComp = ref _canBeActiveCompFilter.Pools.Inc2.Get(canBeActEnt);
                
                if (_poolDestination.Value.Has(canBeActEnt) == false && canBeActiveComp.IsActive)
                {
                    ref DestinationPointComponent destComp = ref _poolDestination.Value.Add(canBeActEnt);
                    ref StartPositionComponent startPosComp = ref _poolStartPosition.Value.Get(canBeActEnt);
                    
                    
                    ref DeltaMoveComponent deltaMove = ref _poolDeltaMove.Value.Get(canBeActEnt);

                    Vector3 destPosition = new Vector3(
                        startPosComp.Value.x -deltaMove.Value.x,
                        startPosComp.Value.y -deltaMove.Value.y,
                        startPosComp.Value.z -deltaMove.Value.z);

                    destComp.Value = destPosition;
                }
                else if(canBeActiveComp.IsActive == false)
                {
                    if (_poolDestination.Value.Has(canBeActEnt))
                    {
                        _poolDestination.Value.Del(canBeActEnt);
                    }
                }
            }
        }
    }
}