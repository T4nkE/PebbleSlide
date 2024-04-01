using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimary : MonoBehaviour
{

    public float primaryDamage;
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                // Reduce enemy health
                enemyHealth.SetHealth(enemyHealth.health - primaryDamage);
            }
        }
    }
}
