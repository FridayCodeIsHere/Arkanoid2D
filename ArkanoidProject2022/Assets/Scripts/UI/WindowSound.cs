using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(AudioSource))]
    public class WindowSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _windowOpenSound;
        [SerializeField] private AudioClip _windowCloseSound;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            AudioManager.Instance.PlaySound(_windowOpenSound.name);
        }

        public void PlayCloseSound()
        {
            AudioManager.Instance.PlaySound(_windowCloseSound.name);
        }
    }
}

