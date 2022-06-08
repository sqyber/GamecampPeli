using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health = 100f;

        public void DealDamage(float damage)
        {
            health -= damage;
        }
    }
}
