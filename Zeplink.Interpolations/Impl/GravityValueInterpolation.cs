using System;
using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    public class GravityValueInterpolation : Interpolation<Rigidbody2D, float>
    {
        public GravityValueInterpolation(Rigidbody2D reference, Func<float> origin, Func<float> target, float duration, EasingType easingType = EasingType.Linear) : base(reference, origin, target, duration, easingType) { }
        public GravityValueInterpolation(Rigidbody2D reference, float value, Func<float> origin, Func<float> target, float duration, EasingType easingType = EasingType.Linear) : base(reference, value, origin, target, duration, easingType) { }

        public GravityValueInterpolation(Rigidbody2D reference, float origin, float target, float duration, EasingType easingType = EasingType.Linear) : base(reference, origin, target, duration, easingType) { }
        public GravityValueInterpolation(Rigidbody2D reference, float value, float origin, float target, float duration, EasingType easingType = EasingType.Linear) : base(reference, value, origin, target, duration, easingType) { }

        public override void Apply()
        {
            Reference.gravityScale = Value;
        }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, GetT(elapsedTime));
        }
    }
}
