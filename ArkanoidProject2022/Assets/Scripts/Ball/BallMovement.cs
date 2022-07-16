using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _lineEffect;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private bool _isActive = false;
        private const float Force = 10f;

        private void OnEnable()
        {
            FingerInput.OnClicked += BallActivate;
        }

        private void OnDisable()
        {
            FingerInput.OnClicked -= BallActivate;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        public void Start()
        {
            //BallActivate();
            _animator.SetTrigger("Create");
        }

        private void BallActivate()
        {
            if (!_isActive)
            {
                _lineEffect.SetActive(true);
                _isActive = true;
                transform.SetParent(null);
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                AddForce(0, -1); //fall down at the start
            }

            
        }

        public void AddForce(float dirX = 0f, float dirY = 1f)
        {
            _rigidbody.velocity = new Vector2(dirX * 4, dirY).normalized * Force;
        }
    }
}
