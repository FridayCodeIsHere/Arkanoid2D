using UnityEngine;
using UnityEngine.UI;

public enum TypeScore
{
    Score,
    Crystal
}

namespace ArkanoidProj
{
    [RequireComponent(typeof(Text))]
    public class UserProgressText : MonoBehaviour
    {
        [SerializeField] private TypeScore _typeScore;
        private Text _textScore;

        private void Start()
        {
            _textScore = GetComponent<Text>();
            RenderData();
        }

        private void RenderData()
        {
            switch(_typeScore)
            {
                case TypeScore.Score:
                    _textScore.text = UserProgress.Instance.GetScore().ToString();
                    break;
                case TypeScore.Crystal:
                    _textScore.text = UserProgress.Instance.GetCrystal().ToString();
                    break;
            }
        }

    }
}
