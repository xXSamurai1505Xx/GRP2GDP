using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputActions input; // Adjust the type here
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    private float speed = 10f;

    private void Awake()
    {
        input = new InputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * speed;
        // Test if OnMovementPerformed works
        //Debug.Log(moveVector);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
