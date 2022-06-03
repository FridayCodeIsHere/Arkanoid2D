using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Animator))]
    public class IntToText : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private Animator _animator;
        private static readonly int _isCollect = Animator.StringToHash("CollectValue");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetInt(int value)
        {
            _text.text = value.ToString();
        }

        public void CollectAnimation()
        {
            _animator.SetTrigger(_isCollect);
        }
    }
}
