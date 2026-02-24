namespace ZepLink.Interpolations.Easings
{
    public class SmoothStep : Easing
    {
        public override EasingType Type => EasingType.EaseInOut;
        
        public override float GetT(float t)
        {
            return t * t * t * (t * (6f * t - 15f) + 10f);
        }
    }
}
