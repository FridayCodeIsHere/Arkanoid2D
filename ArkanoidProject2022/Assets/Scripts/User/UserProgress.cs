using UnityEngine;

namespace ArkanoidProj
{
    public class UserProgress : MonoBehaviour
    {
        public static UserProgress Instance { get; private set; } = null;
        private int Score;

        private const string KEY = "Score";


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
                throw new System.Exception("Value cannot be less then 0");
            }
            Score += value;
            SaveScore();
        }

        public int GetScore()
        {
            LoadScore();
            return Score;
        }

        private void SaveScore()
        {
            PlayerPrefs.SetInt(KEY, Score);
        }

        private void LoadScore()
        {
            if (PlayerPrefs.HasKey(KEY))
            {
                Score = PlayerPrefs.GetInt(KEY);
            }
        }
    }

}