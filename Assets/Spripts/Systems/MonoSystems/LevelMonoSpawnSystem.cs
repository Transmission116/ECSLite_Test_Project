using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECS_Lite_Test
{
    internal sealed class LevelMonoSpawnSystem : IEcsInitSystem
    {
        private EcsPoolInject<TransformComponent> _transformPool = default;
  

        private EcsCustomInject<PrefabFactory> _prefabFactory;
        private EcsCustomInject<AssetData> _assetData;
        
        
        public void Init(EcsSystems systems)
        {
            SpawnLevel();
            SpawnButtons(systems);
            SpawnDoors(systems);
        }

        private void SpawnDoors(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            EcsFilter filter = world.Filter<PositionComponent>()
                .Inc<LinkedIdComponent>()
                .Inc<MoveSpeedComponent>()
                .Inc<CanBeActiveLinkedComponent>()
                .Exc<PushableComponent>()
                .End();


            EcsPool<PositionComponent> positionPool = world.GetPool<PositionComponent>();
            EcsPool<LinkedIdComponent> linkedIdPool = world.GetPool<LinkedIdComponent>();
            foreach (var entity in filter)
            {
                ref PositionComponent posComp = ref positionPool.Get(entity);
                ref LinkedIdComponent linkComp = ref linkedIdPool.Get(entity);

                VisualView doorObject = _prefabFactory.Value.CreatePrefab(_assetData.Value.DoorsPrefab,posComp.Value);
                
                doorObject.SetupVisualView(_assetData.Value.GetMaterialByColorID(linkComp.Value));
                
                ref TransformComponent transComp = ref _transformPool.Value.Add(entity);
                transComp.Transform = doorObject.Transform;
            }
        }

        private void SpawnButtons(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            EcsFilter filter = world.Filter<PositionComponent>()
                .Inc<LinkedIdComponent>()
                .Inc<DistanceCheckComponent>()
                .Inc<PushableComponent>()
                .Exc<CanBeActiveLinkedComponent>()
                .End();


            EcsPool<PositionComponent> positionPool = world.GetPool<PositionComponent>();
            EcsPool<LinkedIdComponent> linkedIdPool = world.GetPool<LinkedIdComponent>();
            foreach (var entity in filter)
            {
                ref PositionComponent posComp = ref positionPool.Get(entity);
                ref LinkedIdComponent linkComp = ref linkedIdPool.Get(entity);
                
                VisualView buttonObject = _prefabFactory.Value.CreatePrefab(_assetData.Value.ButtonPrefab,posComp.Value);

                buttonObject.SetupVisualView(_assetData.Value.GetMaterialByColorID(linkComp.Value));
                
                ref TransformComponent transComp = ref _transformPool.Value.Add(entity);
                transComp.Transform = buttonObject.Transform;
            }
        }

        private void SpawnLevel()
        {
            int levelIndex = 0; //can be use for generate level from array 
            _prefabFactory.Value.CreatePrefab(_assetData.Value.LevelPrefab[levelIndex], Vector3.zero);
        }
    }
}