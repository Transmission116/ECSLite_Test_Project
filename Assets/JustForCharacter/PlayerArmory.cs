using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Linq;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private GameObject _attachedObj;
    [SerializeField] private GameObject _allBonesOwner;
 
    private Transform[] allModelBones;


    private void Awake()
    {
        EquipArm();
    }

    private void EquipArm()
    {
        allModelBones = _allBonesOwner.GetComponentsInChildren<Transform>();
        var _skinnedMeshes = _attachedObj.GetComponentsInChildren<SkinnedMeshRenderer>();
        if (_skinnedMeshes != null)
        {
            foreach (var _skinnedMeshRenderer in _skinnedMeshes)
            {
                RetargedSkinnedMeshRenderer(_skinnedMeshRenderer, _allBonesOwner);
            }
        }
    }
    private Transform GetBoneByName(string _boneName)
    {
        return allModelBones.FirstOrDefault(x => x.gameObject.name == _boneName);
    }

    private void RetargedSkinnedMeshRenderer(SkinnedMeshRenderer _skinnedRenderer, GameObject _allBonesOwner)
    {
        var _equipmentBones = _skinnedRenderer.bones;
        Transform[] _retargetedBones = new Transform[_equipmentBones.Length];

        for (int i = 0; i < _equipmentBones.Length; ++i)
        {
            var _equipmentBone = _equipmentBones[i];
            Transform _dollBone = GetBoneByName(_equipmentBone.gameObject.name);
            if (!_dollBone)
            {
                Debug.LogWarning("Can't find bone " + _equipmentBone.gameObject.name + " in doll");
                if (!TrySetAbsentBoneByParentModelBone(_equipmentBone, out _dollBone))
                    // Exception case handling (plug, but can't do better):
                    _dollBone = _allBonesOwner.transform;
            }
            _retargetedBones[i] = _dollBone;
        }
        _skinnedRenderer.bones = _retargetedBones;
    }
    private bool TrySetAbsentBoneByParentModelBone(Transform _equipmentBone, out Transform _outBone)
    {
        var _parentGo = _equipmentBone.parent.gameObject;
        while (_parentGo != null)
        {
            Transform _dollParentBone = GetBoneByName(_parentGo.name);
            if (_dollParentBone)
            {
                _outBone = _dollParentBone;
                return true;
            }
            _parentGo = _parentGo.transform.parent.gameObject;
        }
        _outBone = null;
        return false;
    }

}


