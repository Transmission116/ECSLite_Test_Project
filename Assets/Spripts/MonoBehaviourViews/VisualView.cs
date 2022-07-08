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
         
        private AssetData _assetData;

        public Transform Transform => _transform;

        [Inject]
        public void Construct(AssetData assetData)
        {
            _assetData = assetData;
        }
        
        public void SetupVisualView(ColorID colorID)
        {
            _objectMeshRenderer.material = _assetData.GetMaterialByColorID(colorID);
        }
        
    }
}
