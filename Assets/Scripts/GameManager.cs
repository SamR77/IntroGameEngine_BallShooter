﻿using System.Collections;
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








    /*
    
    _levelManager = levelManager.GetComponent<LevelManager>();
        _uIManager = uIManager.GetComponent<UIManager>(); // this seems clunky, 2 references just to get a refernce to one script....
        startPosition = GameObject.FindWithTag("StartPos");
     
      
     
    public GameObject cameraOrbit;
    
    public GameObject BallGroup;
    


    //public GameObject levelManager;
    //public GameObject uIManager;

    private BallController _ballController;
    private LevelManager _levelManager;
    private UIManager _uIManager;

    

    private GameObject LevelInfo;
    private LevelInfo _levelInfo;

    private float stateChangeTimeStamp;
    private float checkTime;
    private float delay;

    public float BallStopCheckTime;
    public float BallStopDelayTime;

    

    
    */

    //public enum GameState { MainMenu, Aim, Rolling, LoseCheck, LevelComplete, Paused }

    //private GameState gameState;
    //private GameState LastGameState;

    // Start is called before the first frame update












    /*

    // Update is called once per frame
    void Update()
    {     
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        switch (gameState)
        {
            case GameState.MainMenu:
                _uIManager.UIMainMenu();
                //MainMenuUI.SetActive(true);
                //GamePlayUI.SetActive(false);
                //LevelCompleteUI.SetActive(false);
                //GameCompleteUI.SetActive(false);
                //LevelFailUI.SetActive(false);

                break;


            // *** AIM *** ,this mode lets you aim your shot and fire with SPACE

            case GameState.Aim:
                cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = true;

                _uIManager.UIAim();
                //MainMenuUI.SetActive(false);
                //GamePlayUI.SetActive(true);
                //LevelCompleteUI.SetActive(false);
                //GameCompleteUI.SetActive(false);
                //LevelFailUI.SetActive(false);

                _uIManager.modeText.text = "Aim with MOUSE \n & \n Shoot with SPACE";

                aimGuideMesh.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    aimGuideMesh.SetActive(false);
                    _ballController.ballShoot();
                    shotsLeft -= 1;
                    _uIManager.UpdateShotsleft(shotsLeft);
                    gameState = GameState.Rolling;
                    TimeDelay(0.1f);
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    LastGameState = GameState.Aim;
                    gameState = GameState.Paused;
                }

                break;



            // *** ROLLING *** ,after Shooting when the ball is rolling

            case GameState.Rolling:

                cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = true;

                _uIManager.modeText.text = "Wait for ball to stop";
                
                // once ball is ALMOST not moving, stop the ball outright.
                if (Time.time > checkTime) // this adds a slight delay before checking, prevents it from thinking the ball stopped before it even started moving
                {
                    if (_ballController.ballStopped == true)
                    {
                        gameState = GameState.LoseCheck;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    LastGameState = GameState.Rolling;
                    gameState = GameState.Paused;
                }  

                break;



            // *** LOSECHECK ***, after each shot is done rolling, check to see if you used up all your shots (if so you lose and level resets)

            case GameState.LoseCheck:                

                if (shotsLeft <= 0)
                {
                    cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = false;
                    aimGuideMesh.SetActive(false);

                    _uIManager.UILose();
                    //GamePlayUI.SetActive(false);
                    //LevelFailUI.SetActive(true);
                }
                else
                { gameState = GameState.Aim; }
                                                                              
                break;


            // *** LEVEL COMPLETE *** if you manage to hit the target goal, celebrate and switch to next level

            case GameState.LevelComplete:

                cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = false;

                _uIManager.UILevelComplete();
                //MainMenuUI.SetActive(false);
                //GamePlayUI.SetActive(false);

                //TODO: play Fireworks

                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                
                if (nextScene > SceneManager.sceneCountInBuildSettings -1) 
                {                    
                    _uIManager.UIGameComplete();
                    //GameCompleteUI.SetActive(true);
                }
                else
                {
                    _uIManager.UILevelComplete();
                    //LevelCompleteUI.SetActive(true);
                }      
                
                break;


            // *** PAUSED *** game can be paused from either the AIM or ROLLING State

            case GameState.Paused:
                cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = false;
                
                _uIManager.UIPaused();                
                //PauseMenuUI.SetActive(true);

                Time.timeScale = 0f;

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    UnPause();                   
                }

                break;
        }

    }









    



    public void loadNextLevel()
    {
        _levelManager.LoadNextlevel();

        _uIManager.DisableAllUIPanels();
        //LevelCompleteUI.SetActive(false);

        _ballController.StopBall();        
        gameState = GameState.Aim;
        cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = true;        
    }

    public void ReloadLevel()
    {
        _uIManager.DisableAllUIPanels();  // check to see whats the default state..        
        //LevelCompleteUI.SetActive(false);
        //PauseMenuUI.SetActive(false);


        Time.timeScale = 1f;
        _ballController.StopBall();
        _levelManager.ReloadCurrentScene();
        gameState = GameState.Aim;
        cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = true;        
    }

    public void returnToMainMenu()
    {
        _uIManager.DisableAllUIPanels(); //maybe just set to UIMainMenu
        //PauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        _levelManager.LoadMainMenu();
        gameState = GameState.MainMenu;
        ResetBallPos();
        Camera.main.transform.SetPositionAndRotation(new Vector3(-0.7f,10f,11f), Quaternion.Euler(new Vector3(45, -180, 0)));

    }
         
    void TimeDelay(float Delay)
    {
        stateChangeTimeStamp = Time.time;
        checkTime = Time.time + Delay; 
    }

    void BallStopDelay()
    {
        BallStopCheckTime = Time.time;
        BallStopDelayTime = Time.time + 0.5f;
    }

    public void UnPause()
    {
        cameraOrbit.GetComponent<MouseOrbitImproved>().enabled = true;

        _uIManager.UIAim(); 
        //PauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        gameState = LastGameState;
    }

    */




}
