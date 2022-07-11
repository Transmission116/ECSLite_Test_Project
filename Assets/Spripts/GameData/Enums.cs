namespace ECS_Lite_Test
{
    public enum ColorID
    {
        Green,
        Blue
    }
    
    public enum AnimationStateEnum
    {
        Idle,
        Walk,
    }

    public static class ClassEnumExtention
    {
        public static string AnimationStateName(this AnimationStateEnum value)
        {
            switch (value)
            {
                case AnimationStateEnum.Idle : return "idle";
                case AnimationStateEnum.Walk : return "walk";
                default: return "";
            }
        }
       
    }
    
   
}