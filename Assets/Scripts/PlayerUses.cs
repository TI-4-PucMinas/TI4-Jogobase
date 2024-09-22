using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUses : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameplayInputHandler inputHandler;
    public bool airborne = false;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = new GameplayInputHandler();
        inputHandler.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Action_Player();
    }

    public void Action_Player()
    {
        List<GameplayInput> heardInputs = inputHandler.HeardInputs;
        foreach (GameplayInput input in heardInputs)
        {
            if (input.Name.Equals("Right"))
            {
                Debug.Log("Movendo para a direita");
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (input.Name.Equals("Left"))
            {
                Debug.Log("Movendo para a esquerda");
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else if (input.Name.Equals("Up"))
            {
                if (!airborne)
                {
                    Debug.Log("Pulando");
                    rb.velocity = new Vector2(rb.velocity.x, 5f);
                    airborne = true;
                }
            }
        }
    }

    private void OnDestroy()
    {
        inputHandler.Disable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Resetar o estado de "airborne" quando colidir com o chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            airborne = false;
        }
    }
}
