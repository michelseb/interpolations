using System;
using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    public class TransformScaleInterpolation : Interpolation<Transform, Vector3>
    {
        public TransformScaleInterpolation(Transform transform, Func<Vector3> origin, Func<Vector3> target, float duration, EasingType easingType = EasingType.Linear) : base(transform, origin, target, duration, easingType) { }
        public TransformScaleInterpolation(Transform transform, Func<Vector3> target, float duration, EasingType easingType = EasingType.Linear) : this(transform, () => transform.localScale, target, duration, easingType) { }

        public TransformScaleInterpolation(Transform transform, Vector3 origin, Vector3 target, float duration, EasingType easingType = EasingType.Linear) : base(transform, origin, target, duration, easingType) { }
        public TransformScaleInterpolation(Transform transform, Vector3 target, float duration, EasingType easingType = EasingType.Linear) : this(transform, transform.localScale, target, duration, easingType) { }

        public override void Process(float elapsedTime)
        {
            Value = Vector3.Lerp(Origin, Target, GetT(elapsedTime));
        }

        public override void Apply()
        {
            Reference.localScale = Value;
        }
    }
}
