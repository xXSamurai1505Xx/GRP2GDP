using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    // Reference to the HealthBar script
    private HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        // Try to find the HealthBar script on the player
        healthBar = GetComponent<HealthBar>();

        // If the HealthBar script is not directly attached, try to find it in children
        if (healthBar == null)
        {
            healthBar = GetComponentInChildren<HealthBar>();
        }

        // Set the initial health on the health bar
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            Debug.LogError("No HealthBar script found on the player or its children.");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Update the health bar
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            // Handle player death (e.g., restart level, show game over screen)
            Debug.Log("Player has died!");
        }
    }
}
