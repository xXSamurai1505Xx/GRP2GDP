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

    // New parameters for Animator
    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;

    private Animator animator;

    private void Awake()
    {
        input = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        // Update Animator parameters
        horizontalMovement = moveVector.x;
        verticalMovement = moveVector.y;
        animator.SetFloat("Horizontal", horizontalMovement);
        animator.SetFloat("Vertical", verticalMovement);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;

        // Reset Animator parameters when movement is cancelled (back to idle)
        horizontalMovement = 0f;
        verticalMovement = 0f;
        animator.SetFloat("Horizontal", horizontalMovement);
        animator.SetFloat("Vertical", verticalMovement);
    }
}
