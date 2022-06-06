using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class MenuWindowSystem : MonoBehaviour
    {
        [SerializeField] private Animator _settingsMenu;
        [SerializeField] private GameObject _panelLevels;
        [SerializeField] private GameObject _levels;
        [SerializeField] private Animator _storyWindow;
        [SerializeField] private Animator _developersWindow;
        [SerializeField] private GameObject _exitWindow;
        [SerializeField] private LevelsContent _content;


        private void Start()
        {
            LoadingScreen.Screen.Enable(false);
        }
        public void Back()
        {
            if (_panelLevels.activeInHierarchy)
            {
                ExitWindow();
            }
            else
            {
                _content.ClearContent();
                _panelLevels.SetActive(true);
                _levels.SetActive(false);
            }
            
        }

        public void RatingWindow()
        {

        }

        public void HideSettingsMenu()
        {
            _settingsMenu.SetTrigger("Close");
        }

        public void ExitWindow()
        {
            _exitWindow.SetActive(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void BackMenu()
        {
            if (_exitWindow.TryGetComponent(out Animator animator))
            {
                animator.SetTrigger("Close");
            }
        }

        public void HideStoryWindow()
        {
            _storyWindow.SetTrigger("Close");
        }

        public void HideDevelopersInfo()
        {
            _developersWindow.SetTrigger("Close");
        }
    }
}
