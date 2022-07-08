using UnityEngine;

namespace ArkanoidProj
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private TriggerAction _soundTrigger;
        [SerializeField] private TriggerAction _musicTrigger;

        private void OnEnable()
        {
            _musicTrigger.SetState(SettingsController.Instance.GetMusicValue());
            _soundTrigger.SetState(SettingsController.Instance.GetSoundValue());
        }

        public void ChangeSound()
        {
            SettingsController.Instance.ChangeSound();
        }

        public void ChangeMusic()
        {
            SettingsController.Instance.ChangeMusic();
        }
    }
}
