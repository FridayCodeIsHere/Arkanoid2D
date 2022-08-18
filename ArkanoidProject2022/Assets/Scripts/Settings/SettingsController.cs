using UnityEngine;

namespace ArkanoidProj
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private string _menuMusicName;
        [SerializeField] private string[] _gameMusicNames;

        private SettingsState _settingsState;

        public static SettingsController Instance { get; private set; } = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                _settingsState = new SettingsState();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void Start()
        {
            PlayMenuSound();
        }

        public void ChangeMusic()
        {
            _settingsState.EnableMusic(!_settingsState.GetAudioValues(TypeOfAudio.Music));

            if (_settingsState.GetAudioValues(TypeOfAudio.Music))
            {
                AudioManager.Instance.PlayMusic(_menuMusicName);
            }
            else
            {
                AudioManager.Instance.StopMusic();
            }
        }

        public void PlayMenuSound()
        {
            AudioManager.Instance.PlayMusic(_menuMusicName);
        }

        public void StopMenuMusic()
        {
            AudioManager.Instance.StopMusic();
        }

        public void PlayRandomGameSound()
        {
            int randomMusic = Random.Range(0, _gameMusicNames.Length);
            AudioManager.Instance.PlayMusic(_gameMusicNames[randomMusic]);
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
