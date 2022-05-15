using UnityEngine;

namespace ArkanoidProj
{
    public class ClearLevel : MonoBehaviour
    {
        public void Clear()
        {
            Block[] blocks = FindObjectsOfType<Block>();

            if (blocks.Length > 0)
            {
                foreach (Block block in blocks)
                {
                    DestroyItem(block.gameObject);
                }
            }
            BallMovement[] balls = FindObjectsOfType<BallMovement>();
            if (balls.Length > 0)
            {
                foreach(BallMovement ball in balls)
                {
                    DestroyItem(ball.gameObject);
                }
            }
        }

        private void DestroyItem(GameObject item)
        {
#if UNITY_EDITOR
            DestroyImmediate(item.gameObject);
#else
            Destroy(item.gameObject);
#endif
        }
    }
}

