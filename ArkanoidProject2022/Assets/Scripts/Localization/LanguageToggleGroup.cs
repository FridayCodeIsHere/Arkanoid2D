using UnityEngine;
using UnityEngine.UI;


namespace ArkanoidProj
{
    public class LanguageToggleGroup : MonoBehaviour
    {
        [SerializeField] private TriggerAction[] _triggers;

        private void Start()
        {
            SetTrigger();
        }

        public void SetTrigger()
        {
            int langIndex = LocalizationManager.SelectedLanguage;
            for (int i = 0; i < _triggers.Length; i++)
            {
                if (i == langIndex)
                {
                    _triggers[i].SetState(true);
                }
                else
                {
                    _triggers[i].SetState(false);
                }
            }
        }
    }
}
