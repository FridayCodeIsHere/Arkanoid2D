using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class AudioButton : MonoBehaviour
    {
        private bool _enable = true;

        public void SetState(bool value)
        {
            _enable = value;
        }

        public void Change()
        {
            _enable = !_enable;

        }
    }
}
