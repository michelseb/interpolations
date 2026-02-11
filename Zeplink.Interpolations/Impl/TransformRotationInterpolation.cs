using UnityEngine;

namespace ZepLink.Interpolations.Impl
{
    public class TransformRotationInterpolation : Interpolation<Transform, Quaternion>
    {
        public TransformRotationInterpolation(Transform transform, Quaternion origin, Quaternion target, float duration) : base(transform, origin, target, duration) { }
        public TransformRotationInterpolation(Transform transform, Quaternion target, float duration) : this(transform, transform.rotation, target, duration) { }

        public override void Process(float elapsedTime)
        {
            Value = Quaternion.Lerp(Origin, Target, elapsedTime / Duration);
        }

        public override void Apply()
        {
            Reference.rotation = Value;
        }
    }
}
