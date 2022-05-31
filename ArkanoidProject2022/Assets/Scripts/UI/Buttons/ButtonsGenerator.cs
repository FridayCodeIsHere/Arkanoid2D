using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class ButtonsGenerator : MonoBehaviour
    {
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private GameObject _content;

        private void Start()
        {
            //Generate();
        }

        public void Generate()
        {
            LevelsData levelsData = new LevelsData();
            LevelsProgress levelsProgress = levelsData.GetLevelProgress();

            for (int i = 0; i < levelsProgress.CountItemsInTypeLevel(); i++)
            {
                Button button = Instantiate(_buttonPrefab, _content.transform);

                if (button.gameObject.TryGetComponent(out LevelButton levelButton))
                {
                    levelButton.SetData(levelsProgress.GetIndexProgressOfTypeLevel(i), i);
                }
            }
            LoadingScreen.Screen.Enable(false);
        }
    }
}
