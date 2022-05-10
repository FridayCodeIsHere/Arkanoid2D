using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace ArkanoidProj
{

    [RequireComponent(typeof(SpriteRenderer), typeof(ParticleSystem))]
    public class Block : MonoBehaviour
    {
        private static int _count = 0;
        
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private int _score;
        [SerializeField] private int _life;

#if UNITY_EDITOR
        public BlockData BlockData;
#endif

        private void OnEnable()
        {
            _count++;
        }

        private void OnDisable()
        {
            _count--;
            if (_count < 1)
            {
                Debug.Log("Blocks ended");
            }
        }

        public void SetData(BlockData blockData)
        {
            _sprites = new List<Sprite>(blockData._sprites);
            _score = blockData._score;

            _spriteRenderer = GetComponent<SpriteRenderer>();
            _life = _sprites.Count;
            _spriteRenderer.sprite = _sprites[_life - 1];

            MainModule main = GetComponent<ParticleSystem>().main;
            main.startColor = blockData._dropColor;
        }

        public void ApplyDamage()
        {
            _life--;
            if (_life < 1)
            {
                DestroyBlock();
            }
            else
            {
                _spriteRenderer.sprite = _sprites[_life - 1];
            }
        }

        public void DestroyBlock()
        {
            _spriteRenderer.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<ParticleSystem>().Play();
        }
    }
}

