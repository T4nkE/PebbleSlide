using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_destroy : MonoBehaviour

{
    GameObject projectile;
    [SerializeField] private float maxHealth;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            if(currentHealth > 0)
            {
                currentHealth -= 1;
                Debug.Log("Current Enemy's Health = " + currentHealth);
            }

            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
