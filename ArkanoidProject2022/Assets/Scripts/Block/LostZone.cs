using UnityEngine;

namespace ArkanoidProj {
    public class LostZone : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallMovement ball))
            {
                Destroy(ball.gameObject);
                AudioManager.Instance.PlaySound("RestartBall");
            }
        }
    }
}
