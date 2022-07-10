using System;
using UnityEngine;

namespace ArkanoidProj
{
    public class UserProgress : MonoBehaviour
    {
        public static UserProgress Instance { get; private set; } = null;
        private UserProgressData _userProgress = new UserProgressData();

        private const string KEY = "UserProgress";


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void AddScore(int value)
        {
            if (value < 0)
            {
                throw new Exception("Value cannot be less then 0");
            }
            _userProgress.Score += value;
            SaveData();
        }

        public void AddCrystal(int value)
        {
            if (value < 0)
            {
                throw new Exception("Value cannot be less then 0");
            }
            _userProgress.Crystal += value;
            SaveData();
        }

        public int GetScore()
        {
            LoadData();
            return _userProgress.Score;
        }

        public int GetCrystal()
        {
            LoadData();
            return _userProgress.Crystal;
        }

        private void SaveData()
        {
            string save = JsonUtility.ToJson(_userProgress);
            PlayerPrefs.SetString(KEY, save);
            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            if (PlayerPrefs.HasKey(KEY))
            {
                _userProgress = JsonUtility.FromJson<UserProgressData>(PlayerPrefs.GetString(KEY));
            }
            else
            {
                InitUserData();
            }
        }

        private void InitUserData()
        {
            _userProgress.Score = 0;
            _userProgress.Crystal = 0;
        }
    }

    [Serializable]
    public class UserProgressData
    {
        public int Score;
        public int Crystal;
    }
}