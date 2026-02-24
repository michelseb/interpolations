using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    [RequireComponent(typeof(InterpolationController))]
    public class InterpolationControllerTest : MonoBehaviour
    {
        private InterpolationController _controller;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _controller = GetComponent<InterpolationController>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            StartCoroutine(Execute());
        }

        private IEnumerator Execute()
        {
            /** 
             * Simple position interpolation
             **/
            _controller.Run(new TransformPositionInterpolation(transform, new Vector3(0, 1), .5f));

            yield return new WaitForSeconds(2);

            /**
             * 3 queued position interpolations
             * Should execute sequentially
             **/
            _controller.AddToQueue(new TransformPositionInterpolation(transform, new Vector3(2, 0), .5f));
            _controller.AddToQueue(new TransformPositionInterpolation(transform, new Vector3(0, 1), .5f));
            _controller.AddToQueue(new TransformPositionInterpolation(transform, new Vector3(2, 1), .5f));

            yield return new WaitForSeconds(3);

            /**
             * 3 simultaneous interpolations
             * - position
             * - sprite transparency
             * - scale
             * Should execute simultaneously
             **/
            _controller.RunListSimultaneous(new List<IInterpolation>
                {
                    new TransformPositionInterpolation(transform, new Vector3(-2, -1), 1),
                    new SpriteTransparencyInterpolation(_renderer, .5f, 1),
                    new TransformScaleInterpolation(transform, Vector3.one * 2, 3)
                });

            yield return new WaitForSeconds(4);

            /**
             * 5 interpolations with all different easing types
             * - linear
             * - easeIn
             * - easeOut
             * - easeInOut
             * - smoothStep
             **/

            _controller.Run(new TransformPositionInterpolation(transform, new Vector3(0, 2), 1, EasingType.Linear));
            yield return new WaitForSeconds(2);
            _controller.Run(new TransformPositionInterpolation(transform, new Vector3(0, -2), 1, EasingType.EaseIn));
            yield return new WaitForSeconds(2);
            _controller.Run(new TransformPositionInterpolation(transform, new Vector3(0, 2), 1, EasingType.EaseOut));
            yield return new WaitForSeconds(2);
            _controller.Run(new TransformPositionInterpolation(transform, new Vector3(0, -2), 1, EasingType.EaseInOut));
            yield return new WaitForSeconds(2);
            _controller.Run(new TransformPositionInterpolation(transform, new Vector3(0, 2), 1, EasingType.SmoothStep));

        }
    }
}
