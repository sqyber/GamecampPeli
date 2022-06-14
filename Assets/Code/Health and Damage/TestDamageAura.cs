using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GamecampPeli
{
    public class TestDamageAura : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float timeBetweenDamageInSeconds = 1.0f;

        // Bool to track if enemy is in range
        private bool inRangeOfAOE = false;

        // Collider2D used to store the game objects collider
        private Collider2D gOCollider;

        private void Start()
        {
            gOCollider = gameObject.GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("DamageAura")) return;
            inRangeOfAOE = true;
            StartCoroutine(AOEDamage(gOCollider));
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("DamageAura")) return;
            inRangeOfAOE = false;
            StopCoroutine(AOEDamage(gOCollider));
        }

        private IEnumerator AOEDamage(Collider2D enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            while (inRangeOfAOE)
            {
                enemy.GetComponent<IDamageable>().DealDamage(damage);
                Debug.Log("An enemy was hit with the AoE aura!");
                yield return new WaitForSeconds(timeBetweenDamageInSeconds);
            }
        }
    }
}
