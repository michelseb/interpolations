using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ZepLink.Interpolations.Impl
{
    public class LightIntensityInterpolation : Interpolation<Light2D, float>
    {
        public LightIntensityInterpolation(Light2D light, float value, float origin, float target, float duration) : base(light, value, origin, target, duration) { }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, elapsedTime / Duration);
        }

        public override void Apply()
        {
            Reference.intensity = Value;
        }
    }
}
