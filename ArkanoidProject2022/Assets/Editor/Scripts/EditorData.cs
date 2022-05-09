using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    [CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Data")]
    public class EditorData : ScriptableObject
    {
        [SerializeField] private List<EditorBlockData> _blockData = new List<EditorBlockData>();
        public List<EditorBlockData> BlockData => _blockData;
    }

    [System.Serializable]
    public class EditorBlockData
    {
        [SerializeField] private Texture2D _texture2D;
        [SerializeField] private BlockData _blockData;

        public Texture2D Texture2D => _texture2D;
        public BlockData BlockData => _blockData;
    }
}

