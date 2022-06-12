using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GamecampPeli
{
    public class SmallEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 10;

        // The DealDamage function of the IDamageable interface with
        // required components and functions for damaging the enemy
        // and removing the enemy from existence when it reaches
        // 0 health
        public void DealDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}