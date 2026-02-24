namespace ZepLink.Interpolations.Easings
{
    public class EaseOut : Easing
    {
        public override EasingType Type => EasingType.EaseOut;
        
        public override float GetT(float t)
        {
            return t * (2f - t);
        }
    }
}
