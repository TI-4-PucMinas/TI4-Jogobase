using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonista : Player
{
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        dashspeed = 10;
    }

    void Update()
    {
        
    }
}