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

        public void SoundClick()
        {
            AudioManager.Instance.PlaySound("ButtonClick");
        }
    }
}
