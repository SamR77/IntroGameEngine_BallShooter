using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private IGameState currentState;

    [Header("Debug")]
    public string currentActiveState;

    public GameState_MainMenu gameState_MainMenu = new GameState_MainMenu();
    public GameState_LevelLoad gameState_LevelLoad = new GameState_LevelLoad();
    public GameState_Aim gameState_Aim = new GameState_Aim();
    public GameState_Rolling gameState_Rolling = new GameState_Rolling();
    public GameState_WinCheck gameState_WinCheck = new GameState_WinCheck();
    public GameState_LevelComplete gameState_LevelComplete = new GameState_LevelComplete();
    public GameState_GameComplete gameState_GameComplete = new GameState_GameComplete();
    public GameState_LevelFailed gameState_LevelFail = new GameState_LevelFailed();


    void Start()
    {
        currentState = gameState_MainMenu;
        //SwitchToState(gameState_MainMenu);
    }

    private void FixedUpdate()
    {


        currentState.FixedUpdateState(this);
    }


    private void Update()
    {
        //debug to show current active state in inspector
        currentActiveState = currentState.ToString();

        currentState.UpdateState(this);
    }

    public void SwitchToState(IGameState newState)
    {
        // Call the ExitState method of the current state, passing 'this' as the context
        // This allows the current state to perform any necessary cleanup or transition logic
        currentState.ExitState(this);

        // Update the current state to the new state provided as a parameter
        currentState = newState;

        // Call the EnterState method of the new current state, passing 'this' as the context
        // This allows the new state to initialize or set up as it becomes active
        currentState.EnterState(this);
    
    }

}
