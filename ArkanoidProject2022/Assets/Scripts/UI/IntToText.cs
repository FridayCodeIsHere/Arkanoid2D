using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class IntToText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void SetInt(int value)
        {
            _text.text = value.ToString();
        }
    }
}
