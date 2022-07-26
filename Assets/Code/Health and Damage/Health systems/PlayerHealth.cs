using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;
using UnityEngine.EventSystems;

namespace GamecampPeli
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        // Maximum health and current health
        [SerializeField] private int maxHealth = 100;
        private int currentHealth;

        // Health bar script
        [SerializeField] private HealthBarManager healthBar;
        
        // Death menu objects
        [SerializeField] private GameObject deathMenu;
        [SerializeField] private GameObject deathMenuButton;

        private AudioManager audioManager;

        public int CurrentHealth
        {
            get { return currentHealth; }
        }

        // Initializing currentHealth and the maxHealth to the health bar
        private void Awake()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            audioManager = FindObjectOfType<AudioManager>();
        }

        // IDamageable interfaces damage function with required components for
        // damaging the player
        
        // If the players health is 0 or below, open the death menu
        public void DealDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            
            if (currentHealth <= 0)
            {
                audioManager.PlaySfx("PlayerDeath");
                OpenDeathMenu();
            }
        }
        
        private void OpenDeathMenu()
        {
            // Set the death menu active and set the timescale to 0
            deathMenu.SetActive(true);
            Time.timeScale = 0f;

            // Remove the currently selected object from the EventSystem
            EventSystem.current.SetSelectedGameObject(null);
            
            // Set a new selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(deathMenuButton);
        }
    }
}
