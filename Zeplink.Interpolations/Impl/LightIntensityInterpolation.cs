using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    public class LightIntensityInterpolation : Interpolation<Light2D, float>
    {
        public LightIntensityInterpolation(Light2D light, float value, Func<float> origin, Func<float> target, float duration, EasingType easingType = EasingType.Linear) : base(light, value, origin, target, duration, easingType) { }
        public LightIntensityInterpolation(Light2D light, float value, float origin, float target, float duration, EasingType easingType = EasingType.Linear) : base(light, value, origin, target, duration, easingType) { }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, GetT(elapsedTime));
        }

        public override void Apply()
        {
            Reference.intensity = Value;
        }
    }
}
