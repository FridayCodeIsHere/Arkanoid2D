using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class WindowController : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private GameObject _victoryWindow;
        [SerializeField] private GameObject _loseWindow;
        [SerializeField] private GameObject _pauseGameWindow;


        private void OnEnable()
        {
            Block.OnEnded += EndGame;
        }

        private void OnDisable()
        {
            Block.OnEnded -= EndGame;
        }

        public void Play()
        {
            _gameState.SetState(State.Gameplay);
            _pauseGameWindow.SetActive(false);
        }

        public void Replay()
        {
            DisableWindows();
        }

        public void NextLevel()
        {
            _victoryWindow.SetActive(false);
            //add logic
        }

        public void ToHome()
        {
            DisableWindows();
            LoadingScreen.Screen.Enable(true);
            Loader loader = new Loader();
            _gameState.SetState(State.Other);
            loader.LoadingMainScene(true);
        }

        public void SettingsMenu()
        {

        }

        private void DisableWindows()
        {
            _victoryWindow.SetActive(false);
            _pauseGameWindow.SetActive(false);
            _loseWindow.SetActive(false);
        }

        private void EndGame()
        {
            if (_gameState.State == State.Gameplay)
            {
                _gameState.SetState(State.StopGame);
                _victoryWindow.SetActive(true);
                Debug.Log("EndGame");
            }
        }
    }
}

