using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class ProjectileMovement : MonoBehaviour
    {
        // Projectiles speed and damage
        [SerializeField] private float projectileSpeed = 1f;
        [SerializeField] private int damage = 1;

        // Used to store the target game object
        private GameObject target;
        
        private void Awake()
        {
            Initialize();
        }
        
        private void Update()
        {
            MoveProjectile();
            DestroyProjectile();
        }

        // Function for movement of the projectile
        private void MoveProjectile()
        {
            if (target == null) return;
            
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.transform.position,
                projectileSpeed * Time.fixedDeltaTime);
        }

        // Function to destroy the projectile and deal damage to target
        private void DestroyProjectile()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            
            if (Vector2.Distance(transform.position, target.transform.position) < 0.4)
            {
                Destroy(gameObject);
                target.GetComponent<IDamageable>().DealDamage(damage);
                Debug.Log("Projectile did " + damage + " to the nearest enemy!");
            }
        }

        private void Initialize()
        {
            target = GameObject.FindGameObjectWithTag("Shooter").GetComponent<ShootAtNearest>().Target;
            damage = damage + PlayerPrefs.GetInt("W1Bonus", 0);
        }
    }
}
