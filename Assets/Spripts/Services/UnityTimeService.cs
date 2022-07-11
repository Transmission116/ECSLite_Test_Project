using UnityEngine;

namespace ECS_Lite_Test
{
    public class UnityTimeService : ITimeService
    {
        public float DeltaTime => Time.deltaTime;
        public float FixedDeltaTime => Time.fixedTime;
    }
}