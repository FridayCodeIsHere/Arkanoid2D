using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj 
{
    public class TopCollider : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CanvasScaler _canvasScaler;

        private void Start()
        {
            transform.position = Vector2.up * SaveArea.OriginalAnchor / 2 * GetPixelInUnits();
        }

        public float GetPixelInUnits()
        {
            return _camera.orthographicSize * 2 / _canvasScaler.referenceResolution.y;
        }
    }
}
