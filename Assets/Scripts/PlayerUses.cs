using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUses : MonoBehaviour
{
    public GameplayInputHandler inputHandler;
    // Start is called before the first frame update
    void Start()
    {
        inputHandler = new GameplayInputHandler();  
        inputHandler.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        inputHandler.HandleHeardInputs();
        Action_Player();
    }

    private void Action_Player()
    {
        // Exemplo de como mover o personagem com base nos inputs
        foreach (var input in inputHandler.HeardInputs)
        {
            if (input.Name == "MoveLeft")
            {
                transform.Translate(Vector3.left * Time.deltaTime);
            }
            else if (input.Name == "MoveRight")
            {
                transform.Translate(Vector3.right * Time.deltaTime);
            }
            // Adicione mais condições para outros movimentos
        }
    }

    private void OnDestroy()
    {
        inputHandler.Disable();
    }
}
