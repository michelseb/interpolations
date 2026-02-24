namespace ZepLink.Interpolations.Easings
{
    public class EaseIn : Easing
    {
        public override EasingType Type => EasingType.EaseIn;
        
        public override float GetT(float t)
        {
            return t * t;
        }
    }
}
