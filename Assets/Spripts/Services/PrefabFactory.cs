using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace ECS_Lite_Test
{
    public class PrefabFactory
    {
        private AssetData _assetData;
        
        [Inject]
        public void Construct(AssetData assetData)
        {
            _assetData = assetData;
        }
        
        public T CreatePrefab<T>(T prefabObject, Vector3 position) where T :  Object
        {
            return Object.Instantiate(prefabObject, position, Quaternion.identity);
        }
    }
}
