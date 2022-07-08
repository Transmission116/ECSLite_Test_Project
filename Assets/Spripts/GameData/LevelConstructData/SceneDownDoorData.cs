using UnityEngine;

namespace ECS_Lite_Test
{
    [System.Serializable]
    public class SceneDownDoorData : BasicSceneObjectData
    {
        [SerializeField] private Vector3 _doorMoveDelta ;
        [SerializeField] private float _doorMoveSpeed = 0.2f;

        public Vector3 DoorMoveDelta => _doorMoveDelta;

        public float DoorMoveSpeed => _doorMoveSpeed;
    }
}