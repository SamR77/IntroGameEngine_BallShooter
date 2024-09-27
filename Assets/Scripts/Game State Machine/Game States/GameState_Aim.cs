using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)


public class GameState_Aim : IGameState
{

  

    void Awake()
    {
       
    }



    public void EnterState(GameStateManager gameStateManager)
    {
        Cursor.visible = false;

        UIManager.instance.UIGamePlay();

        BallManager.instance.aimGuide.SetActive(true);
        BallManager.instance.ball.SetActive(true);
        CameraManager.instance.UseGameplayCamera();

        UIManager.instance.modeText.text = "Aim with MOUSE \n & \n Shoot with SPACE";       
    }

    public void FixedUpdateState(GameStateManager gameStateManager) { }

    public void UpdateState(GameStateManager gameStateManager)
    {
        if (InputManager.instance.shootBallTriggered)
        {
            BallManager.instance.ballShoot();
            GameStateManager.instance.SwitchToState(new GameState_Rolling());
        }

        if (InputManager.instance.pauseTriggered)
        {
            GameStateManager.instance.SwitchToState(new GameState_Paused());
        }
    }

    public void LateUpdateState(GameStateManager gameStateManager)
    {
        // set aimGuide to match position of the ball
        BallManager.instance.HandleAimGuide();
    }

    public void ExitState(GameStateManager gameStateManager)
    {
        BallManager.instance.aimGuide.SetActive(false);
    }
}

