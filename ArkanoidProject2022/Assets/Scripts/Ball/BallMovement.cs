using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private bool _isActive = false;
        private const float Force = 400f;
        private float _lastPositionX;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space) && _isActive == false)
            {
                BallActivate();
            }
#endif

#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.tapCount > 1)
                {
                    BallActivate();
                }
            }
#endif
        }


        private void BallActivate()
        {
            _lastPositionX = transform.position.x;
            _isActive = true;
            transform.SetParent(null);

            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.AddForce(Vector2.up * Force);
        }

        public void MoveCollision(Collision2D collision)
        {
            float ballPositionX = transform.position.x;

            if (collision.gameObject.TryGetComponent(out PlatformMovement platform))
            {
                if (ballPositionX < _lastPositionX + 0.1f && ballPositionX > _lastPositionX - 0.1f)
                {
                    float collisionPointX = collision.contacts[0].point.x;
                    _rigidbody.velocity = Vector2.zero;

                    float platformCenterPosition = platform.gameObject.GetComponent<Transform>().position.x;
                    float difference = platformCenterPosition - collisionPointX;
                    float direction = collisionPointX < platformCenterPosition ? -1 : 1;

                    _rigidbody.AddForce(new Vector2(direction * Mathf.Abs(difference * (Force / 2)), Force));
                }
            }
            _lastPositionX = ballPositionX;
        }
    }
}
