using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class ButtonsGenerator : MonoBehaviour
    {
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private GameObject _content;
        

        public void Generate()
        {
            LevelManager levelsManager = new LevelManager();
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            int countLevels = levelsManager.GetLevelData(typeLevel).CountLevels;

            for (int i = 0; i < countLevels; i++)
            {
                Button button = Instantiate(_buttonPrefab, _content.transform);
                if (button.gameObject.TryGetComponent(out LevelButton levelButton))
                {
                    ProgressLevel levelProgress = levelsManager.GetLevelData(typeLevel).GetLevelProgress(i);
                    levelButton.SetData(levelProgress, i);
                }
            }
            levelsManager.SaveData();
        }
    }
}
