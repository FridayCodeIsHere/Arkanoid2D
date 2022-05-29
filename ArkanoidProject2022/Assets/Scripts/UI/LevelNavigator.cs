using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj {
    public class LevelNavigator : MonoBehaviour
    {
        public TypeOfLevel LevelType;
        public static LevelNavigator Instance;

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

        public string GetPathToLevels()
        {
            string path = "";
            switch (LevelType)
            {
                case TypeOfLevel.Blue:
                    path = "BlueLevels";
                    break;
                case TypeOfLevel.LightBlue:
                    path = "Light-BlueLevels";
                    break;
                case TypeOfLevel.Red:
                    path = "RedLevels";
                    break;
                case TypeOfLevel.LightRed:
                    path = "Light-RedLevels";
                    break;
                default:
                    Debug.LogWarning("Can't find path");
                    break;
            }
            return path;
        }

        public void SetTypeOfLevel(int indexType)
        {
            if (indexType == 1)
            {
                LevelType = TypeOfLevel.LightBlue;
            }
            if (indexType == 2)
            {
                LevelType = TypeOfLevel.Blue;
            }
            if (indexType == 3)
            {
                LevelType = TypeOfLevel.LightRed;
            }
            if (indexType == 4)
            {
                LevelType = TypeOfLevel.Red;
            }
            Debug.Log($"Level set up: {LevelType}");
        }
    }
}
