using UnityEngine;

public class InputDetector : MonoBehaviour
{
    private GameplayInputHandler inputHandler;

    void Start()
    {
        inputHandler = FindObjectOfType<PlayerUses>().GetComponent<PlayerUses>().inputHandler;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputHandler.HeardInputs.Add(new GameplayInput("MoveLeft") { StartedFrameNumber = Time.frameCount, State = InputState.Started });
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputHandler.HeardInputs.Add(new GameplayInput("MoveRight") { StartedFrameNumber = Time.frameCount, State = InputState.Started });
        }
        // Adicione mais detec��es de input conforme necess�rio
    }
}
