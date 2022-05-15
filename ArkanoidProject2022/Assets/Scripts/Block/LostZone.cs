using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj {
    public class LostZone : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallMovement ball))
            {
                Destroy(ball.gameObject);
            }
        }
    }
}
