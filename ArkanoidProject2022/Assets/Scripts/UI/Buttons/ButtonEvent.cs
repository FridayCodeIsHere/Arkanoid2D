using UnityEngine;
using UnityEngine.Events;

namespace ArkanoidProj
{
    [RequireComponent(typeof(AudioSource))]
    public class ButtonEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnButtonAction;
        [SerializeField] private AudioClip _clickSound;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void ButtonAction()
        {
            OnButtonAction?.Invoke();
        }

        public void SoundClick()
        {
            if (SettingsController.Instance.GetSoundValue())
            {
                _audioSource.PlayOneShot(_clickSound);
            }
        }

        
    }
}
