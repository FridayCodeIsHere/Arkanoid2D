using UnityEngine;

namespace ArkanoidProj {
    public class TapText : MonoBehaviour
    {
        private void OnEnable()
        {
            FingerInput.OnClicked += Deactivate;
        }

        private void OnDisable()
        {
            FingerInput.OnClicked -= Deactivate;
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
