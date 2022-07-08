namespace ECS_Lite_Test
{
    public class Utils
    {
        public static System.Numerics.Vector3 ConvertVector3NumerToUnity(UnityEngine.Vector3 unityV3)
        {
            System.Numerics.Vector3 numV3 = new System.Numerics.Vector3() {
                X = unityV3.x,
                Y = unityV3.y,
                Z = unityV3.z,
            };
            return numV3;
        }
    }
    
    public static class ClassExtention
    {
        public static string Name(this ColorID var)
        {
            switch (var)
            {
                case ColorID.Blue : return "Blue";
                case ColorID.Green : return "Greed";
                default: return "";
                    
            }
        }
    }
}