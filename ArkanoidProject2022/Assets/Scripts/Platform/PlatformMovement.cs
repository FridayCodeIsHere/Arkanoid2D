using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{

    [RequireComponent(typeof(Rigidbody2D), typeof(FingerInput), typeof(SpriteRenderer))]
    public class PlatformMovement : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed = 10f;

        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;

        private float _progress;
        private float _halfWidthPlatform;
        private const float BorderPosition = 5.1f;

        #region MonoBehaviour 
        private void OnValidate()
        {
            if (_speed < 0) _speed = 0;
        }
        #endregion


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _halfWidthPlatform = _spriteRenderer.size.x / 2;
        }

        private void FixedUpdate()
        {
            Vector3 targetNormalized = new Vector3(_target.position.x, transform.position.y);
            transform.position = Vector3.Lerp(transform.position, targetNormalized, _speed * Time.fixedDeltaTime);
        }

        public void ResetPosition()
        {
            _rigidbody.position = new Vector2(0f, _rigidbody.position.y);
        }

        public float GetSize()
        {
            Vector2 size = _rigidbody.GetComponent<SpriteRenderer>().size;
            return size.x;
        }
    }
}
