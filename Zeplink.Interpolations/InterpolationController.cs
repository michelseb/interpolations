using System.Collections.Generic;
using UnityEngine;

namespace ZepLink.Interpolations
{
    public class InterpolationController : MonoBehaviour
    {
        public void Run<T, U>(Interpolation<T, U> interpolation) where T : Component where U : struct
        {
            StartCoroutine(InterpolationHelper<T, U>.Interpolate(interpolation));
        }

        public void RunList<T, U>(IList<Interpolation<T, U>> interpolations) where T : Component where U : struct
        {
            StartCoroutine(InterpolationHelper<T, U>.InterpolateList(interpolations));
        }
    }
}
