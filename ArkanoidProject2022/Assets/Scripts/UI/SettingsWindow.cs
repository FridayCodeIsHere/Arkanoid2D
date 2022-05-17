using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private AudioButton _sound;
        [SerializeField] private AudioButton _music;

        private void OnEnable()
        {
            _music.SetState(true);
            _sound.SetState(true);
        }
    }
}
