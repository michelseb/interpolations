using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZepLink.Interpolations
{
    public class InterpolationController : MonoBehaviour
    {
        private Queue<IInterpolation> _queue;

        private void Awake()
        {
            _queue = new Queue<IInterpolation>();
        }

        private void Start()
        {
            StartCoroutine(InterpolationHelper.ExecuteQueue(_queue));
        }

        public void Run(IInterpolation interpolation, Action onEnd = null)
        {
            StartCoroutine(InterpolationHelper.Interpolate(interpolation, onEnd));
        }

        public void AddToQueue(IInterpolation interpolation)
        {
            _queue.Enqueue(interpolation);
        }

        public void AddToQueue(IList<IInterpolation> interpolations)
        {
            foreach (IInterpolation interpolation in interpolations)
            {
                _queue.Enqueue(interpolation);
            }
        }

        public void RunListSimultaneous(IList<IInterpolation> interpolations, Action onEnd = null)
        {
            StartCoroutine(InterpolationHelper.InterpolateListSimultaneous(interpolations, onEnd));
        }
    }
}
