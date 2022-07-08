using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ECS_Lite_Test
{
    public class VisualView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _objectMeshRenderer;
        [SerializeField] private Transform _transform;
        
        public Transform Transform => _transform;

        
        public void SetupVisualView(Material material)
        {
            _objectMeshRenderer.material = material;
        }
        
    }
}
