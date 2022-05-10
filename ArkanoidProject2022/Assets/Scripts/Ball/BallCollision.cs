using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(BallMovement))]
    public class BallCollision : MonoBehaviour
    {
        private BallMovement _ballMovement;
        private float _lastPositionX;

        private void Awake()
        {
            _ballMovement = GetComponent<BallMovement>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            float ballPositionX = transform.position.x;

            if (collision.gameObject.TryGetComponent(out PlatformMovement platformMove))
            {
                if (ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1)
                {
                    float collisionPointX = collision.contacts[0].point.x;
                    float playerCenterPosition = platformMove.gameObject.transform.position.x;
                    float difference = playerCenterPosition - collisionPointX;
                    float direction = collisionPointX < playerCenterPosition ? -1 : 1;
                    _ballMovement.AddForce(direction * Mathf.Abs(difference));
                }
            }
            _lastPositionX = ballPositionX;

            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage();
            }
        }
    }
}

