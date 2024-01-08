using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Animator animator; // Reference to the Animator component

    public LogicSceneManager logicSceneManager;
    public GameObject gameOverUI;
    private bool isDead = false; // Flag to check if the player is dead

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar == null)
        {
            healthBar = GetComponentInChildren<HealthBar>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

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
        if (isDead) return; // If the player is already dead, do nothing

        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
            
        }
    }

    private void Die()
    {
        isDead = true;

        // Trigger the "IsDead" animation
        if (animator != null)
        {
            animator.SetTrigger("IsDead");
        }

        // Freeze player controls (you need to implement your own logic for this)
        // For example, if you have a script handling player movement, you can disable it
        // or set a flag to stop the player from moving.
        // Example: GetComponent<PlayerMovement>().enabled = false;

        // Handle other death-related actions here (e.g., restart level, show game over screen)
        StartCoroutine(FreezeGameAfterDelay());

    }
    private IEnumerator FreezeGameAfterDelay()
    {
        yield return new WaitForSeconds(1f);  // Adjust the delay time as needed

        // Freeze the game or perform any other actions after the delay
        Time.timeScale = 0f;  // This freezes the game
        gameOverUI.SetActive(true);
        Debug.Log("Game has been frozen after player death!");
    }
}
