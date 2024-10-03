using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Player
{
    private GerenciadorDvida gerenciadorDvidaEnemy;
    private float minX, maxX, minY, maxY;

    void Start()
    {

        gerenciadorDvidaEnemy = GetComponent<GerenciadorDvida>();

        // Calcular os limites da câmera em coordenadas do mundo
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Definir os limites com base nas bordas da câmera
        minX = bottomLeft.x;
        maxX = topRight.x;
    }

    void Update()
    {

        RestrictMovement();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("HitboxPlayer")) 
        {
            ReceberDano(10);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
    }

    public void ReceberDano(float dano)
    {
        if (gerenciadorDvidaEnemy != null)
        {
            gerenciadorDvidaEnemy.machuca(dano);
            

        }
    }

    void RestrictMovement()
    {
        // Restringir a posição do personagem dentro dos limites
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.position = position;
    }
}
