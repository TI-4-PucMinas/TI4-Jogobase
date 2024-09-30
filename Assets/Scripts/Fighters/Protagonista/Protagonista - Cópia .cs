using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonista_Copy : Player_Copy
{
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        dashspeed = 10;
        attack = GetComponentInChildren<Attack>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}