using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthSystem : MonoBehaviour
{
    public float maxHealth = 30f;
    private float currentHealth;

    // Reference to the HealthBar components
    public Slider healthSlider;
    public Image fill;

    public GameObject spawnPrefab;

    // Reference to the Animator component
    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;

        // If healthSlider is not set in the Inspector, try to find it on the same GameObject
        if (healthSlider == null)
        {
            healthSlider = GetComponentInChildren<Slider>();
        }

        // Set the initial health on the health bar
        if (healthSlider != null)
        {
            SetMaxHealth(maxHealth);
            SetHealth(currentHealth);
        }
        else
        {
            Debug.LogError("No Slider component found on the enemy or its children.");
        }

        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    public void SetMaxHealth(float maxHealth)
    {
        //max value set in the inspector of the health bar
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;

        // Optionally, you can update the health bar appearance here
        // e.g., fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    public void TakenHitPoints(float damage)
    {
        currentHealth -= damage;

        // Trigger the hurt animation
        if (animator != null)
        {
            animator.SetTrigger("IsHurt");
        }

        // Update the health bar
        SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            StartDeathAnimation();
        }
    }

    private void StartDeathAnimation()
    {
        Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

        //// Trigger the death animation
        //if (animator != null)
        //{
        //    animator.SetTrigger("IsDead");
        //}

        //// Disable further collisions (optional)
        //Collider2D collider = GetComponent<Collider2D>();
        //if (collider != null)
        //{
        //    collider.enabled = false;
        //}

        //// Start the coroutine to wait for the animation to finish
        //StartCoroutine(WaitForAnimationAndDestroy());
    }

    //private IEnumerator WaitForAnimationAndDestroy()
    //{
    //    // Wait for the animation to finish
    //    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

    //    // Instantiate the prefab at the enemy's position
    //    Instantiate(spawnPrefab, transform.position, Quaternion.identity);

    //    // Destroy the enemy GameObject
    //    Destroy(gameObject);
    //}
}
