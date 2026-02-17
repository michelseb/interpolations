using System;
using UnityEngine;

namespace ZepLink.Interpolations.Impl
{
    public class GravityValueInterpolation : Interpolation<Rigidbody2D, float>
    {
        public GravityValueInterpolation(Rigidbody2D reference, Func<float> origin, Func<float> target, float duration) : base(reference, origin, target, duration) { }
        public GravityValueInterpolation(Rigidbody2D reference, float value, Func<float> origin, Func<float> target, float duration) : base(reference, value, origin, target, duration) { }

        public GravityValueInterpolation(Rigidbody2D reference, float origin, float target, float duration) : base(reference, origin, target, duration) { }
        public GravityValueInterpolation(Rigidbody2D reference, float value, float origin, float target, float duration) : base(reference, value, origin, target, duration) { }

        public override void Apply()
        {
            Reference.gravityScale = Value;
        }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, elapsedTime / Duration);
        }
    }
}
