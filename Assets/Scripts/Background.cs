using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    public float backgroundSpeed;
    public GameObject Player;
    // public float arenaDistance;


    private Rigidbody2D rb;
    
    void Awake()
    {
        // Get reference to the Rigidbody component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = Player.transform.position;

        rb.position = new Vector2(playerPosition * backgroundSpeed, rb.position.y);
    }
}
