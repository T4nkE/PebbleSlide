using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pm : MonoBehaviour
{
    public float speed; // Speed
    private float move;
    public GameObject Left;
    public GameObject Right;
    public GameObject projPrefab; // Prefab of the projectile

    public GameObject EnemyPrefab;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;


    public float jump; // Jump Power
    
    public bool facingRight;
    public bool facingLeft;

    public bool isJumping; // Jump Check asset

    private Rigidbody2D rb;
    //public Projectile proj;

    private SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        // Get reference to the Rigidbody component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // proj = GetComponent<Projectile>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        // Flip the sprite if the character is moving left
        if (move < 0)
        {
            spriteRenderer.flipX = true;

            facingLeft = true;
            facingRight = false;
        }
        // Flip the sprite if the character is moving right
        else if (move > 0)
        {
            spriteRenderer.flipX = false;

            facingRight = true;
            facingLeft = false;
        }

        // Instantiate projectile when the Q key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(facingLeft == true)
            {
                Instantiate(projPrefab, Left.transform.position, transform.rotation);
            }
            if(facingRight == true)
            {
                Instantiate(projPrefab, Right.transform.position, transform.rotation);
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(EnemyPrefab, Spawn1.transform.position, transform.rotation);
        }
    }

    // Jump Checks
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    public bool canAttack()
    {
        return move == 0;
    }
}
