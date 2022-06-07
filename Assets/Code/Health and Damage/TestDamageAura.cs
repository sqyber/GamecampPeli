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

        [SerializeField] private float damageArea;

        private void Start()
        {
            InvokeRepeating("AreaOfEffect", 1, 1);
        }

        private void Update()
        {

        }

        private void AreaOfEffect()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageArea);

            foreach (Collider col in hitColliders)
            {
                col.GetComponent<IDamageable>().DealDamage(damage);
            }
            
        }
    }
}
