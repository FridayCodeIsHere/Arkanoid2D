using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class LevelGenerator : MonoBehaviour
    {
        private readonly LevelIndex _levelIndex = new LevelIndex();
        private readonly BlockGenerate _blockGenerate = new BlockGenerate();
        [SerializeField] private Transform _parentBlocks;
        [SerializeField] private ClearLevel _clearLevel;
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _clearLevel.Clear();
            GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level-{_levelIndex.GetIndex()}");
            if (gameLevel != null)
            {
                _blockGenerate.Generate(gameLevel, _parentBlocks);
            }
            
            LoadingScreen.Screen.Enable(false);
        }

        public void Generate()
        {
            LoadingScreen.Screen.Enable(true);
            Init();
        }
    }
}

