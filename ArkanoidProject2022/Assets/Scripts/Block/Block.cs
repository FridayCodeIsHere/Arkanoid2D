using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace ArkanoidProj
{

    [RequireComponent(typeof(SpriteRenderer), typeof(ParticleSystem))]
    public class Block : BaseBlock, IDamageable
    {
        private static int _count = 0;
        private bool _hasCrystal = false;
        private BlockData _blockData;
        
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private int _score;
        [SerializeField] private int _life;
        [SerializeField] private BoxCollider2D _blockCollider;
        [SerializeField] private BoxCollider2D _composite;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Crystal _crystal;
        
        public static event Action OnEnded;
        public static event Action<int> OnDestroyed;

//#if UNITY_EDITOR
//        public BlockData BlockData;
//#endif

        private void OnEnable()
        {
            _count++;
        }

        private void OnDisable()
        {
            _count--;
            OnDestroyed?.Invoke(_score);
            if (_count < 1)
            {
                OnEnded?.Invoke();
            }
        }

        public void SetData(BlockData blockData)
        {
            _blockData = blockData;
            _sprites = new List<Sprite>(blockData.Sprites);
            _score = blockData.Score;

            _spriteRenderer = GetComponent<SpriteRenderer>();
            _life = _sprites.Count;
            _spriteRenderer.sprite = _sprites[_life - 1];

            MainModule main = GetComponent<ParticleSystem>().main;
            main.startColor = blockData.DropColor;
            if (blockData.Crystal != null)
            {
                _hasCrystal = true;
            }
        }

        public void ApplyDamage()
        {
            _life--;
            if (_life < 1)
            {
                OnDestroyed?.Invoke(_score);
                _particleSystem.Play();
                _spriteRenderer.enabled = false;
                _blockCollider.enabled = false;
                _composite.enabled = false;
                if (_hasCrystal)
                {
                    Crystal crystal = Instantiate(_crystal, transform.position, Quaternion.identity, transform.root);
                    crystal.SetData(_blockData.Crystal, _blockData.ColorGradient);
                    crystal.DropDown();
                }
                Invoke(nameof(Dead), 0.5f);
            }
            else
            {
                _spriteRenderer.sprite = _sprites[_life - 1];
            }
        }

        public void Dead()
        {
            Destroy(this.gameObject);
        }
    }
}

