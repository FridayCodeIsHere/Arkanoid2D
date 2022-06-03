using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Image))]
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Text _buttonText;
        [SerializeField] private Button _button;
        private Image _image;
        private int _index;

        public void SetData(Progress progress, int index)
        {
            _image = GetComponent<Image>();
            _buttonText.text = (index + 1).ToString(); 
            _index = index;

            if (progress.IsOpened == false)
            {
                _button.interactable = false;
                _image.color = new Color(1, 1, 1, 0.5f);
                _buttonText.color = new Color(1, 1, 1, 0.4f);
            }
            
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

