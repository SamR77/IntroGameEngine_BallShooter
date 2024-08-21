using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2022

public class BallManager : MonoBehaviour
{
    public Rigidbody rb_ball;
    public GameObject aimGuide;

    [Header("Script References")]
    public UIManager _uIManager;
    public GameManager _gameManager;
    public GameStateManager _gameStateManager;


    public bool ballStopped;
    public float ballMagnitudeStopThreshold = 0.1f; // Adjust this value as needed
    public float ballStopCheckDelay = 0.5f; // Adjust this value as needed

    [SerializeField, Header("Debug Output (read only)")]
    private float ballVelocityMagnitude;

    private void Start()
    {
        ballStopped = true; // the ball should be stopped at the start of the game
    }

 
    void Update()
    {
        // spits out the ball vector magnitude for debugging    
        ballVelocityMagnitude = rb_ball.velocity.magnitude;
    }

    public void ballShoot() // adds force to ball in a direction away from camera
    {
        _gameManager.shotsLeft -= 1;
        _uIManager.UpdateShotsleft(_gameManager.shotsLeft);

        ballStopped = false; // the ball should be moving at this point
        rb_ball.AddForce(aimGuide.transform.forward * 25, ForceMode.VelocityChange);
    }

    public IEnumerator CheckBallStoppedAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(ballStopCheckDelay);

        // Continuously check if the ball has stopped moving
        while (true)
        {
            if (rb_ball.velocity.magnitude < ballMagnitudeStopThreshold)
            {
                StopBall(); // Stop the ball
                ballStopped = true;
                yield break; // Exit the coroutine as the check is complete
            }

            yield return null; // Wait until the next frame and check again
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GoalTrigger")
        {
            Debug.Log("Goal Reached");
            _gameStateManager.SwitchToState(_gameManager._gameStateManager.gameState_LevelComplete);
            return;
        }

        else if (other.gameObject.tag == "ResetTrigger") 
        {
            SetBallToStartPosition();
        }
    }

    public void HandleAimGuide()
    {        
        // match location of aim guide to ball
        aimGuide.transform.position = rb_ball.transform.position;

        // Rotates aim guide around ball to match camera rotation
        Vector3 newRot = aimGuide.transform.eulerAngles;
        newRot.y = (Camera.main.transform.eulerAngles.y);
        aimGuide.transform.eulerAngles = newRot;
    }

    public void SetBallToStartPosition()
    {
        // Find Start Position object in current scene
        Transform startPosition = GameObject.FindWithTag("BallStartPosition").transform;

        StopBall(); // Stop the ball   
        rb_ball.transform.position = startPosition.transform.position;
        rb_ball.transform.rotation = startPosition.transform.rotation;
    }

    
    public void StopBall() //immediately halts the ball movement
    {
        rb_ball.isKinematic = true;
        rb_ball.isKinematic = false;
    }
    




}
