using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZepLink.Interpolations
{
    internal static class InterpolationHelper
    {
        public static IEnumerator Interpolate(IInterpolation interpolation)
        {
            float elapsedTime = 0f;

            interpolation.Init();

            while (elapsedTime < interpolation.Duration)
            {
                interpolation.Process(elapsedTime);
                interpolation.Apply();

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            interpolation.Complete();
        }

        public static IEnumerator InterpolateListSequential(IList<IInterpolation> interpolations)
        {
            if (interpolations == null || interpolations.Count == 0)
                yield break;

            float elapsedTime = 0f;

            for (var i = 0; i < interpolations.Count; i++)
            {
                var interpolation = interpolations[i];

                while (elapsedTime < interpolation.Duration)
                {
                    interpolation.Process(elapsedTime);
                    interpolation.Apply();

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }

                interpolation.Complete();
                elapsedTime = 0f;
            }
        }

        public static IEnumerator InterpolateListSimultaneous(IList<IInterpolation> interpolations)
        {
            if (interpolations == null || interpolations.Count == 0)
                yield break;

            var elapsedTime = 0f;
            var runningInterpolations = interpolations.Where(i => i.Duration > elapsedTime).ToList();

            while (runningInterpolations.Any())
            {
                runningInterpolations.ForEach(i =>
                {
                    i.Process(elapsedTime);
                    i.Apply();

                    if (elapsedTime >= i.Duration)
                    {
                        i.Complete();
                        runningInterpolations.Remove(i);
                    }
                });

                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
