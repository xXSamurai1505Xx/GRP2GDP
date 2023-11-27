using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    Slider healthSlider;
    public Gradient gradient;
    public Image fill;


    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        fill.color = gradient.Evaluate(1f);
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

        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
