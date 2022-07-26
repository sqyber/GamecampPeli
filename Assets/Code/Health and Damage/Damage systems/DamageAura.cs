using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GamecampPeli
{
    public class DamageAura : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float timeBetweenDamageInSeconds = 1.0f;
        [SerializeField] private String damagingObjectTag;

        // Bool to track if enemy is in range of AoE
        private bool inRangeOfAOE = false;
        private bool inRange;

        // Collider2D used to store the game objects collider
        private Collider2D gOCollider;

        private void Start()
        {
            gOCollider = gameObject.GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(damagingObjectTag)) return;
            inRangeOfAOE = true;
            StartCoroutine(AOEDamage(gOCollider));
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(damagingObjectTag)) return;
            inRangeOfAOE = false;
            StopCoroutine(AOEDamage(gOCollider));
        }

        private IEnumerator AOEDamage(Collider2D enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            
            while (inRangeOfAOE)
            {
                CheckRangeBool();
                if (inRange)
                {
                    enemy.GetComponent<IDamageable>().DealDamage(damage);
                    yield return new WaitForSeconds(timeBetweenDamageInSeconds);
                }
                else
                {
                    yield break;
                }
            }
        }

        private void CheckRangeBool()
        {
            inRange = inRangeOfAOE;
        }
    }
}
