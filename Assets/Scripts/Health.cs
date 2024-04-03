using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject healthBar;

    public void SetHealth(float newHealth)   
    {
        currentHealth = newHealth;

        // Calculate the scale factor based on the current health
        float scaleFactor = currentHealth / maxHealth;

        // Set the scale of the Healthbar GameObject
        healthBar.transform.localScale = new Vector3(scaleFactor, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}