using UnityEngine;

namespace ArkanoidProj
{
    public class LocalizationTest : MonoBehaviour
    {
        [SerializeField] private LocalizedText _text;

        public void LocalizeText()
        {
            _text.Localize("SettingsHeader_Key");
        }
    }

}
