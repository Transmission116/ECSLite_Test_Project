using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECS_Lite_Test {
    sealed class MonoAnimationSystem : IEcsRunSystem 
    {
        private EcsFilterInject<Inc<AnimatorComponent>> _animatorFilter = default;
        

        public void Run (EcsSystems systems)
        {
            foreach (var entity in _animatorFilter.Value)
            {
                SetMovingAnimation(entity, systems);
            }
        }

        private void SetMovingAnimation(int entity, EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsPool<MovingTag> movingPool = world.GetPool<MovingTag> ();
            bool isMovingState = movingPool.Has(entity);
            ref AnimatorComponent animationComponent = ref _animatorFilter.Pools.Inc1.Get(entity);
            animationComponent.Animator.SetBool(AnimationStateEnum.Walk.AnimationStateName(),isMovingState);
        }
    }
}