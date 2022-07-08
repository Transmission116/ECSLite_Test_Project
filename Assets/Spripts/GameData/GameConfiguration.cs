using UnityEngine;

namespace ECS_Lite_Test
{
    [CreateAssetMenu(menuName = "GameConfiguration/GameConfiguration",fileName = "GameConfiguration")]
    public class GameConfiguration: ScriptableObject
    {
        [SerializeField] private float _playerSpeed = 5;
        [SerializeField] private float _stopDistance = 0.001f;
        
    }
}