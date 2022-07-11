using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECS_Lite_Test
{
    public interface ITimeService 
    {
        public float DeltaTime { get; }

        public float FixedDeltaTime { get;}
    }
}
