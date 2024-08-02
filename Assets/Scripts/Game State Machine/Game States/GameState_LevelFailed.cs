using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_LevelFailed : IGameState
{
    // Note: LevelCompleteState and LevelFailedState likly could be using the same UIPanel (UI_Results) 
    // we can use can then feed the data into the UI panel based on the state that is active
    // This may require enabling/disbleing some buttons for different logic?

    public void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager._uIManager.UILevelFailed();
        gameStateManager._cameraOrbit.enabled = false;
    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
      // need logic for buttons...
      // BUtton 01 Restart the level, reload the scene, logic should contained in the Level Manager
      // Button 02 Return to main menu, again contained in the Level Manager
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {

    }

    public void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager.storeLastState();
    }
}
