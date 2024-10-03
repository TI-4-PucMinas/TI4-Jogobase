using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Protag : Player
{

    protected PlayerControls controls;

    void Start()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        atacante = GetComponentInChildren<Attack>();
        clipEX = new AnimationClipEX
        {
            animator = animator,
            layerNumber = 0,
        };

    }

    void Update()
    {
        if (!onGround)
        {
            Debug.Log("no ar");
            animator.SetBool("Pulando", true);
        }

        if (onGround)
        {
            Debug.Log("no chao");
            animator.SetBool("Pulando", false);
        }


        if (onGround && !isAttacking)
        {

            if (horizontal == 0f) { animator.SetBool("Run", false); }

            if (horizontal > 0f)
            {
                animator.SetBool("Run", true);
                Debug.Log("andando pra direita");

            }
            else if (horizontal < 0f)
            {
                animator.SetBool("Run", true);
                Debug.Log("andando pra outro lado");
            }

        }


        if (!isAttacking)
        {
            if (onGround)
            {
                rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            }
            else if (onAirD)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else if (onAirA)
            {
                rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
            }
        }
    }
}