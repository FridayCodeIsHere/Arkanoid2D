using System.Collections.Generic;

namespace ArkanoidProj
{
    [System.Serializable]
    public class LevelsProgress
    {
        public List<Progress> BlueLevels = new List<Progress>();
        public List<Progress> LightBlueLevels = new List<Progress>();
        public List<Progress> RedLevels = new List<Progress>();
        public List<Progress> LightRedLevels = new List<Progress>();

        public void AddToCurrentTypeLevel(Progress progress)
        {
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            switch(typeLevel)
            {
                case TypeOfLevel.Blue:
                    BlueLevels.Add(progress);
                    break;
                case TypeOfLevel.LightBlue:
                    LightBlueLevels.Add(progress);
                    break;
                case TypeOfLevel.Red:
                    RedLevels.Add(progress);
                    break;
                case TypeOfLevel.LightRed:
                    LightRedLevels.Add(progress);
                    break;
            }
        }

        public int CountItemsInTypeLevel()
        {
            int count = 0;

            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            switch (typeLevel)
            {
                case TypeOfLevel.Blue:
                    count = BlueLevels.Count;
                    break;
                case TypeOfLevel.LightBlue:
                    count = LightBlueLevels.Count;
                    break;
                case TypeOfLevel.Red:
                    count = RedLevels.Count;
                    break;
                case TypeOfLevel.LightRed:
                    count = LightRedLevels.Count;
                    break;
            }

            return count;
        }

        public void AddToCurrentTypeLevel(int index, Progress progress)
        {
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            switch (typeLevel)
            {
                case TypeOfLevel.Blue:
                    BlueLevels[index] = progress;
                    break;
                case TypeOfLevel.LightBlue:
                    LightBlueLevels[index] = progress;
                    break;
                case TypeOfLevel.Red:
                    RedLevels[index] = progress;
                    break;
                case TypeOfLevel.LightRed:
                    LightRedLevels[index] = progress;
                    break;
            }
        }

        public void AddToCurrentTypeLevel(int index, bool value)
        {
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            switch (typeLevel)
            {
                case TypeOfLevel.Blue:
                    BlueLevels[index].IsOpened = value;
                    break;
                case TypeOfLevel.LightBlue:
                    LightBlueLevels[index].IsOpened = value;
                    break;
                case TypeOfLevel.Red:
                    RedLevels[index].IsOpened = value;
                    break;
                case TypeOfLevel.LightRed:
                    LightRedLevels[index].IsOpened = value;
                    break;
            }
        }

        public Progress GetIndexProgressOfTypeLevel(int index)
        {
            Progress progress = null;
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            switch (typeLevel)
            {
                case TypeOfLevel.Blue:
                    progress = BlueLevels[index];
                    break;
                case TypeOfLevel.LightBlue:
                    progress = LightBlueLevels[index];
                    break;
                case TypeOfLevel.Red:
                    progress = RedLevels[index];
                    break;
                case TypeOfLevel.LightRed:
                    progress = LightRedLevels[index];
                    break;
            }
            return progress;
        }
    }

    [System.Serializable]
    public class Progress
    {
        public bool IsOpened;
    }
}

