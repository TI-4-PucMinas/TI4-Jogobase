using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public Player player;
    public Player enemy;
    public float distance;

    private bool gaming = true;
    private GerenciadorDvida vida1;
    private GerenciadorDvida vida2;

    // Limites da tela
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        vida1 = player.GetComponent<GerenciadorDvida>();
        vida2 = enemy.GetComponent<GerenciadorDvida>();
        // Definir o tamanho ortogr�fico fixo da c�mera
        Camera.main.orthographicSize = 5.265842f;

        // Ajustar o scale da c�mera ao m�nimo poss�vel
        AdjustCameraScale();

        // Calcular os limites da c�mera
        UpdateCameraLimits();
    }

    void Update()
    {
        // Impedir que o player e o enemy saiam dos limites da tela
        RestrictPlayerMovement(player);
        RestrictPlayerMovement(enemy);

        if (player.transform.position.x < enemy.transform.position.x)
        {
            player.transform.localScale = new Vector3(Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y, player.transform.localScale.z);
        }
        else
        {
            player.transform.localScale = new Vector3(-Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y, player.transform.localScale.z);
        }

        if (vida2.VidaAtual <= 0 && gaming)
        {
            Debug.Log("Player 1 ganhou");
            SceneManager.LoadScene("Vitoria");
            gaming = false;
        }
        else if (vida1.VidaAtual <= 0 && gaming)
        {
            Debug.Log("Player 2 ganhou");
            gaming = false;
        }
    }

    // M�todo para restringir os movimentos dos personagens
    void RestrictPlayerMovement(Player player)
    {
        Vector3 playerPos = player.transform.position;

        // Verificar se o player est� fora dos limites e ajustar a posi��o
        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);

        // Aplicar a nova posi��o ajustada
        player.transform.position = playerPos;
    }

    void UpdateCameraLimits()
    {
        // Calcular os limites da c�mera em coordenadas do mundo
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        // Definir os limites com base nas bordas da c�mera
        minX = bottomLeft.x;
        maxX = topRight.x;
    }

    // Ajusta a escala da c�mera mantendo a propor��o da tela
    void AdjustCameraScale()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        Camera.main.aspect = aspectRatio;
    }
}
