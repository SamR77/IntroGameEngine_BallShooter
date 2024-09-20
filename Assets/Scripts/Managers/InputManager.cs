using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
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
    public bool pauseTriggered      { get; private set; }
 


    void Awake()
    {
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

        shootBallAction.performed += context => shootBallTriggered = true;
        shootBallAction.canceled += context => shootBallTriggered = false;

        pauseAction.performed += context => pauseTriggered = true;
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
