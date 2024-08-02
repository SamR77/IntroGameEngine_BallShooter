using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager_Backup;

public class GameStateManager : MonoBehaviour
{
    [Header("Debug")]       
    [SerializeField] private string lastActiveState;
    [SerializeField] private string currentActiveState;      

    [Header("Script References")]
    public UIManager _uIManager;
    public LevelManager _levelManager;
    public GameManager _gameManager;
    public MouseOrbitImproved _cameraOrbit;
    public BallManager _ballManager;

    //private variables
    private IGameState currentGameState;


    public IGameState lastGameState;





    public GameState_GameInit gameState_GameInit = new GameState_GameInit();
    public GameState_MainMenu gameState_MainMenu = new GameState_MainMenu();    
    public GameState_Aim gameState_Aim = new GameState_Aim();
    public GameState_Rolling gameState_Rolling = new GameState_Rolling();
    public GameState_LevelComplete gameState_LevelComplete = new GameState_LevelComplete();
    public GameState_GameComplete gameState_GameComplete = new GameState_GameComplete();
    public GameState_LevelFailed gameState_LevelFailed = new GameState_LevelFailed();
    public GameState_Paused gameState_Paused = new GameState_Paused();




    void Awake()
    {
        _uIManager = GetComponentInChildren<UIManager>(true);
        _levelManager = GetComponentInChildren<LevelManager>(true);
        _gameManager = GetComponentInChildren<GameManager>(true);
        _cameraOrbit = GetComponentInChildren<MouseOrbitImproved>(true);
        _ballManager = GetComponentInChildren<BallManager>(true);

        currentGameState = gameState_GameInit;
    }

    void Start()                {   currentGameState.EnterState(this);          }
    private void FixedUpdate()  {   currentGameState.FixedUpdateState(this);    }
    private void Update()
    {
        currentGameState.UpdateState(this);
        currentActiveState = currentGameState.ToString();   // display in inspector for debugging
        lastActiveState = lastGameState.ToString();         // display in inspector for debugging
    }

    private void LateUpdate()   {   currentGameState.LateUpdateState(this);     }

    public void SwitchToState(IGameState newState)
    {
        // Call the ExitState method of the current state, passing 'this' as the context
        // This allows the current state to perform any necessary cleanup or transition logic
        currentGameState.ExitState(this);

        // Update the current state to the new state provided as a parameter
        currentGameState = newState;

        // Call the EnterState method of the new current state, passing 'this' as the context
        // This allows the new state to initialize or set up as it becomes active
        currentGameState.EnterState(this);
    }
    public void ButtonResume()
    {
        gameState_Paused.UnPause(this);
    }

    public void storeLastState()
    {
        lastGameState = currentGameState;
    }

}
