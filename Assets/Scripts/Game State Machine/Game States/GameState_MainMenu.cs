using UnityEngine;

public class GameState_MainMenu : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {
        gameStateManager._uIManager.UIMainMenu();

        if(gameStateManager._cameraOrbit.enabled == true)
        {
            Debug.LogError("CameraOrbit should not be enabled...");            
        }
    }

    public void FixedUpdateState(GameStateManager gameStateManager) { }
    public void UpdateState(GameStateManager gameStateManager) { }
    public void LateUpdateState(GameStateManager gameStateManager) { }
    public void ExitState(GameStateManager gameStateManager) 
    {
        gameStateManager.storeLastState();
        gameStateManager._uIManager.DisableAllUIPanels();   
    }
}
