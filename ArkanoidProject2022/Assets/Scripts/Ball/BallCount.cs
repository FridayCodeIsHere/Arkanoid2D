using System;
using UnityEngine;
using UnityEngine.Events;

namespace ArkanoidProj
{
    public class BallCount : MonoBehaviour
    {
        private static int _count = 0;
        public static event Action OnEnded;

        private void OnEnable()
        {
            _count++;
        }

        private void OnDisable()
        {
            _count--;
            if (_count < 1)
            {
                OnEnded?.Invoke();
            }
        }
    }
}
