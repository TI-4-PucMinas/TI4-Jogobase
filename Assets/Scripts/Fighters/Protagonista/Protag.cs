using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Protag : Player
{

    protected PlayerControls controls;


    //limites da tela
    private float minX, maxX, minY, maxY;
    void Start()
    {
        atacante = GetComponentInChildren<Attack>();
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        clipEX = new AnimationClipEX();
        animator = GetComponent<Animator>();
        clipEX.animator = animator;
        vida = GetComponentInChildren<GerenciadorDvida>();
        // Calcular os limites da câmera em coordenadas do mundo
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Definir os limites com base nas bordas da câmera
        minX = bottomLeft.x;
        maxX = topRight.x;
    }

    void Update()
    {
        if (!onGround)
        {
            //Debug.Log("no ar");
            animator.SetBool("Pulando", true);
        }

        if (onGround)
        {
            //Debug.Log("no chao");
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
        RestrictMovement();
    }

    void RestrictMovement()
    {
        // Restringir a posição do personagem dentro dos limites
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.position = position;
    }
}