using System.Collections.Generic;

namespace ZepLink.Interpolations.Easings
{
    public static class EasingFactory
    {
        private static readonly IDictionary<EasingType, Easing> _easings = new Dictionary<EasingType, Easing>
        {
            { EasingType.Linear, new Linear() },
            { EasingType.EaseIn, new EaseIn() },
            { EasingType.EaseOut, new EaseOut() },
            { EasingType.EaseInOut, new EaseInOut() },
            { EasingType.SmoothStep, new SmoothStep() }
        };

        public static Easing Get(EasingType easingType)
        {
            if (_easings.TryGetValue(easingType, out Easing result))
                return result;

            throw new KeyNotFoundException($"Easing of type {easingType} is not supported");
        }
    }
}
