using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float backgroundSpeed;
    public GameObject Player;
    // public float arenaDistance;
    private float displaceBy = -5;
    private float divider = 10;
    public bool cold;

    private Rigidbody2D rb;
    
    void Awake()
    {
        // Get reference to the Rigidbody component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = Player.transform.position;
        if(cold == true)
        {
            rb.position = new Vector2(playerPosition.x * backgroundSpeed, playerPosition.y + displaceBy/divider);
        }
        if(cold == false)
        {
            rb.position = new Vector2(playerPosition.x * backgroundSpeed, rb.position.y);
        }
    }
}
