using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Data")]
    public class EditorData : ScriptableObject
    {
        public List<EditorBlockData> BlockData = new List<EditorBlockData>();
    }

    [System.Serializable]
    public class EditorBlockData
    {
        public Texture2D Texture2D;
        public BlockData BlockData;
    }
}

