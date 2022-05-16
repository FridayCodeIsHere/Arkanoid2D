using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public EndGameData EndGameData
        {
            get
            {
                Calculate();
                return _endGameData;
            }
        }

        private void Calculate()
        {
            _progress = _levelsData.GetLevelProgress().Levels[_levelIndex.GetIndex()];
            _endGameData = new EndGameData()
            {
                LevelIndex = _levelIndex.GetIndex(),
                Life = _platformLife.Life,
                Score = _levelProgress.ScoreCount,
                Crystal = _levelProgress.CrystalCount

            };

            if (_platformLife.Life > 0)
            {
                _levelsData.SaveLevelData(_levelIndex.GetIndex(), _progress);
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
