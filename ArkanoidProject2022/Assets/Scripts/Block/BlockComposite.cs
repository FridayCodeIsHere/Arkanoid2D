using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidProj
{
    public class BlockComposite : MonoBehaviour
    {
        public void ApplyDamage(Vector2 position)
        {
            Collider2D[] colliders2D = Physics2D.OverlapCircleAll(position, 0.05f);
            if (colliders2D.Length > 0)
            {
                foreach (Collider2D item in colliders2D)
                {
                    if (item.TryGetComponent(out IDamageable damageable))
                    {
                        damageable.ApplyDamage();
                        break;
                    }
                }
            }
        }
    }
}
