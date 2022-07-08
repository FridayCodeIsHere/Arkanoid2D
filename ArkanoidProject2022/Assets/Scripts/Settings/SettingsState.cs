using System;
using UnityEngine;

public enum TypeOfAudio
{
    Music,
    Sound
}

namespace ArkanoidProj
{
    public class SettingsState
    {
        private SettingParameters _settingValues = new SettingParameters();
        private const string Key = "SettingsKey";

        public bool GetAudioValues(TypeOfAudio typeAudio)
        {
            LoadData();

            switch (typeAudio)
            {
                case TypeOfAudio.Music:
                    return _settingValues.Music;
                case TypeOfAudio.Sound:
                    return _settingValues.Sound;
            }
            throw new ArgumentException("Invid Data");
        }

        public void ClearSettingsData()
        {
            PlayerPrefs.DeleteKey(Key);
        }

        public void InitSettingsValues()
        {
            _settingValues.Music = true;
            _settingValues.Sound = true;
            _settingValues.LanguageIndex = 0;
        }

        public void LoadData()
        {
            if (PlayerPrefs.HasKey(Key))
            {
                _settingValues = JsonUtility.FromJson<SettingParameters>(PlayerPrefs.GetString(Key));
            }
            else
            {
                InitSettingsValues();
            }
        }

        public void SaveData()
        {
            string save = JsonUtility.ToJson(_settingValues);
            PlayerPrefs.SetString(Key, save);
            PlayerPrefs.Save();
        }

        public void EnableMusic(bool value)
        {
            _settingValues.Music = value;
            SaveData();
        }

        public void EnableSound(bool value)
        {
            _settingValues.Sound = value;
            SaveData();
        }

        public int GetLanguageIndex()
        {
            LoadData();
            return _settingValues.LanguageIndex;
        }

        public void ChangeLanguageIndex(int value)
        {
            _settingValues.LanguageIndex = value;
            SaveData();
        }

    }

    [Serializable] 
    public class SettingParameters
    {
        public bool Music;
        public bool Sound;
        public int LanguageIndex;
    }
}

