using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_LevelLoad : IGameState
{
    // The intent here is to have a state that will load the level and WAIT for all the level loading to be complete before transitioning into the gameplay state of the level... 
    // it's very possible I may not need this state at all, but it's here for now as a placeholder

    public void EnterState(GameStateManager gameStateManager)
    {
        
    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {
        
    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Switching to Aim State");
            gameStateManager.SwitchToState(gameStateManager.gameState_Aim);
        }
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {
        
    }

    public void ExitState(GameStateManager gameStateManager)
    {
        
    }
}
