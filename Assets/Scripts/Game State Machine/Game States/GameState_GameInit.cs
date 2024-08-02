using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public class GameState_GameInit : IGameState
{
    // This state is used the first time the game is Initialized (launched/opened)
    // It will be used to set up all default settings
    // I realize this likley could be done in the MainMenu state as returning to it could count as a game reset of sorts... but it seems cleaner to have it's own state for this

    public void EnterState(GameStateManager gameStateManager)
    {
        // This should be expanded to check if there are any missing or null references and report them back.


        // Set any default game settings here...
        // Variable01 = XX;
        // Variable02 = YY;

        // Enable Camera Mouse Orbit Script
        gameStateManager._cameraOrbit.enabled = true;

        // Enable Ball & AimGuide
        gameStateManager._gameManager.ball.SetActive(true);
        gameStateManager._gameManager.aimGuide.SetActive(true);

        // Enable all UI Panels
        gameStateManager._uIManager.gamePlayUI.SetActive(true);
        gameStateManager._uIManager.mainMenuUI.SetActive(true);
        gameStateManager._uIManager.levelCompleteUI.SetActive(true);
        gameStateManager._uIManager.levelFailedUI.SetActive(true);
        gameStateManager._uIManager.gameCompleteUI.SetActive(true);
        gameStateManager._uIManager.pauseMenuUI.SetActive(true);

        // Switch to MainMenu state
        gameStateManager.SwitchToState(new GameState_MainMenu());
    }

   


    public void FixedUpdateState(GameStateManager gameStateManager) { }
    public void UpdateState(GameStateManager gameStateManager) { }
    public void LateUpdateState(GameStateManager gameStateManager) { }


    public void ExitState(GameStateManager gameStateManager) 
    {
        gameStateManager.storeLastState();

        // Turn off all but required Gameobjects & scripts
        gameStateManager._cameraOrbit.enabled = false;

        // Disable Ball & AimGuide
        gameStateManager._gameManager.ball.SetActive(false);
        gameStateManager._gameManager.aimGuide.SetActive(false);

        // Disable all UI Panels
        gameStateManager._uIManager.DisableAllUIPanels();
    }

}
