using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Image))]
    public class CrystalImage : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _images;
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            SetImage();
        }

        private void SetImage()
        {
            TypeOfLevel levelType = LevelNavigator.Instance.LevelType;

            switch (levelType)
            {
                case TypeOfLevel.Blue:
                    _image.sprite = _images[0];
                    break;
                case TypeOfLevel.LightBlue:
                    _image.sprite = _images[1];
                    break;
                case TypeOfLevel.Red:
                    _image.sprite = _images[2];
                    break;
                case TypeOfLevel.LightRed:
                    _image.sprite = _images[3];
                    break;
            }
        }
    }

}
