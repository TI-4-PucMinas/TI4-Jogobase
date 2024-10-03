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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HitboxPlayer")) 
        {
            ReceberDano(10);
            Debug.Log("recebeu dano");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HitboxPlayer"))
        {
            Debug.Log("Inimigo saiu da hitbox, pode receber dano novamente.");
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
