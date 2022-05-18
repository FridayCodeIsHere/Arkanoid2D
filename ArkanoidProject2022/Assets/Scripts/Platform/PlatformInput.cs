using System;
using UnityEngine;

namespace ArkanoidProj
{
    public class PlatformInput : MonoBehaviour
    {
        public static event Action<float> OnMove;
        public static event Action OnClicked;

        private Vector2 _startPosition = Vector2.zero;
        private float _direction = 0f;
        private float _touchPosition;

        private void Update()
        {
#if UNITY_EDITOR
            OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClicked?.Invoke();
            }
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

                if (touch.tapCount > 1)
                {
                    OnClicked?.Invoke();
                }

                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        if (touch.position.x > _startPosition.x + 0.5f) _direction = 1f;
                        else if (touch.position.x < _startPosition.x - 0.5f) _direction = -1f;
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

