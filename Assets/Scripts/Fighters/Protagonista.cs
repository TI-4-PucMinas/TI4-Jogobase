using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonista : PlayerUses
{
    void Start()
    {
        speed = 5f;
        inputHandler = new GameplayInputHandler();
        inputHandler.Enable();
    }

    void Update()
    {
        Action_Player();
    }
}