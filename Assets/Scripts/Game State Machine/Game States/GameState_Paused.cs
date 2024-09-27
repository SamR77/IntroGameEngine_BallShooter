using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class GameState_Paused : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        UIManager.instance.UIPaused();
        CameraManager.instance.DisableCameraRotation();
    }

    public void FixedUpdateState(GameStateManager gameStateManager) {    }

    public void UpdateState(GameStateManager gameStateManager)
    {
        // Pressing ESC key will unpause the game, Switch to last state stored
        if(InputManager.instance.pauseTriggered)
        {
            GameStateManager.instance.UnPause();
            Debug.Log("Unpausing");
            InputManager.instance.pauseTriggered = false;
        }
    }

    public void LateUpdateState(GameStateManager gameStateManager)  { }



    public void ExitState(GameStateManager gameStateManager)
    {
        Time.timeScale = 1f;
        CameraManager.instance.EnableCameraRotation();
    }
}
