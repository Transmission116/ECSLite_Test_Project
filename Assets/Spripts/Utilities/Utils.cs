

namespace ECS_Lite_Test
{
    public static class Utils
    {
        public static UnityEngine.Vector3 ToUnityVector3(this System.Numerics.Vector3 numericVector3)
        {
            UnityEngine.Vector3 unityVector3 = new UnityEngine.Vector3() {
                x = numericVector3.X,
                y = numericVector3.Y,
                z = numericVector3.Z,
            };
            return unityVector3;
        }
        
        public static  System.Numerics.Vector3 ToNumericVector3(this UnityEngine.Vector3 unityVector)
        {
            System.Numerics.Vector3 numericVector3 = new System.Numerics.Vector3() {
                X = unityVector.x,
                Y = unityVector.y,
                Z = unityVector.z,
            };
           
            return numericVector3;
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