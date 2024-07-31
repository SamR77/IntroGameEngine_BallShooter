using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_LevelFailed : IGameState
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
            //gameStateManager.SwitchToState(gameStateManager.gameplayState);
        }
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {

    }

    public void ExitState(GameStateManager gameStateManager)
    {

    }
}
