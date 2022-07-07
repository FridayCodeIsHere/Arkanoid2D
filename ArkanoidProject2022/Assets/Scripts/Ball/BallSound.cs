using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj {
    [RequireComponent(typeof(AudioSource))]
    public class BallSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _awake;
        [SerializeField] private AudioClip _collision;

        private AudioSource _audioSource;


        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySoundAwake()
        {
            if (AudioController.Audio.GetMusicValue())
            {
                _audioSource.PlayOneShot(_awake);
            }
        }

        public void PlaySoundCollision()
        {
            if (AudioController.Audio.GetSoundValue())
            {
                _audioSource.PlayOneShot(_collision);
            }
        }
    }
}