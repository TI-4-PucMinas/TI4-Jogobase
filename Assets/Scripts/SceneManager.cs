using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private List<GameplayInput> currentInputs;
    Player player1;
    InputHandlersManager inputHandlersManager;
    GameplayInputHandler gameplayInputHandler;

    public static SceneManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject);
        }

        // Cache references to all desired variables
       player1 = FindObjectOfType<Player>();

        
    }

    private void Start()
    {
        inputHandlersManager = FindObjectOfType<InputHandlersManager>();
        if(inputHandlersManager == null)
        {
            Debug.LogError("InputHandlersManager not found in scene");
        }
    }

    private void Update()
    {
        if (inputHandlersManager.InputHandlers[InputType.Gameplay] != null)
        {
            gameplayInputHandler = (GameplayInputHandler)inputHandlersManager.InputHandlers[InputType.Gameplay];
            for (int i = 0; i < gameplayInputHandler.HeardInputs.Count; i++)
            {
                player1.Action_Player(gameplayInputHandler.HeardInputs[i]);
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
