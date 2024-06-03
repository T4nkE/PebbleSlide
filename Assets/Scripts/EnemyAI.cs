using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player; // Reference to the player object
    public float moveSpeed = 5f; // Speed at which the object moves
    public float detectionRadius = 1f;
    public float delay = 3;
    float timer;

    public GameObject HealthBar;
        
    GameObject projectile;
    [SerializeField] private double maxHealth;
    private double currentHealth;


    void Start()
    {
        // Ignore collision between the tracking object and the player
         GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            Collider2D trackingCollider = GetComponent<Collider2D>();
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            if (trackingCollider != null && playerCollider != null)
            {
                Physics2D.IgnoreCollision(trackingCollider, playerCollider);
            }
        }

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (player != null)
        {
            // Calculate the direction from the tracking object to the player
            Vector3 direction = (player.position - transform.position).normalized;
            
            // Ignore the Y component (vertical movement)
            direction.y = 0f;

            // Move towards the player if the object is outside the detection radius
            if (Vector3.Distance(transform.position, player.position) > detectionRadius)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }

            while (Vector3.Distance(transform.position, player.position) <= detectionRadius && timer > delay)
            {
                if (Vector3.Distance(transform.position, player.position) <= detectionRadius )
                {
                    dealDamage();
                    timer = 0;
                }
            }
        }
    }

    void dealDamage()
    {
        Debug.Log("Player Take Damage");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            if(currentHealth > 0)
            {
                currentHealth -= 1;
                Debug.Log("Current Enemy's Health = " + currentHealth);
                UpdateHealth();
            }

            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void UpdateHealth()
    {
        Vector3 healthScale = HealthBar.transform.localScale = 1.5;
        healthScale.x = currentHealth / maxHealth;
        HealthBar.transform.localScale = healthScale;
    }
}