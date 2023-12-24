using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float damageAmount = 20f;
    public float attackRadius = 2f;
    public float attackConeAngle = 45f; // Angle in degrees
    public Button attackButton; // Reference to the UI button
    public Vector2 lastMoveDirection;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Add a listener to the button
        attackButton.onClick.AddListener(Attack);
    }

    private void Attack()
    {
        // Set the IsAttack parameter to true to trigger the attack animation
        animator.SetBool("IsAttack", true);
        DetermineAttackDirection();

        // Perform the attack action after a delay matching the animation duration
        float animationDuration = GetAnimationDuration("AttackAnimationName");
        Invoke("DealAreaDamage", animationDuration);
    }

    private void DealAreaDamage()
    {
        // Get all colliders within the attack radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        // Loop through all colliders
        foreach (Collider2D collider in colliders)
        {
            // Check if the collider belongs to an enemy
            if (collider.CompareTag("Enemy"))
            {
                // Check if the enemy is within the cone angle
                Vector2 directionToEnemy = (collider.transform.position - transform.position).normalized;

                // Calculate the angle between the player's facing direction and the direction to the enemy
                float angleToEnemy = Vector2.SignedAngle(lastMoveDirection, directionToEnemy);

                // Check if the enemy is within the attack cone angle
                if (Mathf.Abs(angleToEnemy) <= attackConeAngle * 0.5f)
                {
                    // Check if the collider has an EnemyHealthSystem component
                    EnemyHealthSystem healthSystem = collider.GetComponent<EnemyHealthSystem>();
                    if (healthSystem != null)
                    {
                        healthSystem.TakenHitPoints(damageAmount);
                        Debug.Log("Damage Taken");
                    }
                }
            }
        }

        // Set the IsAttack parameter back to false to end the attack animation
        animator.SetBool("IsAttack", false);
    }
    private void DetermineAttackDirection()
    {
        // Determine the attack direction based on the last movement direction
        if (lastMoveDirection == Vector2.up)
        {
            // Set the attack direction parameters in the animator
            animator.SetBool("AttackUp", true);
            animator.SetBool("AttackDown", false);
            animator.SetBool("AttackLeft", false);
            animator.SetBool("AttackRight", false);
        }
        else if (lastMoveDirection == Vector2.down)
        {
            // Set the attack direction parameters in the animator
            animator.SetBool("AttackUp", false);
            animator.SetBool("AttackDown", true);
            animator.SetBool("AttackLeft", false);
            animator.SetBool("AttackRight", false);
        }
        else if (lastMoveDirection == Vector2.left)
        {
            // Set the attack direction parameters in the animator
            animator.SetBool("AttackUp", false);
            animator.SetBool("AttackDown", false);
            animator.SetBool("AttackLeft", true);
            animator.SetBool("AttackRight", false);
        }
        else if (lastMoveDirection == Vector2.right)
        {
            // Set the attack direction parameters in the animator
            animator.SetBool("AttackUp", false);
            animator.SetBool("AttackDown", false);
            animator.SetBool("AttackLeft", false);
            animator.SetBool("AttackRight", true);
        }
    }
    private float GetAnimationDuration(string animationName)
    {
        // Get the duration of the specified animation
        if (animator != null)
        {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                if (clip.name == animationName)
                {
                    return clip.length;
                }
            }
        }

        // Return a default value if the animation is not found
        return 1f;
    }
}
