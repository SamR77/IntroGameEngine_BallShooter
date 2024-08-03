using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject aimGuide;

    [Header("Level Info")]
    public int shotsLeft = 99;    

    [Header("Script References")]
    public GameStateManager _gameStateManager;
    public BallManager _ballManager;
    public LevelManager _levelManager;
    public UIManager _uIManager;
    public MouseOrbitImproved _cameraOrbit;

    [Header("References that need to update on scene change")]
    public LevelInfo _levelInfo;
    public GameObject startPosition;

 



    void Awake()
    {    
        _gameStateManager = GetComponent<GameStateManager>();
        _ballManager =  GetComponentInChildren<BallManager>(true);
        _levelManager = GetComponentInChildren<LevelManager>(true);
        _uIManager = GetComponentInChildren<UIManager>(true);  
    }

    void Start()
    {
        
    }

    public void StartGame()
    {
        _levelManager.LoadNextlevel();
        _gameStateManager.SwitchToState(_gameStateManager.gameState_Aim);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    { 
        int LevelCount = SceneManager.GetActiveScene().buildIndex;        
        Debug.Log("Scene Loaded: " + scene.name + " Build Index: " + scene.buildIndex);

        if(scene.buildIndex > 0)
        {
            // Get a reference to the level info Script for that level
            _levelInfo = FindObjectOfType<LevelInfo>();

            // Get the # shots(attempts) available for the level and update the UI
            shotsLeft = _levelInfo.ShotsToComplete;
            _uIManager.UpdateShotsleft(shotsLeft);

            // find the start position for the level and move the ball to that position
            startPosition = GameObject.FindWithTag("StartPos");
            ResetBallPos();

            // Update the current level # on the UI
            _uIManager.UpdateLevelCount(LevelCount);
        }
        else if (scene.buildIndex == 0)
        {
            Debug.Log("Main Menu Scene Loaded");
        }

        // (Unsuscribe) Stop listening for sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ResetBallPos()  // move to be handled by the BallManager Script
    {
        ball.transform.position = startPosition.transform.position;
        _ballManager.StopBall();
        _cameraOrbit.GetComponent<MouseOrbitImproved>().ResetCamera();
    }

}
