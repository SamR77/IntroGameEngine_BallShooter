using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using JetBrains.Annotations;

public class CameraManager : MonoBehaviour
{
    public GameObject VCamGameplay;
    public GameObject VCamMainMenu;

    private CinemachineFreeLook CinemachineGameplayVcam;

    // I need to store these as I'm erasing the names to disable camera rotation
    // sometimes the game can quit without having a change to restore the original names, and they are blank on play
    // Ideally these would be read from the Input Manager, but that doesn't seem possible, so they are hardcoded for now
    // May not be an issue when we move to the new input system
    // I will also try to find a better way to Lock/Unlock the camera rotation than erasing the input axis names
    private string originalXAxisName = "Mouse X";
    private string originalYAxisName = "Mouse Y";

    private void Awake()
    {
        // get the free look camera component
        CinemachineGameplayVcam = VCamGameplay.GetComponent<Cinemachine.CinemachineFreeLook>();

        CinemachineGameplayVcam.m_XAxis.m_InputAxisName = originalXAxisName;
        CinemachineGameplayVcam.m_YAxis.m_InputAxisName = originalYAxisName;

    }



    public void UseMainMenuCamera()
    {
        VCamGameplay.SetActive(false);
        VCamMainMenu.SetActive(true);
    }

    public void UseGameplayCamera()
    {
        VCamGameplay.SetActive(true);
        VCamMainMenu.SetActive(false);
    }

    public void LockCameraRotation()
    {
        //CinemachineGameplayVcam.enabled = false;

    
        CinemachineGameplayVcam.m_XAxis.m_InputAxisName = "";
        CinemachineGameplayVcam.m_YAxis.m_InputAxisName = "";
    }

    public void UnlockCameraRotation()
    {
        //CinemachineGameplayVcam.enabled = true;

        CinemachineGameplayVcam.m_XAxis.m_InputAxisName = originalXAxisName;
        CinemachineGameplayVcam.m_YAxis.m_InputAxisName = originalYAxisName;
    }

    // set gameplay camera to a target orientation
    public void SetGameplayCameraOrientation(Vector3 targetOrientation)
    {
        VCamGameplay.transform.LookAt(targetOrientation);
    }





}
