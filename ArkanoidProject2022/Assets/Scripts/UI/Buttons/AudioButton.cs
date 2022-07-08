using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Image), typeof(TriggerAction))]
    public class AudioButton : MonoBehaviour
    {
        [SerializeField] private TypeOfAudio _typeAudio;

        private TriggerAction _trigger;

        private void Awake()
        {
            _trigger = GetComponent<TriggerAction>();
        }

        private void OnEnable()
        {
            switch (_typeAudio)
            {
                case TypeOfAudio.Music:
                    _trigger.SetState(SettingsController.Instance.GetMusicValue());
                    break;
                case TypeOfAudio.Sound:
                    _trigger.SetState(SettingsController.Instance.GetSoundValue());
                    break;
            }
        }
    }
}
