using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class SmallEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health = 10;

        private void Start()
        {
            Debug.Log("Health: " + health);
        }

        public void DealDamage(float damage)
        {
            health -= damage;
            Debug.Log("Health: " + health);
        }
    }
}