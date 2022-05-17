using System;
using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Crystal : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private const float Speed = 5f;
        private bool _canDrop = false;
        public static event Action OnCollision;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void SetSprite(Sprite sprite)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

        private void FixedUpdate()
        {
            if (_canDrop)
            {
                _rigidbody.velocity = Vector3.down * Speed * 50f * Time.fixedDeltaTime;
            }
        }

        public void DropDown()
        {
            transform.SetParent(transform.root);
            _canDrop = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlatformMovement platform = collision.gameObject.GetComponent<PlatformMovement>();
            LostZone lostZone = collision.gameObject.GetComponent<LostZone>();

            if (platform)
            {
                OnCollision?.Invoke();
                Destroy(this.gameObject);
            }
            else if (lostZone)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
