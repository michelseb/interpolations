using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ZepLink.Interpolations.Impl
{
    public class BloomIntensityInterpolation : Interpolation<Bloom, float>
    {
        public BloomIntensityInterpolation(Bloom reference, Func<float> origin, Func<float> target, float duration) : base(reference, origin, target, duration) { }
        public BloomIntensityInterpolation(Bloom reference, float origin, float target, float duration) : base(reference, origin, target, duration) { }

        public override void Apply()
        {
            Reference.intensity.value = Value;
        }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, elapsedTime / Duration);
        }
    }
}
