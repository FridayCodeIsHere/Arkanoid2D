using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Image))]
    public class LevelBackground : MonoBehaviour
    {
        [SerializeField] private Sprite _blueBG;
        [SerializeField] private Sprite _lightBlueBG;
        [SerializeField] private Sprite _redBG;
        [SerializeField] private Sprite _lightRedBG;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();

            SetLevelBG(LevelNavigator.Instance.LevelType);

        }

        private void SetLevelBG(TypeOfLevel typeLevel)
        {
            switch(typeLevel)
            {
                case TypeOfLevel.Blue:
                    _image.sprite = _blueBG;
                    break;
                case TypeOfLevel.LightBlue:
                    _image.sprite = _lightBlueBG;
                    break;
                case TypeOfLevel.Red:
                    _image.sprite = _redBG;
                    break;
                case TypeOfLevel.LightRed:
                    _image.sprite = _lightRedBG;
                    break;
            }
        }
    }
}
