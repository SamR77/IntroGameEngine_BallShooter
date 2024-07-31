using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_Rolling : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {

    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Switching to WinCheck State");            
            gameStateManager.SwitchToState(gameStateManager.gameState_WinCheck);
        }
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {

    }

    public void ExitState(GameStateManager gameStateManager)
    {

    }
}
