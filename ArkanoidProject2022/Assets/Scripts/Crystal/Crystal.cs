using System;
using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Crystal : MonoBehaviour
    {
        public static int Count { get; private set; }
        [SerializeField] private TrailRenderer _lineEffect;
        private Rigidbody2D _rigidbody;
        private Vector3 _crystalUiPos;
        private const float Speed = 5f;
        private bool _canDrop = false;
        private bool _isCollision = false;
        public static event Action OnCollision;
        public static event Action OnEnded;

        private void OnEnable()
        {
            Count++;
        }

        private void OnDisable()
        {
            Count--;
            if (Block.Count < 1 && Count < 1)
            {
                OnEnded?.Invoke();
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            //_crystalUiPos = Camera.main.ScreenToWorldPoint(CrystalImage.Instance.GetCrystalPosition());
            _crystalUiPos = CrystalImage.Instance.GetCrystalPosition();
        }
        public void SetData(Sprite sprite, Gradient colorGradient)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            _lineEffect.colorGradient = colorGradient;
            spriteRenderer.sprite = sprite;
        }

        private void Update()
        {
            if (_canDrop)
            {
                if (false)
                {
                    //transform.position = Vector3.MoveTowards(transform.position, _crystalUiPos, Speed * 32f * Time.deltaTime);
                    //if (Vector2.Distance(transform.position, _crystalUiPos) < 0.2f)
                    //{
                    //    TakenCrystal();
                    //}
                }
                else
                {
                    transform.Translate(Vector2.down * Speed * Time.deltaTime);
                }
                
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

            if (platform && !_isCollision)
            {
                TakenCrystal();
                _isCollision = true;
            }
            else if (lostZone)
            {
                Destroy(this.gameObject);
            }


        }

        private void TakenCrystal()
        {
            AudioManager.Instance.PlaySound("ApplyCrystal");
            OnCollision?.Invoke();
            Destroy(this.gameObject);
        }
    }
}

