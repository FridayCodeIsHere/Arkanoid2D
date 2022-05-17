using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Image))]
    public class SoundAndMusic : MonoBehaviour
    {
        private Image _image;
        private bool _music;
        private bool _sound;

        public bool Music => _music;
        public bool Sound => _sound;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void SetMusic()
        {
            _music = !_music;
            _image.color = GetAlphaColor(_music);
            
        }

        public void SetSound()
        {
            _sound = !_sound;
            _image.color = GetAlphaColor(_sound);
        }

        private Color GetAlphaColor(bool isOn)
        {
            float alpha = isOn ? 1f : 0.5f;
            return new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
        }
    }
}

