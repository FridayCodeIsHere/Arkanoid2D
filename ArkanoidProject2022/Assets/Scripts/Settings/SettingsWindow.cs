using UnityEngine;

namespace ArkanoidProj
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private TriggerAction _soundTrigger;
        [SerializeField] private TriggerAction _musicTrigger;

        private void OnEnable()
        {
            _musicTrigger.SetState(AudioController.Audio.GetMusicValue());
            _soundTrigger.SetState(AudioController.Audio.GetSoundValue());
        }

        public void ChangeSound()
        {
            AudioController.Audio.ChangeSound();
        }

        public void ChangeMusic()
        {
            AudioController.Audio.ChangeMusic();
        }
    }
}
