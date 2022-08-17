using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public enum TypeOfLevel
    {
        None,
        LightBlue,
        Blue,
        LightRed,
        Red
    }
    public class LevelIndex
    {
        private const string LightBlueLevel = "LightBlueLevel";
        private const string BlueLevel = "BlueLevel";
        private const string RedLevel = "RedLevel";
        private const string LightRedLevel = "LightRedLevel";

        public void SetIndex(TypeOfLevel level, int index)
        {
            string key = GetKeyOfTypeLevel(level);
            PlayerPrefs.SetInt(key, index);
        }

        public int GetIndex(TypeOfLevel levelType)
        {
            int index = 0;
            string key = GetKeyOfTypeLevel(levelType);

            if (PlayerPrefs.HasKey(key))
            {
                index = PlayerPrefs.GetInt(key);
            }

            return index;
        }

        private string GetKeyOfTypeLevel(TypeOfLevel typeLevel)
        {
            string key = null;
            switch (typeLevel)
            {
                case TypeOfLevel.Blue:
                    key = BlueLevel;
                    break;
                case TypeOfLevel.LightBlue:
                    key = LightBlueLevel;
                    break;
                case TypeOfLevel.Red:
                    key = RedLevel;
                    break;
                case TypeOfLevel.LightRed:
                    key = LightRedLevel;
                    break;
                default:
                    //Debug.LogWarning($"TypeOfLevel is null");
                    break;
            }
            return key;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(BlueLevel);
            PlayerPrefs.DeleteKey(LightBlueLevel);
            PlayerPrefs.DeleteKey(RedLevel);
            PlayerPrefs.DeleteKey(LightRedLevel);
        }
    }
}

