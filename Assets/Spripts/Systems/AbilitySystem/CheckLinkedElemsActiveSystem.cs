using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECS_Lite_Test
{
    sealed class CheckLinkedElemsActiveSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<LinkedIdComponent, CanBeActiveLinkedComponent>> _canBeActiveCompFilter = default;
        private EcsFilterInject<Inc<LinkedIdComponent, PushableComponent>> _linkedPushableCompFilter = default;
        
        public void Run(EcsSystems systems)
        {
            foreach (var linkedElemEnt in _canBeActiveCompFilter.Value)
            {
                ref var linkedIdComp = ref _canBeActiveCompFilter.Pools.Inc1.Get(linkedElemEnt);
                bool foundSameColorPushedElem = false;

                foreach (var pushableEnt in _linkedPushableCompFilter.Value)
                {
                    ref var linkedIdCompInPushable = ref _linkedPushableCompFilter.Pools.Inc1.Get(pushableEnt);
                    ref var pushableComp = ref _linkedPushableCompFilter.Pools.Inc2.Get(pushableEnt);

                    if (linkedIdComp.Value == linkedIdCompInPushable.Value)
                    {
                        if (pushableComp.IsPushed)
                        {
                            foundSameColorPushedElem = true;
                            break;
                        }
                    }
                }
                
                ref var canBeActiveComp = ref _canBeActiveCompFilter.Pools.Inc2.Get(linkedElemEnt);
                canBeActiveComp.IsActive = foundSameColorPushedElem;
            }
        }
    }
}