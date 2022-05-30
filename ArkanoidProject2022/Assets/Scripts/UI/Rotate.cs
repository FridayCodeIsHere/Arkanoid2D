using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private float _speed = 4f;
        private float _multiplierSpeed = 10f;

        #region MonoBehaviour
        private void OnValidate()
        {
            if (_speed < 0f) _speed = 0f;
        }
        #endregion

        private void Update()
        {
            transform.Rotate(Vector3.forward * Time.unscaledDeltaTime * _speed * _multiplierSpeed);
        }
    }
}
