using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [CreateAssetMenu(fileName = "Level", menuName = "GameData/GameLevel")]
    public class GameLevel : ScriptableObject
    {
        public List<BlockObject> Blocks = new List<BlockObject>();
    }

    [System.Serializable]
    public class BlockObject
    {
        public Vector3 Position;
        public BlockData BlockData;
    }
}

