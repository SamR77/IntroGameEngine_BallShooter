using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions, GameInput.IUIActions
{

    private GameInput _gameInput;

    #region Static instance
    // Public static property to access the singleton instance of GameStateManager
    public static InputManager instance
    {
        get
        {
            // If the instance is not set, instantiate a new one from resources
            if (_instance == null)
            {
                // Loads the GameStateManager prefab from Resources folder and instantiates it
                var go = (GameObject)GameObject.Instantiate(Resources.Load("InputManager"));
            }
            // Return the current instance (if set) or the newly instantiated instance
            return _instance;
        }
        // Private setter to prevent external modification of the instance
        private set { }
    }
    // Private static variable to hold the singleton instance of GameStateManager
    private static InputManager _instance;
    #endregion

    private void OnEnable()
    {
        if(_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.UI.SetCallbacks(this);
        }
        SetActionMap_Gameplay();

    }




    #region Events

    public event Action<Vector2> CameraOrbitEvent;

    public event Action ShootBallEvent;

    public event Action PauseEvent;
    public event Action ResumeEvent;

    public event Action <Vector2> CameraZoomEvent;


    #endregion



    void Awake()
    {
        #region Singleton Pattern
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion   
    }

    public void SetActionMap_Gameplay()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.UI.Disable();
    }

    public void SetActionMap_UI()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.UI.Enable();
    }



    // don't really need to feed this as the cameraOrbit input is read direcly by
    // the "Cinemachine Input Provider" component on the Gameplay Virtual Camera
    public void OnCameraOrbit(InputAction.CallbackContext context)
    {
        CameraOrbitEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnShootBall(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            ShootBallEvent?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
            SetActionMap_UI();
        }
    }

    public void OnCameraZoom(InputAction.CallbackContext context)
    {
        
    }


    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
            SetActionMap_Gameplay();
        }
    }
}
