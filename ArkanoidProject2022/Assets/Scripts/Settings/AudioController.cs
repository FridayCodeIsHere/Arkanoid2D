using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundSource;
        public static AudioController Audio { get; private set; } = null;
        private AudioState _audioState;

        private void Awake()
        {
            if (Audio == null)
            {
                Audio = this;
                DontDestroyOnLoad(this.gameObject);
                _audioState = new AudioState();
                if (_audioState.GetAudioValues(TypeOfAudio.Music))
                {
                    _backgroundSource.Play();
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void ChangeMusic()
        {
            _audioState.EnableMusic(!_audioState.GetAudioValues(TypeOfAudio.Music));

            if (_audioState.GetAudioValues(TypeOfAudio.Music))
            {
                _backgroundSource.Play();
            }
            else
            {
                _backgroundSource.Stop();
            }
        }

        public void ChangeSound()
        {
            _audioState.EnableSound(!_audioState.GetAudioValues(TypeOfAudio.Sound));
        }

        public bool GetMusicValue()
        {
            return _audioState.GetAudioValues(TypeOfAudio.Music);
        }

        public bool GetSoundValue()
        {
            return _audioState.GetAudioValues(TypeOfAudio.Sound);
        }
    }
}
