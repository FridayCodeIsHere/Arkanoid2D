using UnityEngine;
using System;

namespace ArkanoidProj
{
    public class ClearLevel : MonoBehaviour
    {
        public void Clear()
        {
            DeleteObjectsOfTypeEditor<Block>();
            DeleteObjectsOfTypeEditor<BallMovement>();
            DeleteObjectsOfTypeEditor<Crystal>();
        }

        public void ClearLevelItems()
        {
            DeleteObjectsOfTypeGame<Block>();
            DeleteObjectsOfTypeGame<BallMovement>();
            DeleteObjectsOfTypeGame<Crystal>();
        }

        private void DeleteObjectsOfTypeEditor<T>() where T : UnityEngine.Component
        {
            T[] items = FindObjectsOfType<T>();

            if (items.Length > 0)
            {
                foreach(T item in items)
                {
                    DestroyImmediate(item.gameObject);
                }
            }
        }

        private void DeleteObjectsOfTypeGame<T>() where T : UnityEngine.Component
        {
            T[] items = FindObjectsOfType<T>();

            if (items.Length > 0)
            {
                foreach (T item in items)
                {
                    Destroy(item.gameObject);
                }
            }
        }

        private void DestroyItem(GameObject item)
        {
#if UNITY_EDITOR
            Debug.Log("Editor working");
            
#else
            Destroy(item.gameObject);
#endif
        }
    }
}

