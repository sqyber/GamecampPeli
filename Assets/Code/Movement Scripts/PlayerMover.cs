using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;

    private Vector2 movementInput;
    
    private void Update()
    {
        Move();
    }

    private void OnMove(InputAction.CallbackContext callbackContext)
    {
        movementInput = callbackContext.ReadValue<Vector2>();
    }

    // Simple transform movement for the player which uses the players input
    private void Move()
    {
        Vector2 movement = movementInput * (Time.deltaTime * movementSpeed);

        transform.Translate(movement);
    }
}