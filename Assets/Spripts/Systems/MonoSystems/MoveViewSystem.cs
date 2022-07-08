using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace ECS_Lite_Test
{
    internal sealed class MoveViewSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<PositionComponent,TransformComponent,DestinationPointComponent>> _filterMovableComp = default;
        
        public void Run(EcsSystems systems)
        {
            CheckForNeedMove();
        }

        private void CheckForNeedMove()
        {
            foreach (int entity in _filterMovableComp.Value)
            {
                ref PositionComponent positionComp = ref _filterMovableComp.Pools.Inc1.Get(entity);
                ref TransformComponent transformComp = ref  _filterMovableComp.Pools.Inc2.Get(entity);

                transformComp.Transform.position = positionComp.Value;
            }
        }
    }
}