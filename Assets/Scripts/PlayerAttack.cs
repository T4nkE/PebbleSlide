using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform lightPoint;
    [SerializeField] private GameObject[] lightnings;
    private Animator anim;
    private PlayerMovement playerPos;
    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerPos = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        // if(Input.GetKeyDown(Q) && cooldownTimer > attackCooldown && PlayerMovement.canAttack())
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            // Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
    }
}
