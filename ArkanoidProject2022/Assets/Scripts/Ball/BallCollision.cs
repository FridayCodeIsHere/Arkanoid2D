using UnityEngine;
using System;

namespace ArkanoidProj
{
    [RequireComponent(typeof(BallMovement), typeof(BallSound))]
    public class BallCollision : MonoBehaviour
    {
        private BallMovement _ballMovement;
        private const float HORIZONTAL_ANGLE_LIMIT = 7; //ratio "x:y" of a possible bounce to unstuck horizontally flying ball = ~8° 
        private BallSound _ballSound;
        private long lastPlatformHit = currentTime();

        private void Awake()
        {
            _ballMovement = GetComponent<BallMovement>();
            _ballSound = GetComponent<BallSound>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
       
            PlatformMovement platformMove = collision.gameObject.GetComponent<PlatformMovement>();
            
            //ignore unity physics bug with multiple collisions at once
            if (platformMove)
            {
                if (lastPlatformHit + 50 < currentTime())
                {
                    lastPlatformHit = currentTime();
                }
                else {
                    return;
                }
            }

            _ballSound.PlaySoundCollision();

            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage();
            }

            if (collision.gameObject.TryGetComponent(out BlockComposite blockComposite))
            {
                blockComposite.ApplyDamage(collision.contacts[0].point);
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = calculateBounce(collision, platformMove);
        }

        private Vector2 calculateBounce(Collision2D collision, PlatformMovement platformMove) {

            //ContactPoint2D contact = collision.contacts[0];
            Vector2 curDir = gameObject.GetComponent<Rigidbody2D>().velocity;
            float origSpeed = curDir.magnitude; //original speed

            //never bounce down from side of board
            if (platformMove) {
                if (curDir.y < 0) {
                    curDir.y = -curDir.y; //revert direction to top
                }
            }

            //change direction based on collision place on platform
            if (platformMove) {
                float collisionPointX = collision.contacts[0].point.x;
                float platformCenterPos = platformMove.gameObject.transform.position.x;
                float size = platformMove.GetSize();

                //the further the ball is, the bigger angle of bounce
                float sideInPercent = (collisionPointX - platformCenterPos) * 2 / size;
                
                float x = sideInPercent * HORIZONTAL_ANGLE_LIMIT;
                curDir.x = x;
                curDir.y = 1; //always top, just the ratio is important now, normalization will happen later
                }

            //correct too horizontal directions
            if (Math.Abs(curDir.x) > HORIZONTAL_ANGLE_LIMIT * Math.Abs(curDir.y))
            {//bounce is too horizontal
                Vector2 newDir = new Vector2();
                float x = curDir.x;
                float y = curDir.y;
                newDir.x = x / Math.Abs(x) * HORIZONTAL_ANGLE_LIMIT; //max allowed X speed ratio, keeps the direction
                newDir.y = y / Math.Abs(y);
                newDir = newDir.normalized * origSpeed; //keep the corrected direction, set the original speed
                curDir = newDir;
            }

            return curDir.normalized * origSpeed; //keep the corrected direction, set the original speed

        }

        private static long currentTime() { 
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}

