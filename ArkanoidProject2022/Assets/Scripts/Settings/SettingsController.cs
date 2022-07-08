using UnityEngine;

namespace ArkanoidProj
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundSource;
        public static SettingsController Instance { get; private set; } = null;
        private SettingsState _settingsState;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                _settingsState = new SettingsState();
                if (_settingsState.GetAudioValues(TypeOfAudio.Music))
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
            _settingsState.EnableMusic(!_settingsState.GetAudioValues(TypeOfAudio.Music));

            if (_settingsState.GetAudioValues(TypeOfAudio.Music))
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
            _settingsState.EnableSound(!_settingsState.GetAudioValues(TypeOfAudio.Sound));
        }

        public bool GetMusicValue()
        {
            return _settingsState.GetAudioValues(TypeOfAudio.Music);
        }

        public bool GetSoundValue()
        {
            return _settingsState.GetAudioValues(TypeOfAudio.Sound);
        }

        public int GetLanguageIndex()
        {
            return _settingsState.GetLanguageIndex();
        }
        public void SetLanguageIndex(int value)
        {
            _settingsState.ChangeLanguageIndex(value);
        }
    }
}
