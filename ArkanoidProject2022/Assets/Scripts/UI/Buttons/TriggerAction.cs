using UnityEngine;
using UnityEngine.UI;


namespace ArkanoidProj
{
    [RequireComponent(typeof(Image), typeof(Animator), typeof(AudioSource))]
    public class TriggerAction : MonoBehaviour
    {
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private Image _triggerImage;
        [SerializeField] private AudioClip _clickSound;

        private AudioSource _audioSource;
        private Animator _animator;
        

        public bool IsEnable { get; private set; }


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void SetState(bool value)
        {
            IsEnable = value;
            ChangeSprite();
        }

        public void TriggerEvent()
        {
            if (SettingsController.Instance.GetSoundValue())
            {
                _audioSource.PlayOneShot(_clickSound);
            }
            IsEnable = !IsEnable;
            _animator.SetTrigger("Action");
        }

        public void ChangeSprite()
        {
            _triggerImage.sprite = IsEnable ? _enableSprite : _disableSprite;
        }
    }
}
