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
                    _trigger.IsEnable = AudioController.Audio.GetMusicValue();
                    break;
                case TypeOfAudio.Sound:
                    _trigger.IsEnable = AudioController.Audio.GetSoundValue();
                    break;
            }
        }
    }
}
