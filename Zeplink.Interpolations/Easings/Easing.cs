namespace ZepLink.Interpolations.Easings
{
    public abstract class Easing
    {
        public abstract EasingType Type { get; }
        public abstract float GetT(float t);
    }
}
