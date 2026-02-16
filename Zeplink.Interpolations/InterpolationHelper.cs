using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZepLink.Interpolations
{
    internal static class InterpolationHelper
    {
        public static IEnumerator Interpolate(IInterpolation interpolation, Action onEnd = null)
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
            onEnd?.Invoke();
        }

        public static IEnumerator ExecuteQueue(Queue<IInterpolation> queue)
        {
            if (queue == null)
                yield break;

            float elapsedTime = 0f;

            while (true)
            {
                while (queue.TryDequeue(out IInterpolation interpolation))
                {
                    interpolation.Init();

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

                yield return null;
            }
        }

        public static IEnumerator InterpolateListSimultaneous(IList<IInterpolation> interpolations, Action onEnd = null)
        {
            if (interpolations == null || interpolations.Count == 0)
                yield break;

            var elapsedTime = 0f;

            foreach (var interpolation in interpolations)
            {
                interpolation.Init();
            }

            while (interpolations.Any())
            {
                for (var i = 0; i < interpolations.Count; i++)
                {
                    var interpolation = interpolations[i];

                    interpolation.Process(elapsedTime);
                    interpolation.Apply();

                    if (elapsedTime >= interpolation.Duration)
                    {
                        interpolation.Complete();
                        interpolations.RemoveAt(i);
                    }
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            onEnd?.Invoke();
        }
    }
}
