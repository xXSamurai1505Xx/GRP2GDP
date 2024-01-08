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
    public GameObject projectilePrefab; // Reference to the projectile prefab

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

    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

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

            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerPosition - (Vector2)transform.position, maxRaycastDistance, LayerMask.GetMask("Obstacle"));
            if (hit.collider == null)
            {
                if (distanceToPlayer <= detectionRadius)
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
            else
            {
                StopMovement();
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

        bool isMoving = Mathf.Abs(horizontalMovement) > 0.1f;
        animator.SetBool("IsMoving", isMoving);
    }

    private void SetAttackingState(bool state)
    {
        isAttacking = state;

        if (state)
        {
            StopMovement();
            Debug.Log("Performing attack!");

            if (playerHealth != null)
            {
                UpdateAttackRotation();
                float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);

                if (distanceToPlayer <= attackRange)
                {
                    // Trigger the attack animation
                    animator.SetTrigger("IsAttack");

                    // Start the coroutine to handle shooting projectiles
                    StartCoroutine(ShootProjectile());
                }
            }
        }
    }

    private IEnumerator ShootProjectile()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay before shooting

        // Determine the correct spawn point based on the monster's direction
        Transform spawnPoint = (playerPosition.x > transform.position.x) ? rightSpawnPoint : leftSpawnPoint;

        // Instantiate a projectile from the selected spawn point
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        // Set the projectile's direction along the x-axis
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            Vector2 directionToPlayer = new Vector2((playerPosition.x > transform.position.x) ? 1f : -1f, 0f);
            projectileScript.SetDirection(directionToPlayer);
        }

        // Reset the attacking state
        SetAttackingState(false);
    }

    private void UpdateAttackRotation()
    {
        Vector2 directionToPlayer = (playerPosition - (Vector2)transform.position).normalized;
        float horizontalDirection = directionToPlayer.x;
        float verticalDirection = directionToPlayer.y;
        float horizontalSign = Mathf.Sign(horizontalDirection);
        animator.SetFloat("Horizontal", horizontalSign);
    }
}