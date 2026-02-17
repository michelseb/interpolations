using UnityEngine;

namespace ZepLink.Interpolations.Impl
{
    public class TransformPositionInterpolation : Interpolation<Transform, Vector3>
    {
        private bool _startAtPosition;
        public TransformPositionInterpolation(Transform transform, Vector3 origin, Vector3 target, float duration) : base(transform, origin, target, duration) { }
        public TransformPositionInterpolation(Transform transform, Vector3 target, float duration) : this(transform, transform.position, target, duration) 
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
            Value = Vector3.Lerp(Origin, Target, elapsedTime / Duration);
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
