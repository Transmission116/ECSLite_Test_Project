using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS_Lite_Test
{
    public class TransformView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;
    }
}
