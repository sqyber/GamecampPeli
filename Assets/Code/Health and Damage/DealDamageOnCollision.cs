using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class DealDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private float damage = 1f;
        [SerializeField] private int howOftenToDealDamage = 1;
        [SerializeField] private GameObject player;

        // Bool used to track when the enemy collides with the player
        private bool collisionWithPlayer;
        
        // Trigger function to detect when collision between enemy and player starts
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("PlayerCharacter")) return;
            collisionWithPlayer = true;
            StartCoroutine(nameof(DamagePerSecond));
        }
        
        // Trigger function to detect when collision between enemy and player starts
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("PlayerCharacter")) return;
            collisionWithPlayer = false;
            StopCoroutine(nameof(DamagePerSecond));
        }

        // Enumerator to deal damage once per second
        private IEnumerator DamagePerSecond()
        {
            while (collisionWithPlayer)
            {
                player.GetComponent<IDamageable>().DealDamage(damage);
                Debug.Log("An enemy hit you!");
                yield return new WaitForSeconds(howOftenToDealDamage);
            }
        }
    }
}