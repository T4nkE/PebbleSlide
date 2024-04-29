using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(Q) && cooldownTimer > attackCooldown && PlayerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void attack()
    {
        cooldownTimer = 0;
    }
}
