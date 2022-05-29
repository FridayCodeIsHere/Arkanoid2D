using UnityEngine;

namespace ArkanoidProj
{
    public class PanelLevels : MonoBehaviour
    {
        public void SetTypeLevel(int indexType)
        {

            if (indexType == 1)
            {
                LevelNavigator.Instance.LevelType = TypeOfLevel.LightBlue;
            }
            if (indexType == 2)
            {
                LevelNavigator.Instance.LevelType = TypeOfLevel.Blue;
            }
            if (indexType == 3)
            {
                LevelNavigator.Instance.LevelType = TypeOfLevel.LightRed;
            }
            if (indexType == 4)
            {
                LevelNavigator.Instance.LevelType = TypeOfLevel.Red;
            }
        }
    }
}
