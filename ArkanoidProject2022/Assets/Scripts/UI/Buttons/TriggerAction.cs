using UnityEngine;
using UnityEngine.UI;


namespace ArkanoidProj
{
    [RequireComponent(typeof(Image), typeof(Animator))]
    public class TriggerAction : MonoBehaviour
    {
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private Image _triggerImage;

        private Animator _animator;
        

        public bool IsEnable;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetState(bool value)
        {
            IsEnable = value;
            ChangeSprite();
        }

        public void TriggerEvent()
        {
            IsEnable = !IsEnable;
            _animator.SetTrigger("Action");
        }

        public void ChangeSprite()
        {
            _triggerImage.sprite = IsEnable ? _enableSprite : _disableSprite;
        }
    }
}
