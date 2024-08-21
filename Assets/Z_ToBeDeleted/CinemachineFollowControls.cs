using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineFollowControls : MonoBehaviour
{
    
    [SerializeField] private Transform followTarget;
    [SerializeField] private float distance = 7.5f;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private float minVerticalAngle = 2.0f;
    [SerializeField] private float maxVerticalAngle = 90.0f;

    [SerializeField] private Vector2 camRotation;



    // Update is called once per frame
    void Update()
    {
        camRotation += new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * rotationSpeed;
        camRotation.x = Mathf.Clamp(camRotation.x, minVerticalAngle, maxVerticalAngle);

        var target_rotation = Quaternion.Euler(camRotation);

        transform.position = followTarget.position - target_rotation * new Vector3(0f, 0f, distance); 
        transform.rotation = target_rotation;
    }
}
