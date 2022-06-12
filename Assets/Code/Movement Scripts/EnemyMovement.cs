using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1f;
        
        private GameObject target;
        
        // Sets the target of the enemy to be an object with the tag "PlayerCharacter"
        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("PlayerCharacter");
        }
        
        private void Update()
        {
            MoveEnemyTowardsPlayer();
        }

        // Simple transform.position function to move the enemy towards the target (player)
        private void MoveEnemyTowardsPlayer()
        {
            transform.position = Vector2.MoveTowards
                (transform.position,
                    target.transform.position,
                    movementSpeed * Time.deltaTime);
        }
    }
}
