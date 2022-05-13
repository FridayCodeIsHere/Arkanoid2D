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
#if UNITY_EDITOR
                    DestroyImmediate(block.gameObject);
#else
                    Destroy(block.gameObject);
#endif
                }
            }

        }
    }
}

