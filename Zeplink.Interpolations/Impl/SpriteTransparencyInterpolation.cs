using System;
using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    public class SpriteTransparencyInterpolation : Interpolation<SpriteRenderer, float>
    {
        public SpriteTransparencyInterpolation(SpriteRenderer reference, Func<float> origin, Func<float> target, float duration, EasingType easingType = EasingType.Linear) : base(reference, origin, target, duration, easingType) { }
        public SpriteTransparencyInterpolation(SpriteRenderer reference, float origin, float target, float duration, EasingType easingType = EasingType.Linear) : base(reference, origin, target, duration, easingType) { }
        public SpriteTransparencyInterpolation(SpriteRenderer reference, float target, float duration, EasingType easingType = EasingType.Linear) : base(reference, reference.color.a, target, duration, easingType) { }

        private Color _referenceColor;

        public override void Init()
        {
            base.Init();

            _referenceColor = Reference.color;
        }

        public override void Apply()
        {
            _referenceColor.a = Value;
            Reference.color = _referenceColor;
        }

        public override void Process(float elapsedTime)
        {
            Value = Mathf.Lerp(Origin, Target, GetT(elapsedTime));
        }
    }
}
