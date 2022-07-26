using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace GamecampPeli
{
    public class DealDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float timeBetweenDamageInSeconds = 1.0f;

        // Used to get the player game object and its animator
        // to play a playerHit animation when player is damaged
        private GameObject player;
        private Animator playerAnim;

        // Bool used to track when the enemy collides with the player
        private bool collisionWithPlayer;

        private void Start()
        {
            player = GameObject.FindWithTag("PlayerCharacter");
            playerAnim = player.GetComponent<Animator>();
        }
        
        // Trigger function to detect when collision between enemy and player starts
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("PlayerCharacter")) return;
            collisionWithPlayer = true;
            StartCoroutine(DamagePerSecond(other));
        }
        
        // Trigger function to detect when collision between enemy and player starts
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("PlayerCharacter")) return;
            collisionWithPlayer = false;
            StopCoroutine(nameof(DamagePerSecond));
        }

        // Enumerator to deal damage once per second
        private IEnumerator DamagePerSecond([NotNull] Collider2D player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            while (collisionWithPlayer)
            {
                player.GetComponent<IDamageable>().DealDamage(damage);
                FindObjectOfType<AudioManager>().PlaySfx("PlayerHit");
                playerAnim.Play("playerHit", -1, 0f);
                
                yield return new WaitForSeconds(timeBetweenDamageInSeconds);
            }
        }
    }
}