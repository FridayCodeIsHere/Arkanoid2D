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

        private void OnEnable()
        {
            PlatformInput.OnClicked += BallActivate;
        }

        private void OnDisable()
        {
            PlatformInput.OnClicked -= BallActivate;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void BallActivate()
        {
            if (_isActive)
            {
                _lastPositionX = transform.position.x;
                _isActive = true;
                transform.SetParent(null);
            }

            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            AddForce();
        }

        public void AddForce(float direction = 0f)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(new Vector2(direction * (Force / 2), Force));
        }
    }
}
