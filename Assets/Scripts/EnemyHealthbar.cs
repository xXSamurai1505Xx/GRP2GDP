using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    Slider healthSlider;
    //public Gradient gradient;
    public Image fill;


    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        //healthSlider.direction = Slider.Direction.RightToLeft;

        //fill.color = gradient.Evaluate(1f);
        if (healthSlider == null)
        {
            Debug.LogError("Slider component not found on GameObject: " + gameObject.name);
        }
        else
        {
            Debug.Log("HealthSlider component found successfully.");
        }
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

        //fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
