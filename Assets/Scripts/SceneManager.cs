using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private List<GameplayInput> currentInputs;
    Player player1;
    InputHandlersManager inputHandlersManager;
    GameplayInputHandler gameplayInputHandler;
    Dictionary<int, string[]> comandos;
    string[] mandos;


    public static SceneManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        // Cache references to all desired variables
        player1 = FindObjectOfType<Player>();
        comandos = new Dictionary<int, string[]>();
        comandos.Add(0, new string[] {"Dash_right", "Right", "Right" });
        comandos.Add(1, new string[] {"Dash_left", "Left", "Left" });
    }

    private void Start()
    {
        inputHandlersManager = FindObjectOfType<InputHandlersManager>();
        if (inputHandlersManager == null)
        {
            Debug.LogError("InputHandlersManager not found in scene");
        }
    }

    private void Update()
    {
        if (inputHandlersManager.InputHandlers[InputType.Gameplay] != null)
        {
            gameplayInputHandler = (GameplayInputHandler)inputHandlersManager.InputHandlers[InputType.Gameplay];
            if (gameplayInputHandler.HeardInputs.Count > 0)
            {
                mandos = CheckLink();
                for (int i = 0; i < mandos.Length; i++)
                {
                    player1.Action_Player(mandos[i]);
                }
            }
        }
        else
        {
            Debug.LogError("OU NOU");
        }
    }

    private void OnDestroy()
    {

    }

    string[] CheckLink()
    {
        string[] resposta = new string[gameplayInputHandler.HeardInputs.Count];
        int c = 0,l = 0,j;
        for (int k = 0; k < comandos.Count; k++)
        { 
                // Iterate through the heard inputs to find a potential match
                for (int i = 0; i < gameplayInputHandler.HeardInputs.Count && c < resposta.Length ; i++)
                {
                    if (l == comandos[k].Length)
                    {
                        return resposta;
                    }
                    bool sequenceMatch = true;
                    resposta[c] = gameplayInputHandler.HeardInputs[l].Name;
                
                // Check if each key in the sequence matches the corresponding heard input and is not pressed at the same time
                for (j = 0; j < comandos[k].Length && (j + i) < gameplayInputHandler.HeardInputs.Count; j++)
                    {
                        GameplayInput heardInput = gameplayInputHandler.HeardInputs[i + j];

                        if (heardInput.Name != comandos[k][j] || IsInputSimultaneous(heardInput, 2))
                        {

                            sequenceMatch = false;
                            break;
                        }


                    }

                    // If the sequence matches, perform the action (replace this with your own logic)
                    if (sequenceMatch)
                    {
                        resposta[c] = comandos[k][0];
                        l += j;
                    }
                l++;
                c++;

            }
            }
        
        // Check if there are enough heard inputs to potentially match the sequence
        return resposta;
    }

    bool IsInputSimultaneous(GameplayInput input, int maxSimultaneousCount)
    {
        // Count the occurrences of inputs at the same frame
        int simultaneousCount = 0;

        foreach (GameplayInput otherInput in gameplayInputHandler.HeardInputs)
        {
            if (otherInput != input &&
                otherInput.StartedFrameNumber == input.StartedFrameNumber &&
                otherInput.Name == input.Name) // Check if the keys are the same
            {
                simultaneousCount++;

                // Break early if the count exceeds the threshold
                if (simultaneousCount >= maxSimultaneousCount)
                    return true;
            }
        }

        return false;
    }
}
