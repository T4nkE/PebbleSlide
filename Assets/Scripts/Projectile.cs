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
        if (transform.position.x < -15f)
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

/*
public class Projectile : MonoBehaviour
{
    // public Transform player;
    Rigidbody2D rb;

    [SerializeField] float movespeed;

    public PlayerMovement playerMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMovement>();

        // Ignore collision between the tracking object and the player
        // if (player != null)
        // {
        //     Collider2D trackingCollider = GetComponent<Collider2D>();
        //     Collider2D playerCollider = player.GetComponent<Collider2D>();
        //     if (trackingCollider != null && playerCollider != null)
        //     {
        //         Physics2D.IgnoreCollision(trackingCollider, playerCollider);
        //     }
        // }
    }

    void Start()
    {  
        if (playerMove == null){
            Debug.Log("object not found");
        }
        else {
            Debug.Log("object found");
        }


        if(playerMove.facingLeft == true)
        {
            rb.velocity = Vector2.left * movespeed;
        }
        
        if(playerMove.facingRight == true)
        {
            rb.velocity = Vector2.right * movespeed;
        }
    }

    void Update()
    {
        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
*/
