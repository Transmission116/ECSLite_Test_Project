using UnityEngine;

namespace ECS_Lite_Test
{
    [System.Serializable]
    public class BasicSceneObjectData
    {
        [SerializeField] protected Vector3 _position;
        [SerializeField] protected ColorID _colorId;
        
        public Vector3 Position => _position;
        public ColorID ColorId => _colorId;
    }
}