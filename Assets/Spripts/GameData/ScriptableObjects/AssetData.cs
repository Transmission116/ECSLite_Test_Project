using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS_Lite_Test
{
    [CreateAssetMenu(menuName = "GameConfiguration/AssetData",fileName = "AssetData")]
    public class AssetData : ScriptableObject
    {
        [SerializeField] private TransformView[] _levelPrefabs;
        [SerializeField] private TransformView _playerPrefab;
        
        [SerializeField] private VisualView _buttonPrefab;
        [SerializeField] private VisualView _doorsPrefab;

        [SerializeField] private Material _greenMaterial;
        [SerializeField] private Material _blueMaterial;
        
        
        public TransformView[] LevelPrefab => _levelPrefabs;
        public TransformView PlayerPrefab => _playerPrefab;
        
        public VisualView ButtonPrefab => _buttonPrefab;
        public VisualView DoorsPrefab => _doorsPrefab;

        public Material GetMaterialByColorID(ColorID coloeId)
        {
            switch (coloeId)
            {
                case ColorID.Green : return _greenMaterial;
                case ColorID.Blue : return _blueMaterial;
                default: throw new NullReferenceException("Material not find");
            }
        }

    }
}
