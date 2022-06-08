using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GamecampPeli
{
    public class TestDamageAura : MonoBehaviour
    {
        [SerializeField] private float damage = 1;

        [SerializeField] private float radius = 1;


        private void Start()
        {

        }

        private void Update()
        {
            AreaDamage(transform.position, radius);
        }

        private void AreaDamage(Vector2 objectPosition, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(objectPosition, radius);
            foreach (var hitCollider in hitColliders)
            {
                hitCollider.GetComponent<IDamageable>().DealDamage(damage);
            }
        }
    }
}
