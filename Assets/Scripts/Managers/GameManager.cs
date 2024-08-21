using System;
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

    public void StartGame() // do I even need this? can I just call the LoadNextLevel() method in the LevelManager?    
    {
        _levelManager.LoadNextlevel();         
    }


}
