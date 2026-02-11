namespace ZepLink.Interpolations
{
    public interface IInterpolation
    {
        float Duration { get; }
        void Init();
        void Process(float elapsedTime);
        void Apply();
        void Complete();
    }
}
