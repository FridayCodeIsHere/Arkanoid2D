using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj {

    [CreateAssetMenu(fileName = "BlockData", menuName = "GameData/BlockData")]
    public class BlockData : ScriptableObject
    {
        public GameObject _block;
        public List<Sprite> _sprites;
        public Color _dropColor;
        public int _score;

        //public Block Block => _block;
        //public List<Sprite> Sprites => _sprites;
        //public Color DropColor => _dropColor;
        //public int Score => _score;

    }
}
