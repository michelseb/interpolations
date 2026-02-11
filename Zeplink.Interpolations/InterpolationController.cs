using System.Collections.Generic;
using UnityEngine;

namespace ZepLink.Interpolations
{
    public class InterpolationController : MonoBehaviour
    {
        public void Run(IInterpolation interpolation)
        {
            StartCoroutine(InterpolationHelper.Interpolate(interpolation));
        }

        public void RunListSequential(IList<IInterpolation> interpolations)
        {
            StartCoroutine(InterpolationHelper.InterpolateListSequential(interpolations));
        }

        public void RunListSimultaneous(IList<IInterpolation> interpolations)
        {
            StartCoroutine(InterpolationHelper.InterpolateListSimultaneous(interpolations));
        }
    }
}
