using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class LevelManager : MonoBehaviour
{
    [Header("Script References")]
    public GameManager _gameManager;
    public UIManager _uIManager;
    public BallManager _ballManager;
    public GameStateManager _gameStateManager;


    public int nextScene;
    private int currentScene;


    public void LoadNextlevel()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene <= SceneManager.sceneCountInBuildSettings)  
        {            
            LoadScene(nextScene);
            _gameStateManager.SwitchToState(_gameStateManager.gameState_Aim);
        }

        else if (nextScene > SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("All levels complete!");
        }
    }

    void LoadScene(int sceneId)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneId);
    }

    public void LoadMainMenuScene()
    {
        LoadScene(0);
        _gameStateManager.SwitchToState(_gameStateManager.gameState_GameInit);
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameStateManager.SwitchToState(_gameStateManager.gameState_Aim);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int LevelCount = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene Loaded: " + scene.name + " Build Index: " + scene.buildIndex);

        if (scene.buildIndex > 0)
        {
            // Get a reference to the level info Script for that level
            LevelInfo _levelInfo = FindObjectOfType<LevelInfo>();            

            // Get the # shots(attempts) available for the level and update the UI
            _gameManager.shotsLeft = _levelInfo.ShotsToComplete;            
            _uIManager.UpdateShotsleft(_levelInfo.ShotsToComplete);

            // Update the current level # on the UI
            _uIManager.UpdateLevelCount(LevelCount);

            // Set the ball to the current levels start position            
            _ballManager.SetBallToStartPosition();
        }
        else if (scene.buildIndex == 0)
        {
            Debug.Log("Main Menu Scene Loaded");

            // do we need to do anything here? maybe call a game reset method?
            // Switch to init state???

        }
        // (Unsuscribe) Stop listening for sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    

}



