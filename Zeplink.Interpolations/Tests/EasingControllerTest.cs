using System.Collections;
using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    [RequireComponent(typeof(InterpolationController))]
    public class EasingControllerTest : MonoBehaviour
    {
        private InterpolationController _controller;

        [SerializeField] private EasingType _easing;
        [SerializeField][Range(0, 2)] private float _animationDuration;
        [SerializeField][Range(0, 2)] private float _pauseDuration;

        private void Awake()
        {
            _controller = GetComponent<InterpolationController>();
        }

        private void Start()
        {
            StartCoroutine(Execute());
        }

        private IEnumerator Execute()
        {
            float yPosition = 1;

            while (true)
            {
                _controller.Run(new TransformPositionInterpolation(transform, new Vector3(transform.position.x, yPosition), _animationDuration, _easing));
                yPosition = -yPosition;

                yield return new WaitForSeconds(_pauseDuration + _animationDuration);
            }
        }
    }
}
