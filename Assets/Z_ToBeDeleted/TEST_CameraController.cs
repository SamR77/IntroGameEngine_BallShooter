using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2022

public class TEST_CameraController : MonoBehaviour
{
    public float cameraSmoothingFactor = 1;
    public float LookUpMax = 60;
    public float LookUpMin = -60;

    public Transform cameraTransform;

    private Quaternion camRotation;

    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothingFactor * (-1);   // look up/down
        camRotation.y += Input.GetAxis("Mouse Y") * cameraSmoothingFactor;          // Look left/right

        camRotation.x = Mathf.Clamp(camRotation.x, LookUpMin, LookUpMax);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
