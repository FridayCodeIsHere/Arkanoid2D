using UnityEngine;

namespace ArkanoidProj {
    public class LevelsData
    {
        private const string BlueKeyLevel = "BlueKey";
        private const string LightBlueKeyLevel = "LightBlueKey";
        private const string RedKeyLevel = "RedKey";
        private const string LightRedKeyLevel = "LightRedKey";

        private LevelsProgress _levelsProgress = new LevelsProgress();

        private void SaveData()
        {
            string key = GetKeyOfTypeLevel();
            string saveJson = JsonUtility.ToJson(_levelsProgress);
            PlayerPrefs.SetString(key, saveJson);
            PlayerPrefs.Save();
        }

        private string GetKeyOfTypeLevel(TypeOfLevel typeLevel = TypeOfLevel.None)
        {
            if (typeLevel == TypeOfLevel.None)
            {
                typeLevel = LevelNavigator.Instance.LevelType;
            }

            string key = "";
            switch (typeLevel)
            {
                case TypeOfLevel.Blue:
                    key = BlueKeyLevel;
                    break;
                case TypeOfLevel.LightBlue:
                    key = LightBlueKeyLevel;
                    break;
                case TypeOfLevel.Red:
                    key = RedKeyLevel;
                    break;
                case TypeOfLevel.LightRed:
                    key = LightRedKeyLevel;
                    break;
                case TypeOfLevel.None:
                    Debug.Log("None level");
                    break;
            }
            return key;
        }

        public void NewData()
        {
            TypeOfLevel folderName = LevelNavigator.Instance.LevelType;
            string path = $"Levels/{LevelNavigator.Instance.GetPathToLevels()}";
            int levelCount = Resources.LoadAll<GameLevel>(path).Length;

            for (int i = 0; i < levelCount; i++)
            {
                _levelsProgress.AddToCurrentTypeLevel(new Progress());
            }

            _levelsProgress.AddToCurrentTypeLevel(0, true);
            SaveData();
            Resources.UnloadUnusedAssets();
        }

        public LevelsProgress GetLevelProgress(TypeOfLevel type = TypeOfLevel.None)
        {
            if (PlayerPrefs.HasKey(GetKeyOfTypeLevel(type)))
            {
                string saveJson = PlayerPrefs.GetString(GetKeyOfTypeLevel(type));
                _levelsProgress = JsonUtility.FromJson<LevelsProgress>(saveJson);
            }
            else
            {
                NewData();
            }
            return _levelsProgress;
        }

        public void SaveLevelData(int index, Progress progress)
        {
            _levelsProgress = GetLevelProgress();
            _levelsProgress.AddToCurrentTypeLevel(index, progress);
            if (index < _levelsProgress.CountItemsInTypeLevel() - 1)
            {
                _levelsProgress.AddToCurrentTypeLevel(index + 1, true);
            }
            SaveData();
            
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(BlueKeyLevel);
            PlayerPrefs.DeleteKey(LightBlueKeyLevel);
            PlayerPrefs.DeleteKey(RedKeyLevel);
            PlayerPrefs.DeleteKey(LightRedKeyLevel);
        }
    }
}
