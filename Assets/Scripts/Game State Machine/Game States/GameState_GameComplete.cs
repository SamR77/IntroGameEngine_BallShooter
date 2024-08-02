using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_GameComplete : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {

    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        // need logic for button...
        // Return to main menu, method contained in the Level Manager
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {

    }

    public void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.storeLastState();
    }
}
