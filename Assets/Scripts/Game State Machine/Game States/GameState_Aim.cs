using System;
using System.Security.Cryptography;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)


public class GameState_Aim : IGameState
{    
    public void EnterState(GameStateManager gameStateManager)
    {
        Cursor.visible = false;

        UIManager.instance.UIGamePlay();

        BallManager.instance.aimGuide.SetActive(true);
        BallManager.instance.ball.SetActive(true);
        CameraManager.instance.UseGameplayCamera();

        UIManager.instance.modeText.text = "Aim with MOUSE \n & \n Shoot with SPACE";

        // Subscribe to input events
        InputManager.instance.ShootBallEvent += HandleShootBall;
        InputManager.instance.PauseEvent += HandlePause;
    }

    #region Input Events
    private void HandleShootBall()
    {        
        BallManager.instance.ballShoot();
        GameStateManager.instance.SwitchToState(new GameState_Rolling());           
    }

    private void HandlePause()
    {
        GameStateManager.instance.Pause();
    }
    #endregion





    public void FixedUpdateState(GameStateManager gameStateManager) { }

    public void UpdateState(GameStateManager gameStateManager)
    {


        /*
        if (InputManager.instance.shootBallTriggered)
        {
            BallManager.instance.ballShoot();
            GameStateManager.instance.SwitchToState(new GameState_Rolling());
        }

        if (InputManager.instance.pauseTriggered)
        {
            GameStateManager.instance.SwitchToState(new GameState_Paused());
            // Reset the pauseTriggered flag
            InputManager.instance.pauseTriggered = false;
        }
        */

    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {
        // set aimGuide to match position of the ball
        BallManager.instance.HandleAimGuide();
    }

    public void ExitState(GameStateManager gameStateManager)
    {
        BallManager.instance.aimGuide.SetActive(false);

        // Unsubscribe from input events
        InputManager.instance.ShootBallEvent -= HandleShootBall;
        InputManager.instance.PauseEvent -= HandlePause;
    }








}

