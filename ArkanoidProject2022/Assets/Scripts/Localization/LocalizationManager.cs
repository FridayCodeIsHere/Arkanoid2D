using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace ArkanoidProj
{
    public class LocalizationManager : MonoBehaviour
    {
        public static int SelectedLanguage { get; private set; }
        private static Dictionary<string, List<string>> _localization;

        [SerializeField] private TextAsset _textFile;

        private void Awake()
        {
            if (_localization == null)
            {
                LoadLocalization();
            }
        }

        public void SetLanguage(int id)
        {
            SelectedLanguage = id;
        }

        private void LoadLocalization()
        {
            _localization = new Dictionary<string, List<string>>();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(_textFile.text);

            foreach (XmlNode key in xmlDocument["Keys"].ChildNodes)
            {
                string keyStr = key.Attributes["Name"].Value;

                List<string> values = new List<string>();
                foreach (XmlNode translate in key["Translates"].ChildNodes)
                {
                    values.Add(translate.InnerText);
                }
                _localization[keyStr] = values;
            }
        }

        public static string GetTranslate(string key, int languageId = -1)
        {
            if (languageId == -1)
            {
                languageId = SelectedLanguage;
            }

            if (_localization.ContainsKey(key))
            {
                return _localization[key][languageId];
            }
            return key;
        }
    }
}
