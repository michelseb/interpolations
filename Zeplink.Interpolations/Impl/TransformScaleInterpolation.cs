using UnityEngine;

namespace ZepLink.Interpolations.Impl
{
    public class TransformScaleInterpolation : Interpolation<Transform, Vector3>
    {
        public TransformScaleInterpolation(Transform transform, Vector3 origin, Vector3 target, float duration) : base(transform, origin, target, duration) { }
        public TransformScaleInterpolation(Transform transform, Vector3 target, float duration) : this(transform, transform.localScale, target, duration) { }

        public override void Process(float elapsedTime)
        {
            Value = Vector3.Lerp(Origin, Target, elapsedTime / Duration);
        }

        public override void Apply()
        {
            Reference.localScale = Value;
        }
    }
}
