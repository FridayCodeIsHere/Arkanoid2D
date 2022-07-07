using UnityEngine;
using UnityEngine.UI;

namespace ArkanoidProj
{
    [RequireComponent(typeof(Text))]
    public class UserScoreText : MonoBehaviour
    {
        private Text _textScore;

        private void Start()
        {
            _textScore = GetComponent<Text>();
            RenderData();
        }

        private void RenderData()
        {
            _textScore.text = UserProgress.Instance.GetScore().ToString();
        }

    }
}
