using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManeger : MonoBehaviour
{

    public Player player;
    public Player enemy;
    public float distance;

    private bool gaming = true;
    private GerenciadorDvida vida1;
    private GerenciadorDvida vida2;

    // Start is called before the first frame update
    void Start()
    {
        vida1 = player.GetComponent<GerenciadorDvida>();
        vida2 = enemy.GetComponent<GerenciadorDvida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < enemy.transform.position.x)
        {
            player.transform.localScale = new Vector3(Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y, player.transform.localScale.z);
        }
        else
        {
            player.transform.localScale = new Vector3(-Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y, player.transform.localScale.z);
        }

        if(vida2.VidaAtual <= 0 && gaming)
        {
            Debug.Log("Player 1 ganhou");
            gaming = false;
        }
        else if(vida1.VidaAtual <= 0 && gaming)
        {
            Debug.Log("Player 2 ganhou");
            gaming = false;
        }
    }
}
