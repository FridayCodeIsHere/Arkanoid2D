using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ArkanoidProj
{
    public class ButtonEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnButtonAction;

        public void ButtonAction()
        {
            OnButtonAction?.Invoke();
        }
    }
}
