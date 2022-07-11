using System.Numerics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;


namespace ECS_Lite_Test {
    sealed class PushableSystem : IEcsRunSystem 
    {  
        
        private EcsFilterInject<Inc<CanPushTag>> _canPushCompFilter = default;
        private EcsFilterInject<Inc<PushableComponent, DistanceCheckComponent>> _pushableCompFilter = default;
        
        private EcsPoolInject<PositionComponent> _positionPool = default;
        
        
        public void Run (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            
            foreach (var pushableEnt in _pushableCompFilter.Value)
            {
                bool isSomebodyPushing = false;
                foreach (var canPushEnt in _canPushCompFilter.Value)
                {
                    ref var pushablePos = ref _positionPool.Value.Get(pushableEnt);
                    ref var canPushPos = ref _positionPool.Value.Get(canPushEnt);

                    EcsPool <DistanceCheckComponent> distanceCheckPool = world.GetPool<DistanceCheckComponent>();

                    ref DistanceCheckComponent distanceCheckComponent = ref distanceCheckPool.Get(pushableEnt);
                    
                    if (Vector3.Distance(pushablePos.Value,canPushPos.Value) < distanceCheckComponent.DistanceForActivate)
                    {
                        isSomebodyPushing = true;
                        break;
                    }
                }

                ref var pushableComp = ref _pushableCompFilter.Pools.Inc1.Get(pushableEnt);
                pushableComp.IsPushed = isSomebodyPushing;
            }
        }
    }
}