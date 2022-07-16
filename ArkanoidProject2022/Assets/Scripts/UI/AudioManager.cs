using System;
using System.Linq;
using UnityEngine;

namespace ArkanoidProj
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Sound[] _sounds;
        [SerializeField] private Sound[] _musics;
        private AudioSource _musicSource;
        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }
            DontDestroyOnLoad(this.gameObject);
        }

        public void PlaySound(string soundName, AudioSource source = null)
        {
            Sound sound = _sounds.FirstOrDefault(x => x.Name == soundName);
            if (!SettingsController.Instance.GetSoundValue() || sound == null) return;
            
            bool remove = false;
            if (source == null)
            {
                source = gameObject.AddComponent<AudioSource>();
                remove = true;
            }

            InitSource(source, sound);
            source.PlayOneShot(sound.GetAudio());

            if (!sound.IsLoop && remove)
            {
                Destroy(source, sound.GetAudio().length);
            }
        }

        public void StopMusic()
        {
            if (_musicSource)
            {
                _musicSource.Stop();
            }
        }

        private void InitSource(AudioSource source, Sound audio)
        {
            source.loop = audio.IsLoop;
            source.clip = audio.GetAudio();
            source.volume = audio.Volume;
            source.pitch = audio.Pitch;
        }

        public void PlayMusic(string musicName, AudioSource source = null)
        {
            Sound music = _musics.FirstOrDefault(x => x.Name == musicName);
            if (!SettingsController.Instance.GetMusicValue() || music == null) return;

            if (_musicSource) _musicSource.Stop();

            if (source == null)
            {
                _musicSource = gameObject.AddComponent<AudioSource>();
            }
            else
            {
                _musicSource = source;
            }

            InitSource(_musicSource, music);
            _musicSource.Play();
        }
    }

    [Serializable]
    public class Sound
    {
        [SerializeField] private string _name;
        [SerializeField] private bool _isLoop;
        [SerializeField, Range(0f, 1f)] private float _volume;
        [SerializeField] private float _pitch;
        [SerializeField, Range(0f, 1f)] private float _spaceSound;
        [SerializeField] private AudioClip _audioClip;

        public string Name => _name;
        public bool IsLoop => _isLoop;
        public float Volume => _volume;
        public float Pitch => _pitch;
        public float SpaceSound => _spaceSound;
        public AudioClip GetAudio() => _audioClip;
    }
}

