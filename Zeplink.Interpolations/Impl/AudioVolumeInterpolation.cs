using UnityEngine;

namespace ZepLink.Interpolations.Impl
{
    public class AudioVolumeInterpolation : Interpolation<AudioSource, float>
    {
        public AudioVolumeInterpolation(AudioSource audio, float value, float origin, float target, float duration) : base(audio, value, origin, target, duration) { }
        public AudioVolumeInterpolation(AudioSource audio, float origin, float target, float duration) : this(audio, origin, origin, target, duration) { }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, elapsedTime / Duration);
        }

        public override void Apply()
        {
            Reference.volume = Value;
        }
    }
}
