namespace ZepLink.Interpolations.Easings
{
    public class EaseInOut : Easing
    {
        public override EasingType Type => EasingType.EaseInOut;
        
        public override float GetT(float t)
        {
            return t * t * (3f - 2f * t);
        }
    }
}
