using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputActions input;
    private Vector2 moveVector = Vector2.zero;
    public Vector2 lastMoveDirection = Vector2.up;
    private Rigidbody2D rb = null;
    public float speed = 4f;
    private Animator animator;
    private bool isDead = false; // Flag to check if the player is dead

    private void Awake()
    {
        input = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
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
        if (!isDead)
        {
            rb.velocity = moveVector * speed;

            // Update Animator parameters
            animator.SetFloat("Horizontal", moveVector.x);
            animator.SetFloat("Vertical", moveVector.y);
        }
        else
        {
            // If the player is dead, freeze the controls
            rb.velocity = Vector2.zero;
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>().normalized;
        lastMoveDirection = moveVector;
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;

        // Reset Animator parameters when movement is cancelled (back to idle)
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 0f);
    }

    // Add a method to set the isDead flag from the PlayerHealth script
    public void SetPlayerDead(bool dead)
    {
        isDead = dead;
    }
}
