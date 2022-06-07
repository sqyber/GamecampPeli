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
        Vector2 movement = movementInput * (Time.deltaTime * movementSpeed);

        transform.Translate(movement);
    }

    private void OnMove(InputAction.CallbackContext callbackContext)
    {
        movementInput = callbackContext.ReadValue<Vector2>();
    }
}