using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECS_Lite_Test
{
    internal sealed class MonoLevelSpawnSystem : IEcsInitSystem
    {
        private EcsPoolInject<TransformComponent> _transformPool = default;
        
        private EcsPoolInject<PositionComponent> _positionPool = default;
        private EcsPoolInject<LinkedIdComponent> _linkedIdPool = default;

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


            /*EcsPool<PositionComponent> positionPool = world.GetPool<PositionComponent>();
            EcsPool<LinkedIdComponent> linkedIdPool = world.GetPool<LinkedIdComponent>();*/
            foreach (var entity in filter)
            {
                SpawnAndSetupSceneObject(_assetData.Value.DoorsPrefab,entity);
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


            /*EcsPool<PositionComponent> positionPool = world.GetPool<PositionComponent>();
            EcsPool<LinkedIdComponent> linkedIdPool = world.GetPool<LinkedIdComponent>();*/
            foreach (var entity in filter)
            {
                SpawnAndSetupSceneObject(_assetData.Value.ButtonPrefab,entity);
            }
        }

        private void SpawnLevel()
        {
            int levelIndex = 0; //can be use for generate level from array 
            _prefabFactory.Value.CreatePrefab(_assetData.Value.LevelPrefab[levelIndex], Vector3.zero);
        }

        private void SpawnAndSetupSceneObject(VisualView spawnPrefab,int entity)
        {
            ref PositionComponent posComp = ref _positionPool.Value.Get(entity);
            ref LinkedIdComponent linkComp = ref _linkedIdPool.Value.Get(entity);
            
            Vector3 spawnPosition = posComp.Value.ToUnityVector3();
            VisualView buttonObject = _prefabFactory.Value.CreatePrefab(spawnPrefab,spawnPosition);

            buttonObject.SetupVisualView(_assetData.Value.GetMaterialByColorID(linkComp.Value));
                
            ref TransformComponent transComp = ref _transformPool.Value.Add(entity);
            transComp.Transform = buttonObject.Transform;
        }
    }
}