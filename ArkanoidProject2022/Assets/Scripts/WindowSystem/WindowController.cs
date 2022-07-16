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
            Crystal.OnEnded += EndGame;
        }

        private void OnDisable()
        {
            Block.OnEnded -= EndGame;
            Crystal.OnEnded -= EndGame;
        }

        public void Play()
        {
            Animator anim = _pauseGameWindow.GetComponent<Animator>();
            anim.SetTrigger("HidePause");
            _gameState.SetState(State.Gameplay);
        }

        public void Replay()
        {
            DisableWindows();
            AudioManager.Instance.StopMusic();
            //SettingsController.Instance.PlayRandomGameSound();
        }

        public void NextLevel()
        {
            _victoryWindow.SetActive(false);
            //SettingsController.Instance.PlayRandomGameSound();
            //add logic
        }

        public void ToHome()
        {
            DisableWindows();
            LoadingScreen.Screen.Enable(true);
            Loader loader = new Loader();
            _gameState.SetState(State.Other);
            loader.LoadingMainScene(true);
            SettingsController.Instance.PlayMenuSound();
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
            }
        }
    }
}

