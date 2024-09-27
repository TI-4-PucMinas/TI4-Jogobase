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

                player1.Action_Player(gameplayInputHandler.HeardInputs);
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

   
}
