using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FingerMove : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private const float BorderPosition = 5.1f;
        private float _halfWidthPlatform;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _halfWidthPlatform = _spriteRenderer.size.x / 2;
        }
        private void FixedUpdate()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = Mathf.Clamp(mousePos.x, -BorderPosition + (_halfWidthPlatform), BorderPosition - (_halfWidthPlatform));
            transform.position = new Vector3(mousePos.x, transform.position.y);
        }
    }
}