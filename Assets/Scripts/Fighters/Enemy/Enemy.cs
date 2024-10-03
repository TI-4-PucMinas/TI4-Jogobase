using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Player
{
    private GerenciadorDvida gerenciadorDvidaEnemy;

    void Start()
    {
        
        gerenciadorDvidaEnemy = GetComponent<GerenciadorDvida>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Exemplo para receber dano
        {
            ReceberDano(10);
        }
    }

    public void ReceberDano(float dano)
    {
        if (gerenciadorDvidaEnemy != null)
        {
            gerenciadorDvidaEnemy.machuca(dano); 
        }
    }
}
