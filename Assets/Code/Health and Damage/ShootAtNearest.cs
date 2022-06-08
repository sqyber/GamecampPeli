using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class ShootAtNearest : MonoBehaviour
    {
        [SerializeField] private float shootingDistance = 7f;
        //[SerializeField] private float projectileSpeed = 5f;
        [SerializeField] private float fireRate = 3f;
        [SerializeField] private float damage = 1f;
        //[SerializeField] private GameObject projectile;
        private GameObject target;
        private bool canShoot = true;
 
        private void Update ()
        {
            CheckIfCanShoot();
        }
 
        private void Fire ()
        {
            target.GetComponent<IDamageable>().DealDamage(damage);
            
            //Vector2 direction = target.transform.position - transform.position;
            //link to spawned arrow, you dont need it, if the arrow has own moving script
            //GameObject tmpProjectile = Instantiate(projectile, transform.position, transform.rotation);
            //tmpProjectile.transform.right = direction;
            //tmpProjectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed;
        }
 
        private IEnumerator AllowToShoot ()
        {
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }

        private void CheckIfCanShoot()
        {
            GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");

            if (!canShoot) return;
            canShoot = false;
            //Coroutine for delay between shooting
            StartCoroutine("AllowToShoot");
            //array with enemies
            //you can put in start, iff all enemies are in the level at beginn (will be not spawn later)
            if (allTargets == null) return;
            target = allTargets[0];
            //look for the closest
            foreach (GameObject tmpTarget in allTargets)
            {
                if (Vector2.Distance(transform.position, tmpTarget.transform.position) < Vector2.Distance(transform.position, target.transform.position))
                {
                    target = tmpTarget;
                }
            }
            //shoot if the closest is in the fire range
            if (Vector2.Distance(transform.position, target.transform.position) < shootingDistance)
            {
                Fire();
            }
        }
    }
}
