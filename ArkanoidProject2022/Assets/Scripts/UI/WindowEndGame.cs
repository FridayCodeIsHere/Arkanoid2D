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
            TypeOfLevel typeLevel = LevelNavigator.Instance.LevelType;
            EndGameData endGameData = _calculationLevel.GetEndData(typeLevel);
            UserProgress.Instance.AddScore(endGameData.Score);
            UserProgress.Instance.AddCrystal(endGameData.Crystal);
            _scoreText.text = endGameData.Score.ToString();
            _crystalText.text = endGameData.Crystal.ToString();
        }

    }
}
