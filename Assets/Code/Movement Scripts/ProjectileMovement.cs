using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float projectileSpeed = 1f;
        [SerializeField] private int damage = 1;
        private GameObject target;
        
        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Shooter").GetComponent<ShootAtNearest>().Target;
        }

        
        private void Update()
        {
            MoveProjectile();
            DestroyProjectile();
        }

        private void MoveProjectile()
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.transform.position,
                projectileSpeed * Time.fixedDeltaTime);
        }

        private void DestroyProjectile()
        {
            if (Vector2.Distance(transform.position, target.transform.position) < 0.4)
            {
                Destroy(gameObject);
                target.GetComponent<IDamageable>().DealDamage(damage);
            }
        }
    }
}
