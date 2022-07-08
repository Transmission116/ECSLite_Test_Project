using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS_Lite_Test
{
    public class AnimationView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public Animator Animator => _animator;
    }
}
