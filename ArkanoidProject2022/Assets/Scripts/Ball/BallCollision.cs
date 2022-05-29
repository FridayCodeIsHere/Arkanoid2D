using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(BallMovement))]
    public class BallCollision : MonoBehaviour
    {
        private BallMovement _ballMovement;
        private Vector2 _lastPosition;
        private float _lastDirection;

        private void Awake()
        {
            _ballMovement = GetComponent<BallMovement>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 currentPosition = transform.position;
            PlatformMovement platformMove = collision.gameObject.GetComponent<PlatformMovement>();

            if (platformMove)
            {
                if (currentPosition.x < _lastPosition.x + 0.1f && currentPosition.x > _lastPosition.x - 0.1f)
                {
                    float collisionPointX = collision.contacts[0].point.x;
                    float platformCenterPos = platformMove.gameObject.transform.position.x;

                    float difference = platformCenterPos - collisionPointX;
                    float direction = collisionPointX < platformCenterPos ? -1 : 1;
                    _ballMovement.AddForce(direction * Mathf.Abs(difference), 1); //always shoot up from platform
                    Debug.Log($"Direction {direction}, Difference: {difference}");
                    _lastDirection = direction;
                }
            }
            else
            {
                if (currentPosition.y < _lastPosition.y + 0.3f && currentPosition.y > _lastPosition.y - 0.3f)
                {
                    //_ballMovement.AddForce(Random.Range(0,1));
                }
            }
            _lastPosition = currentPosition;

            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage();
            }

            if (collision.gameObject.TryGetComponent(out BlockComposite blockComposite))
            {
                blockComposite.ApplyDamage(collision.contacts[0].point);
            }
        }
    }
}

