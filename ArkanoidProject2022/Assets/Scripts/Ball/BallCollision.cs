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
            PlatformMovement platformMove = collision.gameObject.GetComponent<PlatformMovement>();

            if (platformMove)
            {
                if (ballPositionX < _lastPositionX + 0.1f && ballPositionX > _lastPositionX - 0.1f)
                {
                    float collisionPointX = collision.contacts[0].point.x;
                    float platformCenterPos = platformMove.gameObject.transform.position.x;
                    
                    float difference = platformCenterPos - collisionPointX;
                    float direction = collisionPointX < platformCenterPos ? -1 : 1;
                    _ballMovement.AddForce(direction * Mathf.Abs(difference));
                }
            }
            _lastPositionX = ballPositionX;

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

