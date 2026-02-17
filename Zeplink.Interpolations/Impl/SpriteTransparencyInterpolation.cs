using UnityEngine;

namespace ZepLink.Interpolations.Impl
{
    public class SpriteTransparencyInterpolation : Interpolation<SpriteRenderer, float>
    {
        public SpriteTransparencyInterpolation(SpriteRenderer reference, float origin, float target, float duration) : base(reference, origin, target, duration) { }

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
            Value = Mathf.Lerp(Origin, Target, elapsedTime / Duration);
        }
    }
}
