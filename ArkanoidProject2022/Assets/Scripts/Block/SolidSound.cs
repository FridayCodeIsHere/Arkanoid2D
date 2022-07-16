using UnityEngine;

namespace ArkanoidProj
{
    public class SolidSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _soundCollision;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<BallMovement>())
            {
                AudioManager.Instance.PlaySound(_soundCollision.name);
            }
        }
    }
}

