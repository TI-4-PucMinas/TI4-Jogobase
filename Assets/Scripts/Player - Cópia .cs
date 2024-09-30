using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour,IFrameCheckHandler
{
    protected Rigidbody2D rb;

    protected bool airborne = false;
    protected float speed;
    protected float dashspeed;
    protected bool is_dashing;
    private List<GameplayInput> currentInputs;
    protected Animator animator;
    public Attack attack;
    private Vector2 attack_pos;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attack_pos = new Vector2(transform.position.x + 0.6f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x == 0)
        {
            animator.SetTrigger("Stop");
        }

    }

    public void Action_Player(List<GameplayInput> inputs)
    {
        for(int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].Name == "Right")
            {
                animator.SetTrigger("Run");
                moveRight();
            }
            else if (inputs[i].Name == "Left")
            {
                animator.SetTrigger("Run");
                moveLeft();
            }
            else if (inputs[i].Name == "X")
            {
                animator.SetTrigger("Attack");
                attack.GetComponent<Attack>().Ataque(50,attack_pos);
            }
            
        }
    }

    protected void moveRight()
    {
        if (is_dashing)
        {
            rb.velocity = new Vector2 (dashspeed,rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        
    }

    protected void moveLeft()
    {
        if (is_dashing)
        {
            rb.velocity = new Vector2(-dashspeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private void HandleProcessedInputs(List<GameplayInput> inputs)
    {
        currentInputs = inputs;
    }

    protected void SetStats(float spd, float d_spd)
    {
        speed = spd;
        dashspeed = d_spd;
    }



    public void OnHitFrameStart()
    {
        throw new NotImplementedException();
    }

    public void OnHitFrameEnd()
    {
        throw new NotImplementedException();
    }

    public void OnLastFrameStart()
    {
        throw new NotImplementedException();
    }

    public void OnLastFrameEnd()
    {
        throw new NotImplementedException();
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    // Resetar o estado de "airborne" quando colidir com o chão
    //  if (collision.gameObject.CompareTag("Ground"))
    //{
    //  airborne = false;
    //}
    //}
}
