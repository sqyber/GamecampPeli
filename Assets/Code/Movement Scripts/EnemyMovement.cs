using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class EnemyMovement : MonoBehaviour
    {
        // Float to define the movement speed of the object
        [SerializeField] private float movementSpeed = 1f;
        
        // GameObject used to store the target GameObject
        private GameObject target;

        // Vector2s used to store the information of the targets location and 
        // the GameObjects own location
        private Vector2 targetLocation;
        private Vector2 currentOwnLocation;
        
        // Vector2 to store the GameObjects current localScale;
        private Vector2 currentScale;

        // Bool used to track if the object is moving left or right
        private bool goingLeft;

        // Bool used to track if the object is facing left or right
        private bool facingLeft;
        
        // Sets the target of the enemy to be an object with the tag "PlayerCharacter"
        private void Start()
        {
            Initialize();
        }
        
        private void Update()
        {
            MoveEnemyTowardsPlayer();
        }

        private void Initialize()
        {
            target = GameObject.FindGameObjectWithTag("PlayerCharacter");
            targetLocation = target.transform.position;
            currentOwnLocation = transform.position;
            currentScale = gameObject.transform.localScale;

            CheckMovementDirection();
            CheckScaleX();
            FlipSprite();
        }

        // Simple transform.position function to move the enemy towards the target (player)
        private void MoveEnemyTowardsPlayer()
        {
            currentOwnLocation = transform.position;
            targetLocation = target.transform.position;
            
            CheckMovementDirection();
            CheckScaleX();
            FlipSprite();

            transform.position = Vector2.MoveTowards
                (currentOwnLocation,
                    targetLocation,
                    movementSpeed * Time.deltaTime);
        }

        // Function to check the objects movement direction
        private void CheckMovementDirection()
        {
            if (targetLocation.x < currentOwnLocation.x)
            {
                goingLeft = true;
            }

            if (targetLocation.x > currentOwnLocation.x)
            {
                goingLeft = false;
            }
        }

        // Function to check if the objects localScale coordinate X is positive
        // or negative
        private void CheckScaleX()
        {
            if (currentScale.x < 0)
            {
                facingLeft = true;
                return;
            }
            facingLeft = false;
        }
        
        // Function to flip the objects sprite based on the movement direction
        private void FlipSprite()
        {
            if (goingLeft && !facingLeft)
            {
                currentScale.x *= -1;
                gameObject.transform.localScale = currentScale;
            } else if (!goingLeft && facingLeft)
            {
                currentScale.x *= -1;
                gameObject.transform.localScale = currentScale;
            }
        }
    }
}
