using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;

    private Rigidbody2D playerRb;
    private Vector2 movementInput;
    private Animator animator;

    private bool isMoving;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementSpeed = movementSpeed + PlayerPrefs.GetInt("SpeedBonus", 0);
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    // Function to store the players input
    private void OnMove(InputAction.CallbackContext callbackContext)
    {
        movementInput = callbackContext.ReadValue<Vector2>();
    }

    // Simple transform movement for the player which uses the players input
    private void Move()
    {
        playerRb.velocity = movementInput * movementSpeed * Time.fixedDeltaTime;
        animator.SetFloat("MovementX", Mathf.Abs(movementInput.x));
        animator.SetFloat("MovementY", Mathf.Abs(movementInput.y));
    }
}