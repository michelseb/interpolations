using UnityEngine;
using ZepLink.Interpolations.Easings;

namespace ZepLink.Interpolations.Impl
{
    [RequireComponent(typeof(InterpolationController))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class DynamicInterpolationTest : MonoBehaviour
    {
        private InterpolationController _controller;
        private Camera _camera;
        private SpriteRenderer _renderer;

        [SerializeField] private EasingType _easing;
        [SerializeField][Range(0, 2)] private float _animationDuration;

        private void Awake()
        {
            _controller = GetComponent<InterpolationController>();
            _renderer = GetComponent<SpriteRenderer>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition);

                _controller.Run(
                    new TransformPositionInterpolation(transform, new Vector3(pos.x, pos.y), _animationDuration, _easing),
                    () => { _renderer.color = Random.ColorHSV(); },
                    true);
            }
        }
    }
}
