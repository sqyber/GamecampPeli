using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class DamageRandomEnemy : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float rateOfFire = 2f;
        [SerializeField] private int amountOfTargets = 1;

        private GameObject[] allEnemies;
        private bool canShoot = true;
        private int amountOfEnemies;

        private void Update()
        {
            DamageARandomEnemy();
        }

        // IEnumerator to add a rate of fire to the damage
        private IEnumerator AllowNextDamage()
        {
            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }

        // Function to damage a random enemy or random enemies depending on the upgrade level
        // of the weapon
        private void DamageARandomEnemy()
        {
            FindAllEnemies();
            
            if (allEnemies.Length < 1) return;
            amountOfEnemies = allEnemies.Length;

            if (!canShoot) return;
            canShoot = false;

            StartCoroutine(nameof(AllowNextDamage));

            for (int i = 0; i < amountOfTargets; i++)
            {
                int randomEnemy = Random.Range(0, amountOfEnemies);
                GameObject tmpTarget = allEnemies[randomEnemy];
                tmpTarget.GetComponent<IDamageable>().DealDamage(damage);
            }
        }

        // Function to find all enemies to an array
        private void FindAllEnemies()
        {
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }
}
