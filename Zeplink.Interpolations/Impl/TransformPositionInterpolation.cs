using System;
using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    public class TransformPositionInterpolation : Interpolation<Transform, Vector3>
    {
        private bool _startAtPosition;
        public TransformPositionInterpolation(Transform transform, Func<Vector3> origin, Func<Vector3> target, float duration, EasingType easingType = EasingType.Linear) : base(transform, origin, target, duration, easingType) { }
        public TransformPositionInterpolation(Transform transform, Func<Vector3> target, float duration, EasingType easingType = EasingType.Linear) : this(transform, () => transform.position, target, duration, easingType)
        {
            _startAtPosition = true;
        }
        public TransformPositionInterpolation(Transform transform, Vector3 origin, Vector3 target, float duration, EasingType easingType = EasingType.Linear) : base(transform, origin, target, duration, easingType) { }
        public TransformPositionInterpolation(Transform transform, Vector3 target, float duration, EasingType easingType = EasingType.Linear) : this(transform, transform.position, target, duration, easingType) 
        {
            _startAtPosition = true;
        }

        public override void Init()
        {
            base.Init();

            if (_startAtPosition)
            {
                Origin = Reference.position;
            }
        }

        public override void Process(float elapsedTime)
        {
            Value = Vector3.Lerp(Origin, Target, GetT(elapsedTime));
        }

        public override void Apply()
        {
            Reference.position = Value;
        }

        public override void Complete()
        {
            Reference.position = Target;
            _onEnd?.Invoke();
        }
    }
}
