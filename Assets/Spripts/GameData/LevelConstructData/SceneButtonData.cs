using UnityEngine;

namespace ECS_Lite_Test
{
    [System.Serializable]
    public class SceneButtonData : BasicSceneObjectData
    {
        [SerializeField] private float _pushDistance = 0.5f;
        
        public float PushDistance => _pushDistance;
    }
}