using UnityEngine;

namespace ArkanoidProj
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private UnityEventInt UiUpdate;
        private int _score;
        public int Score => _score;

        public void SetDefault()
        {
            _score = 0;
            UiUpdate.Invoke(_score);
        }

        private void OnEnable()
        {
            Block.OnDestroyed += ScoreCollect;
        }

        private void OnDisable()
        {
            Block.OnDestroyed -= ScoreCollect;
        }

        private void ScoreCollect(int value)
        {
            if(_gameState.State == State.Gameplay)
            {
                _score += value;
                UiUpdate.Invoke(_score);
            }
        }
    }
}
