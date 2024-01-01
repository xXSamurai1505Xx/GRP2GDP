//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class EnemyAttack : MonoBehaviour
//{
//    public float damageAmount = 10f;
//    public float attackRange = 3f;
//    public float timeBetweenAttacks = 2f;
//    public float attackCooldown = 1f;

//    private float timeSinceLastAttack;
//    private PlayerHealth playerHealth;
//    private Animator animator;

//    // Reference to the EnemyMovement script
//    private EnemyMovement enemyMovement;

//    // Add this line to declare attackRangeCollider
//    public CircleCollider2D attackRangeCollider;

//    void Start()
//    {
//        GameObject player = GameObject.FindGameObjectWithTag("Player");
//        if (player != null)
//        {
//            playerHealth = player.GetComponent<PlayerHealth>();
//        }
//        else
//        {
//            Debug.LogError("Player not found!");
//        }

//        // Get the Animator component
//        animator = GetComponent<Animator>();

//        // Get the reference to the EnemyMovement script
//        enemyMovement = GetComponent<EnemyMovement>();
//    }

//    void Update()
//    {
//        timeSinceLastAttack += Time.deltaTime;
//    }

//    public void PerformAttack()
//    {
//        if (timeSinceLastAttack >= timeBetweenAttacks)
//        {
//            Debug.Log("Performing attack!");
//            RangeAttack();
//            timeSinceLastAttack = 0f;
//        }
//    }

//    private void RangeAttack()
//    {
//        if (playerHealth != null && attackRangeCollider != null)
//        {
//            // Check if the attackRangeCollider is not null
//            Collider2D collider = Physics2D.OverlapCircle(transform.position, attackRangeCollider.radius, LayerMask.GetMask("Player"));

//            if (collider != null)
//            {
//                Debug.Log("Range Attack!");
//                playerHealth.TakeDamage(damageAmount);
//                if (animator != null)
//                {
//                    animator.SetTrigger("IsAttack");
//                }

//                // Set the attacking state in EnemyMovement
//                enemyMovement.SetAttackingState(true);

//                // Start the coroutine to reset the attacking state after a cooldown
//                StartCoroutine(ResetAttackingState());
//            }
//        }
//    }

//    private IEnumerator ResetAttackingState()
//    {
//        yield return new WaitForSeconds(attackCooldown);
//        // Reset the attacking state in EnemyMovement
//        enemyMovement.SetAttackingState(false);
//    }
//}
