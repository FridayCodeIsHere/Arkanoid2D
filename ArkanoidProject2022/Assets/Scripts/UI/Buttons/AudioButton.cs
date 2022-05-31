using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Image))]
    public class AudioButton : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _minAlpha = 0.6f;
        private Image _image;
        private bool _enable = true;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetState(bool value)
        {
            _enable = value;
            _image.color = GetAlphaColor();
        }

        public void Change()
        {
            _enable = !_enable;
            _image.color = GetAlphaColor();
        }

        private Color GetAlphaColor()
        {
            float alpha = _enable ? 1f : _minAlpha;
            return new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
        }
    }
}
