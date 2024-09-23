using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rb;
    
    protected bool airborne = false;
    protected float speed = 5;
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

    public void Action_Player(GameplayInput input)
    {
        if(input.Name == "Right")
        {
            moveRight();
        }
        else if (input.Name == "Left")
        {
            moveLeft();
        }
        

    }

    private void moveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void moveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    private void HandleProcessedInputs(List<GameplayInput> inputs)
    {
        currentInputs = inputs;
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
