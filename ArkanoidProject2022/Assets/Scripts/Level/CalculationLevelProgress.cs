using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace ArkanoidProj
{
    public class CalculationLevelProgress : MonoBehaviour
    {
        [SerializeField] private PlatformLife _platformLife;
        [SerializeField] private LevelProgress _levelProgress;
        private Progress _progress = new Progress();
        private readonly LevelsData _levelsData = new LevelsData();
        private readonly LevelIndex _levelIndex = new LevelIndex();
        private EndGameData _endGameData;

        public EndGameData GetEndData(TypeOfLevel typeLevel)
        {
            Calculate(typeLevel);
            return _endGameData;
        }

        private void Calculate(TypeOfLevel typeLevel)
        {
            _progress = _levelsData.GetLevelProgress().GetIndexProgressOfTypeLevel(_levelIndex.GetIndex(typeLevel));
            _endGameData = new EndGameData()
            {
                LevelIndex = _levelIndex.GetIndex(typeLevel),
                Life = _platformLife.Life,
                Score = _levelProgress.ScoreCount,
                Crystal = _levelProgress.CrystalCount

            };

            if (_platformLife.Life > 0)
            {
                _levelsData.SaveLevelData(_levelIndex.GetIndex(typeLevel), _progress);
                ShopManagerScript.Instance.addCoins(_endGameData.Score);
            }
        }

    }

    public struct EndGameData
    {
        public int LevelIndex;
        public int Life;
        public int Score;
        public int Crystal;
    }
}
