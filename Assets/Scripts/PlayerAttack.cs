using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float damageAmount = 20f;
    public float attackRadius = 5f;
    public float attackConeAngle = 45f; // Angle in degrees
    public Button attackButton; // Reference to the UI button

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

        // Perform the attack action after a delay matching the animation duration
        float animationDuration = GetAnimationDuration("AttackAnimationName");
        Invoke("DealAreaDamage", animationDuration);
    }

    private void DealAreaDamage()
    {
        // ... existing code for dealing damage ...

        // Set the IsAttack parameter back to false to end the attack animation
        animator.SetBool("IsAttack", false);
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
