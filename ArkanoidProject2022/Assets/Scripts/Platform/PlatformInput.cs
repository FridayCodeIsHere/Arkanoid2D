using System;
using UnityEngine;

namespace ArkanoidProj
{
    public class PlatformInput : MonoBehaviour
    {
        public static event Action<float> OnMove;
        private Vector2 _startPosition = Vector2.zero;
        private float _direction = 0f;

        private void Update()
        {
#if UNITY_EDITOR
            OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
#endif

#if UNITY_ANDROID
            GetInputTouch();
#endif
        }

        private void GetInputTouch()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        if (touch.position.x > _startPosition.x + 15f) _direction = 1f;
                        else if (touch.position.x < _startPosition.x - 15f) _direction = -1f;
                        break;
                    default:
                        _startPosition = touch.position;
                        _direction = 0f;
                        break;
                }
                OnMove?.Invoke(_direction);
            }
        }
    }
}

