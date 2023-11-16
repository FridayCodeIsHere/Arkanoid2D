using UnityEngine;
using UnityEngine.Events;

namespace ArkanoidProj
{
    public class PlatformLife : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private UnityEvent OnAllLifeLosted;
        [SerializeField] private UnityEvent OnLifeLosted;
        [SerializeField] private UnityEventInt UiUpdated;
        private static readonly int _LifesUpgradeID = ShopManagerScript._LifesUpgradeID;

        public static int DEFAULT_LIVES = 3;
        private readonly int MAX_LIFE = DEFAULT_LIVES + ShopManagerScript.Instance.getQuantity(_LifesUpgradeID);
        private int _life;

        public int Life => _life;

        public void SetDefault()
        {
            _life = MAX_LIFE;
            UiUpdated.Invoke(_life);
        }

        private void OnEnable()
        {
            BallCount.OnEnded += LostLife;
        }

        private void OnDisable()
        {
            BallCount.OnEnded -= LostLife;
        }

        private void LostLife()
        {
            if (_gameState.State == State.Gameplay)
            {
                _life--;
                if (_life < 1)
                {
                    OnAllLifeLosted?.Invoke();
                }
                else
                {
                    OnLifeLosted?.Invoke();
                }
            }
            UiUpdated.Invoke(_life);
        }
    }

    [System.Serializable]
    public class UnityEventInt : UnityEvent<int> {}
}
