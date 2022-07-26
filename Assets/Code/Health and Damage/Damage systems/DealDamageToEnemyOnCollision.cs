using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace GamecampPeli
{
    public class DealDamageToEnemyOnCollision : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float timeBetweenDamageInSeconds = 1.0f;

        // Bool used to track when the enemy collides with the player
        private bool collisionWithEnemy;

        // Trigger function to detect when collision between enemy and player starts
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            collisionWithEnemy = true;
            StartCoroutine(DamagePerSecond(other));
        }
        
        // Trigger function to detect when collision between enemy and player starts
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            collisionWithEnemy = false;
            StopCoroutine(nameof(DamagePerSecond));
        }

        // Enumerator to deal damage once per second
        private IEnumerator DamagePerSecond([NotNull] Collider2D enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            while (collisionWithEnemy)
            {
                Debug.Log("Orbiter hit an enemy!");
                enemy.GetComponent<IDamageable>().DealDamage(damage);
                FindObjectOfType<AudioManager>().PlaySfx("EnemyHit");

                yield return new WaitForSeconds(timeBetweenDamageInSeconds);
            }
        }
    }
}
