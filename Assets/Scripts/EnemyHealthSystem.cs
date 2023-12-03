using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float maxHealth = 30f;
    [SerializeField] private float currentHealth;
    public GameObject spawnPrefab;

    // Reference to the HealthBar script
    [SerializeField] EnemyHealthbar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        // If the HealthBar script is not directly attached, try to find it in children
        if (healthBar == null)
        {
            healthBar = GetComponentInChildren<EnemyHealthbar>();
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

    public void TakenHitPoints(float damage)
    {
        currentHealth -= damage;

        // Update the health bar
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            EnemyDies();
            Debug.Log("Enemy has died!");

        }
    }

    void EnemyDies()
    {
        // Instantiate the prefab at the enemy's position
        Instantiate(spawnPrefab, transform.position, Quaternion.identity);

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }



}
