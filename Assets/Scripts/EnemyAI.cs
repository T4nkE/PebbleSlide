using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float moveSpeed = 5f; // Speed at which the object moves
    public float detectionRadius = 1f;

    void Start()
    {
        // Ignore collision between the tracking object and the player
        if (player != null)
        {
            Collider2D trackingCollider = GetComponent<Collider2D>();
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            if (trackingCollider != null && playerCollider != null)
            {
                Physics2D.IgnoreCollision(trackingCollider, playerCollider);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
}
