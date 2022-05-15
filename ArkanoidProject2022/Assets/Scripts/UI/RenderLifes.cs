using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    public class RenderLifes : MonoBehaviour
    {
        [SerializeField] private List<Image> _lifes;
        [SerializeField] private Sprite _lostLife;
        [SerializeField] private Sprite _activeLife;

        public void UpdateLife(int value)
        {
            for (int i = 0; i < _lifes.Count; i++)
            {
                if (i >= value)
                {
                    _lifes[i].sprite = _lostLife;
                }
                else
                {
                    _lifes[i].sprite = _activeLife;
                }
            }
        }
    }
}
