using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackRange = 3f;
    public float attackCooldown = 2f; // Cooldown between attacks

    private bool canAttack = true;

    private void Update()
    {
        // Check if the player is in attack range and the enemy can attack
        if (CanAttack() && canAttack)
        {
            // Perform the attack
            Attack();

            // Set cooldown to prevent rapid attacks
            canAttack = false;
            Invoke("ResetAttackCooldown", attackCooldown);
        }
    }

    private bool CanAttack()
    {
        // Check if the player is within the attack range
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));
        return playerCollider != null;
    }

    private void Attack()
    {
        // Deal damage to the player
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }

    private void ResetAttackCooldown()
    {
        canAttack = true;
    }

    // Visualize the attack range in the scene view (optional)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
