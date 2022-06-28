using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;

namespace GamecampPeli
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 100;
        private int currentHealth;

        [SerializeField] private HealthBarManager healthBar;

        // Initializing currentHealth and the maxHealth to the health bar
        private void Awake()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        // IDamageable interfaces damage function with required components for
        // damaging the player
        public void DealDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
