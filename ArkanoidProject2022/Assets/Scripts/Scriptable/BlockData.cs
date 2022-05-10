using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj {

    [CreateAssetMenu(fileName = "BlockData", menuName = "GameData/BlockData")]
    public class BlockData : ScriptableObject
    {
        [SerializeField] private GameObject _block;
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private Color _dropColor;
        [SerializeField] private int _score;

        public GameObject Block => _block;
        public List<Sprite> Sprites => _sprites;
        public Color DropColor => _dropColor;
        public int Score => _score;

    }
}
