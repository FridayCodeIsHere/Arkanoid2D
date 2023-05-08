using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj {
    [RequireComponent(typeof(Button), typeof(Image))]
    public class LevelTypeButton : MonoBehaviour
    {
        [SerializeField] private TypeOfLevel _typeLevel;
        [SerializeField] private List<LevelTypeButton> _buttons;
        private Button _button;
        private Image _image;
        public bool IsCompleted;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            LoadData();
        }

        private void Start()
        {
            SetData();
        }

        private void SetData()
        {
            LoadData();
            foreach (LevelTypeButton button in _buttons)
            {
                if (button.IsCompleted == false)
                {
                    _image.color = new Color(1, 1, 1, 0.5f);
                    _button.interactable = false;
                    break;
                }
            }
        }

        private void LoadData()
        {
            LevelManager levelManager = new LevelManager();

            IsCompleted = levelManager.GetLevelData(_typeLevel).IsCompletedTypeLevel();
        }
    }

}
