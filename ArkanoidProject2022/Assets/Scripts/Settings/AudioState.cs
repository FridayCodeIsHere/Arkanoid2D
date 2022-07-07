using System;
using UnityEngine;

public enum TypeOfAudio
{
    Music,
    Sound
}

namespace ArkanoidProj
{
    public class AudioState
    {
        private AudioValues _audioValues = new AudioValues();
        private const string Key = "Audio";

        public bool GetAudioValues(TypeOfAudio typeAudio)
        {
            if (PlayerPrefs.HasKey(Key))
            {
                _audioValues = JsonUtility.FromJson<AudioValues>(PlayerPrefs.GetString(Key));
            }
            else
            {
                InitAudio();
            }

            switch (typeAudio)
            {
                case TypeOfAudio.Music:
                    return _audioValues.Music;
                case TypeOfAudio.Sound:
                    return _audioValues.Sound;
            }
            throw new ArgumentException("Invid Data");
        }

        public void ClearAudioKey()
        {
            PlayerPrefs.DeleteKey(Key);
        }

        public void InitAudio()
        {
            _audioValues.Music = true;
            _audioValues.Sound = true;
        }

        public void SaveData()
        {
            string save = JsonUtility.ToJson(_audioValues);
            PlayerPrefs.SetString(Key, save);
            PlayerPrefs.Save();
        }

        public void EnableMusic(bool value)
        {
            _audioValues.Music = value;
            SaveData();
        }

        public void EnableSound(bool value)
        {
            _audioValues.Sound = value;
            SaveData();
        }
    }

    [Serializable] 
    public class AudioValues
    {
        public bool Music;
        public bool Sound;
    }
}

