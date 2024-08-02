using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager_Backup;

public class GameState_Paused : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {
        Time.timeScale = 0f;
        gameStateManager._cameraOrbit.enabled = false;
        gameStateManager._uIManager.UIPaused();
    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        // Pressing ESC key will unpause the game, Switch to last state stored
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnPause(gameStateManager);
        }

        // need logic for buttons... 
        // Button: Resume, unpause the game, Switch to last state stored
        // Button: Restart Level, reload the scene, Method should be contained in the Level Manager
        // Button: Main Menu, Loads the Main Menu Scene, Method should be contained in the Level Manager
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UnPause(GameStateManager gameStateManager)
    {
        if (gameStateManager.lastGameState == gameStateManager.gameState_Aim)
        {
            gameStateManager.SwitchToState(gameStateManager.gameState_Aim);
        }

        else if (gameStateManager.lastGameState == gameStateManager.gameState_Rolling)
        {
            gameStateManager.SwitchToState(gameStateManager.gameState_Rolling);
        }
    }



    public void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.storeLastState();
        Time.timeScale = 1f;
    }
}
