using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackRange = 3f;
    public float timeBetweenAttacks = 2f; // Time between each attack

    private float timeSinceLastAttack;

    

    
    private void Update()
    {
        // Update the time since the last attack
        timeSinceLastAttack += Time.deltaTime;

        // Check if the player is in attack range and enough time has passed since the last attack
        if (CanAttack() && timeSinceLastAttack >= timeBetweenAttacks)
        {
            // Perform the attack
            

            // Reset the timer
            timeSinceLastAttack = 0f;
        }
    }

    private bool CanAttack()
    {
        // Check if the player is within the attack range
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, attackRange, LayerMask.GetMask("Player"));
        return playerCollider != null;
    }

    

    // Visualize the attack range in the scene view (optional)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    

}
