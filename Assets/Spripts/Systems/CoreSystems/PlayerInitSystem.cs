using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using UnityEngine.WSA;

namespace ECS_Lite_Test
{
    internal sealed class PlayerInitSystem : IEcsInitSystem
    {
        private EcsPoolInject<PositionComponent> _poolPosition = default;
        private EcsPoolInject<MoveSpeedComponent> _poolMoveSpeed = default;
        private EcsPoolInject<ControlledByPlayerTag> _poolControlByPlayer = default;
        private EcsPoolInject<DirectionComponent> _poolDirectionSystem = default;
        private EcsPoolInject<CanPushTag> _canPushPool = default;

        private EcsCustomInject<GameConfiguration> _gameConfiguration;

        public void Init(EcsSystems systems)
        {
            int playerEntity = systems.GetWorld().NewEntity();

            EcsFilter filter = systems.GetWorld().Filter<PlayerSpawnPositionComponent>().End();
            EcsPool<PlayerSpawnPositionComponent> spawnPosPool = systems.GetWorld().GetPool<PlayerSpawnPositionComponent>();
            foreach (var entity in filter)
            {
                _poolPosition.Value.Add(playerEntity).Value = spawnPosPool.Get(entity).Value;
                _poolMoveSpeed.Value.Add(playerEntity).Value = _gameConfiguration.Value.PlayerSpeed;
                _canPushPool.Value.Add(playerEntity);
                _poolControlByPlayer.Value.Add(playerEntity);
                _poolDirectionSystem.Value.Add(playerEntity);
                spawnPosPool.Del(entity);
            }
        }
    }
}