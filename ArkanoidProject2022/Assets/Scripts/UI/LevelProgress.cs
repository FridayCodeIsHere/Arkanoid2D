using System;
using UnityEngine;

namespace ArkanoidProj
{
    public class LevelProgress : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private UnityEventInt _UpdateScore;
        [SerializeField] private UnityEventInt _UpdateCrystal;
        private int _score;
        private int _crystal;

        public int ScoreCount => _score;
        public int CrystalCount => _crystal;

        public void SetDefault()
        {
            _score = 0;
            _crystal = 0;

            _UpdateScore.Invoke(_score);
            _UpdateCrystal.Invoke(_crystal);
        }

        private void OnEnable()
        {
            Block.OnDestroyed += ScoreCollect;
            Crystal.OnCollision += CrystalCollect;
        }

        private void OnDisable()
        {
            Block.OnDestroyed -= ScoreCollect;
            Crystal.OnCollision -= CrystalCollect;
        }

        private void ScoreCollect(int value)
        {
            if (_gameState.State == State.Gameplay)
            {
                _score += value;
                _UpdateScore.Invoke(_score);
            }
        }

        private void CrystalCollect()
        {
            if (_gameState.State == State.Gameplay)
            {
                Debug.Log("Update Crystals");
                _crystal++;
                _UpdateCrystal.Invoke(_crystal);
            }
        }
    }
}
