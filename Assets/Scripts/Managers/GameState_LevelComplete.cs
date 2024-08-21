using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState_LevelComplete : IGameState
{

    // Note: LevelCompleteState and LevelFailedState likly could be using the same UIPanel (UI_Results) 
    // we can use can then feed the data into the UI panel based on the state that is active
    // This may require enabling/disbleing some buttons for different logic?
    public void EnterState(GameStateManager gameStateManager)
    {

        // check to see if this is the last level CheckWin() in GameManager
        // if last level then set UI For GameComplete
        // if NOT LAST level then Set UI for LevelComplete

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            gameStateManager._uIManager.UIGameComplete();
        }
        else
        {
            gameStateManager._uIManager.UILevelComplete();
        }
        gameStateManager._cameraManager.LockCameraRotation();
    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        // need logic for buttons...
        // BUtton 01 next level, load the next level in the build settings, logic should contained in the Level Manager
        // Button 02 Return to main menu, again contained in the Level Manager
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {
        gameStateManager.storeLastState();
    }

    public void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager._cameraManager.UnlockCameraRotation();
    }
}
