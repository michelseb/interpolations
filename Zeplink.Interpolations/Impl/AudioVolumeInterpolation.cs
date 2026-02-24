using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    public class AudioVolumeInterpolation : Interpolation<AudioSource, float>
    {
        public AudioVolumeInterpolation(AudioSource audio, float value, float origin, float target, float duration, EasingType easingType = EasingType.Linear) : base(audio, value, origin, target, duration, easingType) { }
        public AudioVolumeInterpolation(AudioSource audio, float origin, float target, float duration, EasingType easingType = EasingType.Linear) : this(audio, origin, origin, target, duration, easingType) { }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, GetT(elapsedTime));
        }

        public override void Apply()
        {
            Reference.volume = Value;
        }
    }
}
