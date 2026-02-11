using UnityEngine;

namespace ZepLink.Interpolations.Impl
{
    public class CameraColorInterpolation : Interpolation<Camera, Color>
    {
        public CameraColorInterpolation(Camera reference, Color origin, Color target, float duration) : base(reference, origin, target, duration) { }

        public override void Apply()
        {
            Reference.backgroundColor = Value;
        }

        public override void Process(float elapsedTime)
        {
            Value = Color.Lerp(Origin, Target, elapsedTime / Duration);
        }
    }
}
