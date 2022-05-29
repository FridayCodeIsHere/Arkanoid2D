using UnityEngine;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Canvas))]
    public class LoadingScreen : MonoBehaviour
    {
        public static LoadingScreen Screen = null;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            if (Screen == null)
            {
                Screen = this;
                DontDestroyOnLoad(this.gameObject);
                _canvas.enabled = true;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void Enable(bool value)
        {
            if (value)
            {
                _canvas.enabled = value;
            }
            else
            {
                Invoke(nameof(Disable), 0.5f);
            }
            
        }

        private void Disable()
        {
            _canvas.enabled = false;
        }
    }
}

