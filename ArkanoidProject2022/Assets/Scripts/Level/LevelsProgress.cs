using System.Collections.Generic;

namespace ArkanoidProj
{
    [System.Serializable]
    public class LevelsProgress
    {
        public List<Progress> Levels = new List<Progress>();
    }

    [System.Serializable]
    public class Progress
    {
        public bool IsOpened;
    }
}

