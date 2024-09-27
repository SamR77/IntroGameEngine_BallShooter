using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
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


    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;


    [Header("Action Map Name References")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string cameraZoom = "CameraZoom";
    [SerializeField] private string cameraOrbit = "CameraOrbit";
    [SerializeField] private string shootBall = "ShootBall";
    [SerializeField] private string pause = "Pause";

    private InputAction cameraOrbitAction;
    private InputAction cameraZoomAction;
    private InputAction shootBallAction;
    private InputAction pauseAction;

    public float cameraZoomInput  { get; private set; }
    public Vector2 cameraOrbitInput { get; private set; }
    public bool shootBallTriggered  { get; private set; }
    public bool pauseTriggered;
 


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

        cameraZoomAction = playerControls.FindActionMap(actionMapName).FindAction(cameraZoom);
        cameraOrbitAction = playerControls.FindActionMap(actionMapName).FindAction(cameraOrbit);
        shootBallAction = playerControls.FindActionMap(actionMapName).FindAction(shootBall);
        pauseAction = playerControls.FindActionMap(actionMapName).FindAction(pause);

       RegisterInputActions();
    }

    void RegisterInputActions()
    {
        cameraZoomAction.performed += context => cameraZoomInput = context.ReadValue<float>();
        cameraZoomAction.canceled += context => cameraZoomInput =0;

        cameraOrbitAction.performed += context => cameraOrbitInput = context.ReadValue<Vector2>();
        cameraOrbitAction.canceled += context => cameraOrbitInput = Vector2.zero;

        shootBallAction.started += context => shootBallTriggered = true;
        //shootBallAction.performed += context => shootBallTriggered = true;
        shootBallAction.canceled += context => shootBallTriggered = false;

        pauseAction.started += context => pauseTriggered = true;
        //pauseAction.performed += context => pauseTriggered = true;
        pauseAction.canceled += context => pauseTriggered = false;
    }

    
    
    private void OnEnable()
    {
        cameraZoomAction.Enable();
        cameraOrbitAction.Enable();
        shootBallAction.Enable();
        pauseAction.Enable();
    }
    

    private void OnDisable()
    {
        cameraZoomAction.Disable();
        cameraOrbitAction.Disable();
        shootBallAction.Disable();
        pauseAction.Disable();
    }
    




}
