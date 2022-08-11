using UnityEngine;
using UnityEngine.Events;

namespace ArkanoidProj
{
    public class LevelGenerator : MonoBehaviour
    {
        private readonly LevelIndex _levelIndex = new LevelIndex();
        private readonly BlockGenerate _blockGenerate = new BlockGenerate();

        [SerializeField] private Transform _parentBlocks;
        [SerializeField] private ClearLevel _clearLevel;
        [SerializeField] private GameState _gameState;
        [SerializeField] private UnityEvent OnGenerated;

        private void Start()
        {
            _gameState.SetState(State.StopGame);
            Init();
        }

        private void Init()
        {
            _clearLevel.ClearLevelItems();

            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            LevelManager levelManager = new LevelManager();
            
            GameLevel gameLevel = levelManager.GetLevelData(typeLevel).GetSelectedLevelProgress().Level;
            Debug.Log($"GameLevel: {gameLevel.name}");

            if (gameLevel != null)
            {
                _blockGenerate.Generate(gameLevel, _parentBlocks);
            }
            
            LoadingScreen.Screen.Enable(false);
            OnGenerated?.Invoke();
            _gameState.SetState(State.Gameplay);
        }

        /*
          private void Init()
        {
            _clearLevel.ClearLevelItems();

            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            string path = $"Levels/{LevelNavigator.Instance.GetPathToLevels()}/Level-{_levelIndex.GetIndex(typeLevel)}";

            GameLevel gameLevel = Resources.Load<GameLevel>(path);

            if (gameLevel != null)
            {
                _blockGenerate.Generate(gameLevel, _parentBlocks);
            }
            
            LoadingScreen.Screen.Enable(false);
            OnGenerated?.Invoke();
            _gameState.SetState(State.Gameplay);
        }
         
          
         */

        public void Generate()
        {
            LoadingScreen.Screen.Enable(true);
            Init();
        }

        public void GenerateNext()
        {
            
            Debug.Log("GenerateNext");
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            LevelManager levelManager = new LevelManager();
            GameLevelData levelData = levelManager.GetLevelData(typeLevel);
            int indexLevel = levelData.GetIndexSelectLevel();
            if (indexLevel < levelData.CountLevels - 1)
            {
                indexLevel++;
                levelData.SelectLevel(indexLevel);

                levelManager.SaveData();
                Generate();
            }
            else
            {
                Loader loader = new Loader();
                _gameState.SetState(State.Other);
                loader.LoadingMainScene(true);
            }
            


        }

        //public void GenerateNext()
        //{
        //    Debug.Log("GenerateNext");
        //    TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
        //    LevelsData levelsData = new LevelsData();
        //    int tempIndex = _levelIndex.GetIndex(typeLevel);
        //    //levelsData.GetLevelProgress().Levels.Count - 1

        //    if (tempIndex < levelsData.GetLevelProgress().CountItemsInTypeLevel() - 1)
        //    {
        //        _levelIndex.SetIndex(typeLevel, tempIndex + 1);
        //        Generate();
        //    }
        //    else
        //    {
        //        Loader loader = new Loader();
        //        _gameState.SetState(State.Other);
        //        loader.LoadingMainScene(true);
        //    }
        //}
    }
}

