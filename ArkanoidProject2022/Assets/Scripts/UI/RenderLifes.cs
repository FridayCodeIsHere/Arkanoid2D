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

        private static int _LifesUpgradeID = ShopManagerScript._LifesUpgradeID;
        private int MAX_LIFE = PlatformLife.DEFAULT_LIVES + ShopManagerScript.Instance.getQuantity(_LifesUpgradeID);

        public void UpdateLife(int value)
        {
            for (int i = 0; i < _lifes.Count; i++)
            {
                if (i >= value)
                {
                    if (i >= MAX_LIFE)
                    {
                        _lifes[i].enabled = false; //not bought lives
                    }
                    else {
                        _lifes[i].sprite = _lostLife; //bought lives but lost in game
                    }
                    
                }
                else
                {
                    _lifes[i].sprite = _activeLife;
                }
            }
        }
    }
}
