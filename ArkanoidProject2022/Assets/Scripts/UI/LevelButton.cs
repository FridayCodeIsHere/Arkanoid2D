using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Text _buttonText;
        [SerializeField] private Button _button;
        private int _index;

        public void SetData(Progress progress, int index)
        {
            _buttonText.text = (index + 1).ToString(); 
            _index = index;
            _button.interactable = progress.IsOpened;
            
        }

        public void LevelSelected()
        {
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            LoadingScreen.Screen.Enable(true);
            LevelIndex levelIndex = new LevelIndex();
            levelIndex.SetIndex(typeLevel, _index);

            Loader loader = new Loader();
            loader.LoadingMainScene(false);
        }
    }
}

