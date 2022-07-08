using System.Numerics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Vector3 = UnityEngine.Vector3;

namespace ECS_Lite_Test
{
    internal sealed class LevelInitializeSystem : IEcsInitSystem
    {
        private EcsCustomInject<LevelConstructScheme> _levelConstructScheme;
      
        public void Init(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            int entity = world.NewEntity();
            EcsPool<PlayerSpawnPositionComponent> spawnPosPool = world.GetPool<PlayerSpawnPositionComponent>();
            ref PlayerSpawnPositionComponent spawnComponent = ref spawnPosPool.Add(entity);
            spawnComponent.Value = _levelConstructScheme.Value.PlayerSpawnPosition;

            CreateButtonEntity(world);
            
            CreateDoorEntity(world);
            
        }

        private void CreateDoorEntity(EcsWorld world)
        {
            foreach (var doorData in _levelConstructScheme.Value.DoorData)
            {
                int doorEntity = world.NewEntity();
                EcsPool<PositionComponent> positionPool = world.GetPool<PositionComponent>();
                ref PositionComponent positionComponent = ref positionPool.Add(doorEntity);
                positionComponent.Value = doorData.Position;

                EcsPool<LinkedIdComponent> linkedIdPool = world.GetPool<LinkedIdComponent>();
                ref LinkedIdComponent linkedIdComponent = ref linkedIdPool.Add(doorEntity);
                linkedIdComponent.Value = doorData.ColorId;

                EcsPool<MoveSpeedComponent> moveSpeedPool = world.GetPool<MoveSpeedComponent>();
                ref MoveSpeedComponent moveSpeedComp = ref moveSpeedPool.Add(doorEntity);
                moveSpeedComp.Value = doorData.DoorMoveSpeed;
                
                EcsPool<StartPositionComponent> startPositionPool = world.GetPool<StartPositionComponent>();
                ref StartPositionComponent startPosition = ref startPositionPool.Add(doorEntity);
                startPosition.Value = doorData.Position;
                
                EcsPool<DeltaMoveComponent> deltaMovePool = world.GetPool<DeltaMoveComponent>();
                ref DeltaMoveComponent deltaMovePosition = ref deltaMovePool.Add(doorEntity);
                deltaMovePosition.Value = doorData.DoorMoveDelta;
                
                EcsPool<CanBeActiveLinkedComponent> canBeActiveLinkedPool = world.GetPool<CanBeActiveLinkedComponent>();
                canBeActiveLinkedPool.Add(doorEntity);
               
            }
        }

        private void CreateButtonEntity(EcsWorld world)
        {
            foreach (var buttonData in _levelConstructScheme.Value.ButtonData)
            {
                int buttonEntity = world.NewEntity();
                EcsPool<PositionComponent> positionComponentPool = world.GetPool<PositionComponent>();
                ref PositionComponent positionComponent = ref positionComponentPool.Add(buttonEntity);
                positionComponent.Value = buttonData.Position;

                EcsPool<LinkedIdComponent> linkedIdPool = world.GetPool<LinkedIdComponent>();
                ref LinkedIdComponent linkedIdComponent = ref linkedIdPool.Add(buttonEntity);
                linkedIdComponent.Value = buttonData.ColorId;

                EcsPool<PushableComponent> pushableComponentPool = world.GetPool<PushableComponent>();
                pushableComponentPool.Add(buttonEntity);

                EcsPool<DistanceCheckComponent> distanceCheckPool = world.GetPool<DistanceCheckComponent>();
                ref DistanceCheckComponent distCheckCom =ref distanceCheckPool.Add(buttonEntity);
                distCheckCom.DistanceForActivate = buttonData.PushDistance;
            }
        }
    }
}