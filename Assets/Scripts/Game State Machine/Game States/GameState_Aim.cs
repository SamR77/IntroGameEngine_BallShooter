using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager_Backup;

public class GameState_Aim : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager._uIManager.UIGamePlay(); 
        
        gameStateManager._ballManager.aimGuide.SetActive(true);
        gameStateManager._gameManager.ball.SetActive(true);  // this should be handled by the ballManager, may be issues because this script is directly on the ball... might want to seperate the mesh so we can turn it off and on without affecting the ball itself

        gameStateManager._cameraManager.UseGameplayCamera();             

        gameStateManager._uIManager.modeText.text = "Aim with MOUSE \n & \n Shoot with SPACE";     
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
        // set aimGuide to match position of the ball
        gameStateManager._ballManager.HandleAimGuide();
    }

    public void ExitState(GameStateManager gameStateManager)
    {
        gameStateManager._ballManager.aimGuide.SetActive(false);        
        gameStateManager.storeLastState();     
    }


    public GameObject ball;









}
