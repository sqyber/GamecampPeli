using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class DealDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private float damage = 1f;
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("PlayerCharacter")) return;
            other.GetComponent<IDamageable>().DealDamage(damage);
            Debug.Log("Enemy hit you!");
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("PlayerCharacter"))
            {
                other.gameObject.GetComponent<IDamageable>().DealDamage(damage);
                Debug.Log("The enemy hit you!");
            }
        }
    }
}
