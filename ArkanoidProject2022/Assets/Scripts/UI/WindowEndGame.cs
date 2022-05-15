using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj {
    public class WindowEndGame : MonoBehaviour
    {
        [SerializeField] private CalculationLevelProgress _calculationLevel;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _crystalText;

        private void OnEnable()
        {
            EndGameData endGameData = _calculationLevel.EndGameData;
            _scoreText.text = endGameData.Score.ToString();
            _crystalText.text = endGameData.Crystal.ToString();
        }

    }
}
