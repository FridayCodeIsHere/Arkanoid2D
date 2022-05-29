using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class SaveArea : MonoBehaviour
    {
        public static Vector2 OriginalAnchor; 

        private void Awake()
        {
            UpdateSaveArea();
        }

        private void UpdateSaveArea()
        {
            Rect safeArea = Screen.safeArea;
            RectTransform rectTransform = GetComponent<RectTransform>();

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            OriginalAnchor = anchorMax;
            //Debug.Log($"Up position = {anchorMax.y / 2 * GetPixelInUnits()}");

            //_topCollider.transform.position = Vector2.up * anchorMax / 2 * GetPixelInUnits();

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;

            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;

        }

        
    }
}
