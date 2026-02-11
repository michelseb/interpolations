using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZepLink.Interpolations
{
    public class InterpolationController : MonoBehaviour
    {
        public void Run(IInterpolation interpolation, Action onEnd = null)
        {
            StartCoroutine(InterpolationHelper.Interpolate(interpolation, onEnd));
        }

        public void RunListSequential(IList<IInterpolation> interpolations, Action onEnd = null)
        {
            StartCoroutine(InterpolationHelper.InterpolateListSequential(interpolations, onEnd));
        }

        public void RunListSimultaneous(IList<IInterpolation> interpolations, Action onEnd = null)
        {
            StartCoroutine(InterpolationHelper.InterpolateListSimultaneous(interpolations, onEnd));
        }
    }
}
