using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rb;
    private bool facingRight = true;
    protected bool airborne = false;
    protected float speed;
    protected float dashspeed;
    protected bool is_dashing;
    private List<GameplayInput> currentInputs;

    // Start is called before the first frame update
    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Action_Player(string input)
    {
        if(input == "Right")
        {
            if(rb.velocity.x < 0)
            {
                is_dashing = false;
            }
            moveRight();
        }
        else if (input == "Left")
        {
            if (rb.velocity.x > 0)
            {
                is_dashing = true;
            }
            moveLeft();
        }
        else if(input == "Dash_right" || input == "Dash_left")
        {
            is_dashing = true;
        }
        else
        {
            is_dashing = false;
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    // Resetar o estado de "airborne" quando colidir com o chão
    //  if (collision.gameObject.CompareTag("Ground"))
    //{
    //  airborne = false;
    //}
    //}
}
