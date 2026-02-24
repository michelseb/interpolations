namespace ZepLink.Interpolations.Easings
{
    public class Linear : Easing
    {
        public override EasingType Type => EasingType.Linear;
        
        public override float GetT(float t)
        {
            return t; 
        }
    }
}
