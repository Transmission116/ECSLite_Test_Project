using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS_Lite_Test
{
    [CreateAssetMenu(menuName = "GameConfiguration/PrefabData",fileName = "PrefabData")]
    public class PrefabData : ScriptableObject
    {
        [SerializeField] private GameObject _levelPrefab;
        [SerializeField] private GameObject _playerPrefab;
        
        [SerializeField] private GameObject _greenButtonPrefab;

        [SerializeField] private GameObject _blueButtonPrefab;
        
        [SerializeField] private GameObject _greenDoorsPrefab;
        [SerializeField] private GameObject _blueDoorsPrefab;
       
        public GameObject LevelPrefab => _levelPrefab;
        public GameObject PlayerPrefab => _playerPrefab;
        
        public GameObject GreenButtonPrefab => _greenButtonPrefab;

        public GameObject BlueButtonPrefab => _blueButtonPrefab;

        public GameObject GreenDoorsPrefab => _greenDoorsPrefab;

        public GameObject BlueDoorsPrefab => _blueDoorsPrefab;


    }
}
