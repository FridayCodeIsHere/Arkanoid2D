using UnityEngine;
using System;

namespace ArkanoidProj
{
    public class ClearLevel : MonoBehaviour
    {
        public void Clear()
        {
            DeleteObjectsOfType<Block>();
            DeleteObjectsOfType<BallMovement>();
            DeleteObjectsOfType<Crystal>();
        }

        private void DeleteObjectsOfType<T>() where T : UnityEngine.Component
        {
            T[] items = FindObjectsOfType<T>();

            if (items.Length > 0)
            {
                foreach(T item in items)
                {
                    DestroyItem(item.gameObject);
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

