using System;
using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    public class TransformRotationInterpolation : Interpolation<Transform, Quaternion>
    {
        public TransformRotationInterpolation(Transform transform, Func<Quaternion> origin, Func<Quaternion> target, float duration, EasingType easingType = EasingType.Linear) : base(transform, origin, target, duration, easingType) { }
        public TransformRotationInterpolation(Transform transform, Func<Quaternion> target, float duration, EasingType easingType = EasingType.Linear) : this(transform, () => transform.rotation, target, duration, easingType) { }

        public TransformRotationInterpolation(Transform transform, Quaternion origin, Quaternion target, float duration, EasingType easingType = EasingType.Linear) : base(transform, origin, target, duration, easingType) { }
        public TransformRotationInterpolation(Transform transform, Quaternion target, float duration, EasingType easingType = EasingType.Linear) : this(transform, transform.rotation, target, duration, easingType) { }

        public override void Process(float elapsedTime)
        {
            Value = Quaternion.Lerp(Origin, Target, GetT(elapsedTime));
        }

        public override void Apply()
        {
            Reference.rotation = Value;
        }
    }
}
