using UnityEngine;

public class Enemy : Player
{
    private float minX, maxX, minY, maxY;

    void Start()
    {

        vida = GetComponent<GerenciadorDvida>();

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


    private void OnTriggerExit2D(Collider2D collision)
    {
 
    }

    void RestrictMovement()
    {
        // Restringir a posição do personagem dentro dos limites
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.position = position;
    }
}
