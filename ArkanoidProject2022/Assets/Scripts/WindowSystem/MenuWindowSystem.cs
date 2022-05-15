using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class MenuWindowSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsMenu;
        
        public void ExitGame()
        {
            Application.Quit();
        }

        public void RatingWindow()
        {

        }

        public void SettingsMenu()
        {
            _settingsMenu.SetActive(true);
        }
    }
}
