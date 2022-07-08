using System.IO.Enumeration;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECS_Lite_Test {
    sealed class PlayerMonoSpawnSystem : IEcsInitSystem 
    {
        private EcsPoolInject<TransformComponent> _poolTransform = default;
        private EcsPoolInject<AnimatorComponent> _poolAnimator = default;
        
        private EcsCustomInject<PrefabFactory> _prefabFactory;
        private EcsCustomInject<AssetData> _assetData;
        
        public void Init (EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<ControlledByPlayer>()
                .Inc<PositionComponent>()
                .Inc<MoveSpeedComponent>().End();

            foreach (var entity in filter)
            {
                EcsPool<PositionComponent> poolPosition = world.GetPool<PositionComponent>();
                
                TransformView playerUnit = _prefabFactory.Value.CreatePrefab(_assetData.Value.PlayerPrefab, poolPosition.Get(entity).Value);
                _poolTransform.Value.Add(entity).Transform = playerUnit.Transform;
                _poolAnimator.Value.Add(entity).Animator = playerUnit.GetComponent<Animator>();
            }
        }
    }
}