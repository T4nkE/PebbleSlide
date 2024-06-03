using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] pm player;

    [SerializeField] float movespeed;
    public float test;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<pm>();

            if (player != null)
            {
                if (player.facingLeft)
                {
                    rb.velocity = Vector2.left * movespeed;
                }
                else
                {
                    rb.velocity = Vector2.right * movespeed;
                }
            }
            else
            {
                Debug.LogError("Player script (pm) not found on the player GameObject.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject with tag 'Player' not found.");
        }
    }

    void Update()
    {
        if (transform.position.x < -65f || transform.position.x > 65f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
