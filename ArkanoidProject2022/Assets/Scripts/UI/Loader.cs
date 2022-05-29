using UnityEngine.SceneManagement;
using UnityEngine;

namespace ArkanoidProj
{
    public class Loader
    {
        private const string Main = "Main";
        private const string Game = "Game";

        public void LoadingMainScene(bool value)
        {
            SceneManager.LoadScene(value ? Main : Game);
        }

    }
}

