using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class HealthSystem : MonoBehaviour
    {
        private float health;

        public HealthSystem(float health)
        {
            this.health = health;
        }

        public float GetHealth()
        {
            return health;
        }

        public void DealDamage(float damageAmount)
        {
            health -= damageAmount;
        }
    }
}
