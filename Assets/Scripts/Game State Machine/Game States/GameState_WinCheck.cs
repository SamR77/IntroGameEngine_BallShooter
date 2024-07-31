using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_WinCheck : IGameState
{
    // not sure if we need a WinCheck state? it's possible this could all be handled in the rolling state...

    public void EnterState(GameStateManager gameStateManager)
    {

    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        
        
        /*  Pseudeocode for WinCheck State:

        if (Ball has NOT reached the goal trigger)
        {
            if(Shots > 0)           { switch to Aim State }
            else if (Shots <= 0)    { switch to LevelFailed State }
            else                    { something went wrong... what else could it be? }
        }

        else if (Ball has reached the goal trigger)
        {
            if (this is the last level) { switch to GameComplete State }
            else                        { switch to LevelComplete State }        
        }
        */     

        // add inouts to test different states, AIM, LEVELFAILED, LEVELCOMPLETE, GAMECOMPLETE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Switching to LevelComplete State");
            gameStateManager.SwitchToState(gameStateManager.gameState_Aim); gameStateManager.SwitchToState(gameStateManager.gameState_LevelComplete);
        }
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {

    }

    public void ExitState(GameStateManager gameStateManager)
    {

    }
}
