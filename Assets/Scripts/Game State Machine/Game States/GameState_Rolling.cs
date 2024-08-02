using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static GameManager_Backup;

public class GameState_Rolling : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {
        // maybe wrap the next 2 in an if statement to check if the last state was paused so we can set everyting back to whats needed for this state.
        gameStateManager._uIManager.UIGamePlay();
        gameStateManager._cameraOrbit.enabled = true;
        

        gameStateManager._ballManager.aimGuide.SetActive(false);
        gameStateManager._uIManager.modeText.text = "Wait for ball to stop";        
    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        // The ballManager will watch for the ball to stop rolling and then set the ballStopped bool to true

        // rather than a bool... maybe just have this be a method thats called from the ball manager once the ball has stopped and it's time to check if the level is complete or not.
        if (gameStateManager._ballManager.ballStopped == true)
        {
            Debug.Log("Ball has stopped");
            
            if (gameStateManager._gameManager.shotsLeft > 0)
            {
                // this means the goal has not been reached and there are still shots left
                // thought... would it make sense to have a bool for LevelComplete when the goal is reached that could be checked against here? It may not be needed as the logic already in place should interrupt this state before it gets here.
                gameStateManager.SwitchToState(gameStateManager.gameState_Aim);
            }
            else if (gameStateManager._gameManager.shotsLeft <= 0)
            {
                //you failed the level you fool... trigger the level failed state
                gameStateManager.SwitchToState(gameStateManager.gameState_LevelFailed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateManager.SwitchToState(gameStateManager.gameState_Paused);
        }
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {
        // call mouse orbit method in here rather than on itself... this means we don't have to worry about turning the script off in other states, it just wont be called
    }

    public void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.storeLastState();
    }
}
