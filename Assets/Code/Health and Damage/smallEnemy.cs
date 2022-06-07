using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class smallEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health = 1;
        
        public void Damage(float damage)
        {
            health -= damage;
            
            if (health >= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
