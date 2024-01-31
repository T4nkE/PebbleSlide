using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;//Speed
    private float move;

    public float jump; //Jump Power

    public bool isJumping; //Jump Check asset

    private Rigidbody2D rb;

    void Awake()
    {
        // Get reference to the Rigidbody component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

//Jump Checks

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
}