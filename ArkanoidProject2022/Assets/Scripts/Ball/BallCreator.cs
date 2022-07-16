using UnityEngine;

namespace ArkanoidProj
{
    public class BallCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;
        private const float OffsetY = 1.5f;


        public void Create()
        {
            Instantiate(_ballPrefab, new Vector3(transform.position.x, transform.position.y + OffsetY), Quaternion.identity, transform);
            
        }
    }
}
