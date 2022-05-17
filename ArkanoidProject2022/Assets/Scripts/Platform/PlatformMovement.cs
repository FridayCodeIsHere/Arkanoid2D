using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{

    [RequireComponent(typeof(Rigidbody2D), typeof(PlatformInput), typeof(SpriteRenderer))]
    public class PlatformMovement : MonoBehaviour
    {

        [SerializeField] private float _speed = 15f;

        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;

        private float _moveX = 0f;
        private float _halfWidthPlatform;
        private const float BorderPosition = 5.1f;

        #region MonoBehaviour 
        private void OnValidate()
        {
            if (_speed < 0) _speed = 0;
        }
        #endregion

        private void OnEnable()
        {
            PlatformInput.OnMove += Move;
        }

        private void OnDisable()
        {
            PlatformInput.OnMove -= Move;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _halfWidthPlatform = _spriteRenderer.size.x / 2;
        }

        private void FixedUpdate()
        {
            float positionX = _rigidbody.position.x + _moveX * _speed * Time.fixedDeltaTime;
            positionX = Mathf.Clamp(positionX, -BorderPosition + (_halfWidthPlatform), BorderPosition - (_halfWidthPlatform));
            _rigidbody.MovePosition(new Vector2(positionX, _rigidbody.position.y));
        }

        private void Move(float moveX)
        {
            _moveX = moveX;
        }

        public void ResetPosition()
        {
            _rigidbody.position = new Vector2(0f, _rigidbody.position.y);
        }
    }
}
