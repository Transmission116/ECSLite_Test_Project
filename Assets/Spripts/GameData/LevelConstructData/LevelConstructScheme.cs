using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS_Lite_Test
{
    [CreateAssetMenu(menuName = "GameConfiguration/LevelConstructScheme",fileName = "LevelConstructScheme")]
    public class LevelConstructScheme: ScriptableObject
    {
        [SerializeField] private SceneButtonData[] _buttonData;
        [SerializeField] private SceneDownDoorData[] _doorData;
        [SerializeField] private Vector3 _playerSpawnPosition;
        
        
        public SceneButtonData[] ButtonData => _buttonData;
        public SceneDownDoorData[] DoorData => _doorData;
        public Vector3 PlayerSpawnPosition => _playerSpawnPosition;

    }
}
