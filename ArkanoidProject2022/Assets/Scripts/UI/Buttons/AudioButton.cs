using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class AudioButton : MonoBehaviour
    {
        [SerializeField] private string _name;
        private bool _enable = true;

        public void SetState(bool value)
        {
            _enable = value;
        }

        public void Change()
        {
            _enable = !_enable;
            Debug.Log($"{_name}: {_enable}");

        }
    }
}
