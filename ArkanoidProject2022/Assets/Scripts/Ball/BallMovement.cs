using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BallSound))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _lineEffect;
        private Rigidbody2D _rigidbody;
        private BallSound _ballSound;
        private bool _isActive = false;
        private const float Force = 10f;
        private float _lastPositionX;

        private void OnEnable()
        {
            PlatformInput.OnClicked += BallActivate;
        }

        private void OnDisable()
        {
            PlatformInput.OnClicked -= BallActivate;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _ballSound = GetComponent<BallSound>();
        }

        private void BallActivate()
        {
            if (!_isActive)
            {
                _lineEffect.SetActive(true);
                _lastPositionX = transform.position.x;
                _isActive = true;
                transform.SetParent(null);
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                AddForce(0, -1); //fall down at the start
                _ballSound.PlaySoundCollision();
            }

            
        }

        public void AddForce(float dirX = 0f, float dirY = 1f)
        {
            _rigidbody.velocity = new Vector2(dirX * 4, dirY).normalized * Force;
        }
    }
}
