using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 3f;
    public float detectionRadius = 10f;
    public float maxRaycastDistance = 5f;
    public Transform originalPosition;
    public float returnCooldown = 3f;

    private bool shouldMove = true;
    private bool isAttacking = false;
    private bool isReturning = false;
    private float returnCooldownTimer = 0f;

    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 originalPosition2D;
    private Vector2 playerPosition;

    private Animator animator;
    public PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        col.isTrigger = true;

        originalPosition2D = originalPosition.position;
        rb.isKinematic = true;
        rb.freezeRotation = true;

        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (shouldMove)
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);

            Debug.Log("Distance to Player: " + distanceToPlayer);

            if (distanceToPlayer <= detectionRadius)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, playerPosition - (Vector2)transform.position, maxRaycastDistance, LayerMask.GetMask("Obstacle"));

                if (hit.collider == null)
                {
                    if (distanceToPlayer <= attackRange)
                    {
                        if (!isAttacking)
                        {
                            SetAttackingState(true);
                        }
                    }
                    else
                    {
                        MoveTowards(playerPosition);
                        rb.isKinematic = true;
                        ResumeMovement();
                        SetAttackingState(false);
                    }
                }
                else
                {
                    StopMovement();
                }
            }
            else
            {
                if (!isReturning)
                {
                    isReturning = true;
                    returnCooldownTimer = returnCooldown;
                    rb.isKinematic = true;
                }

                if (returnCooldownTimer > 0f)
                {
                    returnCooldownTimer -= Time.deltaTime;
                }
                else
                {
                    ReturnToOriginalPosition();
                }
            }
        }

        UpdateRotation();
    }

    void MoveTowards(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    void ReturnToOriginalPosition()
    {
        rb.velocity = Vector2.zero;
        MoveTowards(originalPosition2D);

        float distanceToOriginalPosition = Vector2.Distance(transform.position, originalPosition2D);
        if (distanceToOriginalPosition < 0.1f)
        {
            isReturning = false;
            returnCooldownTimer = 0f;
            rb.isKinematic = true;
        }
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
        animator.SetFloat("Horizontal", 0f);
    }

    public void ResumeMovement()
    {
        shouldMove = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shouldMove = false;
            StopMovement();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shouldMove = true;
            ResumeMovement();
        }
    }

    private void UpdateRotation()
    {
         float horizontalMovement = rb.velocity.x;
         animator.SetFloat("Horizontal", horizontalMovement);

         // Assuming you have a parameter named "IsMoving" in your Animator
         bool isMoving = Mathf.Abs(horizontalMovement) > 0.1f; // Adjust the threshold as needed
         animator.SetBool("IsMoving", isMoving);

    }
    private void UpdateAttackRotation()
    {
        Vector2 directionToPlayer = (playerPosition - (Vector2)transform.position).normalized;

        // Calculate the horizontal and vertical components of the direction
        float horizontalDirection = directionToPlayer.x;
        float verticalDirection = directionToPlayer.y;

        // Determine the sign of the horizontal component to set the correct direction
        float horizontalSign = Mathf.Sign(horizontalDirection);

        // Set the "Horizontal" parameter in the Animator based on the horizontal sign
        animator.SetFloat("Horizontal", horizontalSign);
    }

    private void SetAttackingState(bool state)
    {
        isAttacking = state;

        if (state)
        {
            StopMovement();
            // Perform attack logic here
            Debug.Log("Performing attack!");

            if (playerHealth != null)
            {
                UpdateAttackRotation(); // Update rotation during attack state
                float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);

                if (distanceToPlayer <= attackRange)
                {
                    playerHealth.TakeDamage(10f); // Adjust the damage amount as needed


                    animator.SetTrigger("IsAttack");
                    

                    StartCoroutine(ResetAttackingState());
                }
            }

        }
    }

    private IEnumerator ResetAttackingState()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay as needed

        // Reset the attacking state
        SetAttackingState(false);
    }
}