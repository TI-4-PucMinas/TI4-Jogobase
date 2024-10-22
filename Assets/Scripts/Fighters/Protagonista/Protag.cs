using UnityEngine;

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
        
    }

    
}