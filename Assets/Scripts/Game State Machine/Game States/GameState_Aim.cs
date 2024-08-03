using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager_Backup;

public class GameState_Aim : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager._uIManager.UIGamePlay(); 
        
        gameStateManager._gameManager.aimGuide.SetActive(true);
        gameStateManager._cameraOrbit.enabled = true;

        gameStateManager._gameManager.ball.SetActive(true);

        gameStateManager._uIManager.modeText.text = "Aim with MOUSE \n & \n Shoot with SPACE";
        // Although this is just one line.. I think it's better practice to move this to the ballManager that way if there is any later changes to enabling/disabling the ball, it's all in one place
    }

    public void FixedUpdateState(GameStateManager gameStateManager)
    {

    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStateManager._ballManager.ballShoot();
            gameStateManager.SwitchToState(gameStateManager.gameState_Rolling);
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
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
        gameStateManager._ballManager.aimGuide.SetActive(false);        
        gameStateManager.storeLastState();     
    }
}
