using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class MenuWindowSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private GameObject _panelLevels;
        [SerializeField] private GameObject _levels;
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

        public void SettingsMenu()
        {
            _settingsMenu.SetActive(true);
        }

        public void HideSettingsMenu()
        {
            Animator anim = _settingsMenu.GetComponent<Animator>();
            anim.SetTrigger("Confirm");
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
            Animator anim = _exitWindow.GetComponent<Animator>();
            anim.SetTrigger("Back");
        }
    }
}
