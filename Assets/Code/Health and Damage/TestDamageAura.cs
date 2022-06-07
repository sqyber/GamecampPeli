using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class TestDamageAura : MonoBehaviour
    {
        [SerializeField] private float damage = 1;

        [SerializeField] private GameObject damageArea;
        
        private void Update()
        {
            void OnCollisionEnter2D(Collision2D col)
            {
                if (col.gameObject.GetComponent<IDamageable>() != null)
                {
                    gameObject.GetComponent<IDamageable>().Damage(damage);
                }
            }
        }
    }
}
