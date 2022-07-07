using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GamecampPeli
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 1;
        [SerializeField] private int progressAmount = 1;
        [SerializeField] private int currencyMin = 1;
        [SerializeField] private int currencyMax = 5;

        private ProgressManager progressManager;
        private CurrencyManager currencyManager;

        private void Start()
        {
            progressManager = FindObjectOfType<ProgressManager>();
            currencyManager = FindObjectOfType<CurrencyManager>();
            currencyMax = currencyMax + 1;
        }
        
        public int ProgressAmount
        {
            get { return progressAmount; }
        }

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
                progressManager.ProgressValue += progressAmount;
                currencyManager.CurrencyValue += Random.Range(currencyMin, currencyMax);
            }
        }
    }
}