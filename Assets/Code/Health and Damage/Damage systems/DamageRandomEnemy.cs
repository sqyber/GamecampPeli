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
        [SerializeField] private GameObject asparagusProjectile;
        [SerializeField] private int delayForDamage = 2;

        private GameObject[] allEnemies;
        private bool canShoot = true;
        private int amountOfEnemies;

        private GameObject target;

        public GameObject Target
        {
            get { return target; }
        }

        private void Awake()
        {
            damage = damage + PlayerPrefs.GetInt("W2Bonus", 0);
        }

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

        private IEnumerator SpawnProjectile(GameObject enemy)
        {
            Vector2 offset = new Vector2(0f, 2f);
            Vector2 enemyPosition = enemy.transform.position;
            
            Instantiate(asparagusProjectile, enemyPosition + offset, Quaternion.identity);
            yield return new WaitForSeconds(delayForDamage);
            enemy.GetComponent<IDamageable>().DealDamage(damage);
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
                target = tmpTarget;
                target.GetComponent<IDamageable>().DealDamage(damage);
                Debug.Log("Dealt " + damage + " to a random enemy!");
                //StartCoroutine(SpawnProjectile(tmpTarget));
            }
        }

        // Function to find all enemies to an array
        private void FindAllEnemies()
        {
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }
}
