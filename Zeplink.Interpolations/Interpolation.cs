using System;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations
{
    public abstract class Interpolation<T, U> : IInterpolation where T : UnityEngine.Object where U : struct
    {
        public T Reference { get; }
        public U Value { get; protected set; }
        public U Origin { get; protected set; }
        public U Target { get; private set; }
        public Func<U> DeferredOrigin { get; protected set; }
        public Func<U> DeferredTarget { get; protected set; }
        public float Duration { get; }
        public Easing Easing { get; }

        protected Action _onStart;
        protected Action _onEnd;

        public Interpolation(T reference, U origin, U target, float duration, EasingType easingType = EasingType.Linear)
        {
            Reference = reference;
            Value = origin;
            Origin = origin;
            Target = target;
            Duration = duration;
            Easing = EasingFactory.Get(easingType);
        }

        public Interpolation(T reference, U value, U origin, U target, float duration, EasingType easingType = EasingType.Linear)
        {
            Reference = reference;
            Value = value;
            Origin = origin;
            Target = target;
            Duration = duration;
            Easing = EasingFactory.Get(easingType);
        }

        public Interpolation(T reference, Func<U> origin, Func<U> target, float duration, EasingType easingType = EasingType.Linear)
        {
            Reference = reference;
            Value = origin();
            DeferredOrigin = origin;
            DeferredTarget = target;
            Duration = duration;
            Easing = EasingFactory.Get(easingType);
        }

        public Interpolation(T reference, U value, Func<U> origin, Func<U> target, float duration, EasingType easingType = EasingType.Linear)
        {
            Reference = reference;
            Value = value;
            DeferredOrigin = origin;
            DeferredTarget = target;
            Duration = duration;
            Easing = EasingFactory.Get(easingType);
        }

        public virtual void Init()
        {
            if (DeferredOrigin != default)
            {
                Origin = DeferredOrigin();
            }

            if (DeferredTarget != default)
            {
                Target = DeferredTarget();
            }

            _onStart?.Invoke();
        }

        public abstract void Process(float elapsedTime);

        public virtual float GetT(float elapsedTime)
        {
            return Easing.GetT(elapsedTime / Duration);
        }

        public abstract void Apply();

        public virtual void Complete()
        {
            Value = Target;
            _onEnd?.Invoke();
        }

        public virtual Interpolation<T, U> SetOnStart(Action onStart)
        {
            _onStart = onStart;
            return this;
        }

        public virtual Interpolation<T, U> SetOnEnd(Action onEnd)
        {
            _onEnd = onEnd;
            return this;
        }
    }
}
