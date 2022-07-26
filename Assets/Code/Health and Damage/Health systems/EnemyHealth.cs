using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

        private Animator animator;
        private AudioManager audioManager;

        private bool deathCycleStarted = false;

        public bool DeathCycleStarted
        {
            get { return deathCycleStarted; }
        }
        
        public int ProgressAmount
        {
            get { return progressAmount; }
        }

        private void Start()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            progressManager = FindObjectOfType<ProgressManager>();
            currencyManager = FindObjectOfType<CurrencyManager>();
            currencyMax = currencyMax + 1;
            audioManager = FindObjectOfType<AudioManager>();
            animator = gameObject.GetComponent<Animator>();
        }
        
        // The DealDamage function of the IDamageable interface with
        // required components and functions for damaging the enemy
        // and removing the enemy from existence when it reaches
        // 0 health
        public void DealDamage(int damage)
        {
            if (deathCycleStarted) return;
            
            if (health > 0)
            {
                audioManager.PlaySfx("EnemyHit");
                health -= damage;
            }
            
            if (health <= 0)
            {
                deathCycleStarted = true;
                animator.Play("Death", -1, 0f);
            }
        }

        public void Kill()
        {
            Destroy(gameObject);
            progressManager.ProgressValue += progressAmount;
            currencyManager.CurrencyValue += Random.Range(currencyMin, currencyMax);
        }
    }
}