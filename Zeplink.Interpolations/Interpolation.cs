using UnityEngine;

namespace ZepLink.Interpolations
{
    public abstract class Interpolation<T, U> : IInterpolation where T : Object where U : struct
    {
        public T Reference { get; }
        public U Value { get; protected set; }
        public U Origin { get; protected set; }
        public U Target { get; }
        public float Duration { get; }

        public Interpolation(T reference, U origin, U target, float duration)
        {
            Reference = reference;
            Value = origin;
            Origin = origin;
            Target = target;
            Duration = duration;
        }

        public Interpolation(T reference, U value, U origin, U target, float duration)
        {
            Reference = reference;
            Value = value;
            Origin = origin;
            Target = target;
            Duration = duration;
        }

        public virtual void Init() { }

        public abstract void Process(float elapsedTime);

        public abstract void Apply();

        public virtual void Complete()
        {
            Value = Target;
        }
    }
}
