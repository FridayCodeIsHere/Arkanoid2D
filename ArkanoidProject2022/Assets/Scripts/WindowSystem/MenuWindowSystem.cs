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
        [SerializeField] private LevelsContent _content;


        private void Start()
        {
            LoadingScreen.Screen.Enable(false);
        }
        public void Back()
        {
            if (_panelLevels.activeInHierarchy)
            {
                Application.Quit();
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

        public void CloseSetting()
        {
            _settingsMenu.SetActive(false);
        }
    }
}
