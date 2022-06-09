using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        private Text _text;
        private string _key;

        private void Start()
        {
            Localize();
            LocalizationManager.OnLanguageChange += OnLanguageChange;
        }

        private void OnDestroy()
        {
            LocalizationManager.OnLanguageChange -= OnLanguageChange;
        }

        private void OnLanguageChange()
        {
            Localize();
        }

        private void Init()
        {
            _text = GetComponent<Text>();
            _key = _text.text;
            Debug.Log(_key);
        }

        public void Localize(string newKey = null)
        {
            if (_text == null)
            {
                Init();
            }
            if (newKey != null)
            {
                _key = newKey;
            }
            _text.text = LocalizationManager.GetTranslate(_key);
            Debug.Log(LocalizationManager.Instance.GetFont());
            _text.font = LocalizationManager.Instance.GetFont();
            
        }

    }
}
