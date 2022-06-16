using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class ShootAtNearest : MonoBehaviour
    {
        [SerializeField] private float rangeOfFiring = 7;
        [SerializeField] private float fireRate = 3f;
        [SerializeField] private GameObject projectile;
        
        private GameObject target;
        private bool canShoot = true;

        public GameObject Target
        {
            get { return target; }
        }
 
        private void Update()
        {
            CheckIfCanShoot();
        }
 
        // Function to spawn a projectile that is shot at the enemy
        private void Fire()
        {
            GameObject tmpProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        }

        // Enumerator used for the fire rate of shooting
        private IEnumerator AllowToShoot()
        {
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }

        // Function to check if the player can shoot at an enemy
        // Requires the range of firing and the damage amount
        // Checks if the player has an enemy in range and then fires if possible
        private void CheckIfCanShoot()
        {
            // Array for the enemies
            GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");

            if (!canShoot) return;
            canShoot = false;
            
            // Coroutine to allow a delay (fire rate) between shots
            StartCoroutine("AllowToShoot");
            
            target = allTargets[0];
            
            // Target the closest object (enemy)
            foreach (GameObject tmpTarget in allTargets)
            {
                if (Vector2.Distance(transform.position, tmpTarget.transform.position) < Vector2.Distance(transform.position, target.transform.position))
                {
                    target = tmpTarget;
                }
            }

            // If target doesn't exist, stop the function
            if (target == null) return;
            
            // Fire at the target, if it's within firing range
            if (Vector2.Distance(transform.position, target.transform.position) < rangeOfFiring)
            {
                Fire();
            }
        }
    }
}
