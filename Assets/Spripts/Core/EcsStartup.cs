using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;
using Zenject;

namespace ECS_Lite_Test
{
    internal sealed class EcsStartup : IInitializable, ITickable, IFixedTickable, IDisposable
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;
        
        private LevelConstructScheme _levelConstructScheme;
        private AssetData _prefabData;
        private PrefabFactory _prefabFactory;
        private GameConfiguration _gameConfiguration;

        [Inject]
        private void Construct(
            AssetData prefabData,
            LevelConstructScheme levelConstructScheme,
            PrefabFactory prefabFactory,
            GameConfiguration gameConfiguration)
        {
            _levelConstructScheme = levelConstructScheme;
            _prefabData = prefabData;
            _prefabFactory = prefabFactory;
            _gameConfiguration = gameConfiguration;
        }

        public void Initialize()
        {
            _world = new EcsWorld();
            CreateUpdateSystems();
            CreateFixedUpdateSystems();
        }

        public void Tick()
        {
            _systems?.Run();
        }

        public void FixedTick()
        {
            _fixedSystems?.Run();
        }

        public void Dispose()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }

            if (_fixedSystems != null)
            {
                _fixedSystems.Destroy();
                _fixedSystems = null;
            }

            _world?.Destroy();
            _world = null;
        }


        private void CreateUpdateSystems()
        {
            _systems = new EcsSystems(_world, "UpdateSystems");
            _systems
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                .Inject(_prefabData)
                .Inject(_levelConstructScheme)
                .Inject(_prefabFactory)
                .Inject(_gameConfiguration)
                .Init();
        }

        private void CreateFixedUpdateSystems()
        {
            _fixedSystems = new EcsSystems(_world, "FixedUpdateSystems");
            _fixedSystems
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                .Init();
        }
    }
}