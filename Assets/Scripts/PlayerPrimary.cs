using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimary : MonoBehaviour
{

    public float primaryDamage;
    public GameObject enemy;
    private float newHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.Q)) 
        {
            currentHealth = other.gameObject.GetComponent<Health>();
            // Reduce enemy health
            newHealth = currentHealth - primaryDamage;
            Health.SetHealth(newHealth);
        }
    }
}
