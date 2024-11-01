using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public Vector2 movementInput;

    public float movementSpeed = 7;
    public float rotationSpeed = 15;
    private CharacterController controller;
    private Vector2 move;

    public float xLimitLeft = 2;
    public float xLimitRight = 2;

    private void Awake() //called before start
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        //HandleRotation();
    }

    private void HandleMovement() //moves player around
    {
        //might not need
        moveDirection = cameraObject.forward * inputManager.verticalInput; //moving to the direction the camera is facing * the vertical input

        moveDirection = cameraObject.forward * inputManager.horizontalInput;

        //hanndle movement input vI or mI?
        //Mathf.Clamp(inputManager.horizontalInput, xLimitLeft, xLimitRight);

        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; // allows us to move left and right as well based on horizontal input and camera direction
        moveDirection.Normalize(); // takes a vector (direction) and keeps its direction the same but changes its length to one = consistent
        moveDirection.y = 0; // dont want player to walk straght up the air or floaitng

        



        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity; //moves player based on calclations above


        //tae code
        //move = PlayerControls..Movement.ReadValue<Vector2>();
        //Vector3 forwardMovement = transform.forward;
        //var movement = forwardMovement + move.x * transform.right;
        //controller.Move(movement * movementSpeed * Time.deltaTime);

    }

    //private void HandleRotation() //adjust later - character isnt supposed to rotate on its own - supposed to rotate along side the map when changing direction from left or right
    //{
        //Vector3 targetDirection = Vector3.zero; //zero on all values starting out - target direction is the direction we want player to rotate when moving

        //targetDirection = cameraObject.forward * inputManager.verticalInput; // just like code in handlemovement
        //targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        //targetDirection.Normalize(); //always facing the direction youre about to go to
        //targetDirection.y = 0;

        //if (targetDirection == Vector3.zero)
            //targetDirection = transform.forward; //keep the rotation at the position we're looking when we stop moving

        //Quaternion targetRotation = Quaternion.LookRotation(targetDirection); //quaternions are used to calculate rotation -- looking towards target location, wherre we're looking is where we want to rotate
        //Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //slerp = rotation between point a and point b
        //using current rotation (transform.rotation), and new rotation(targetRotation), to move at the speed rate declared (rotation.speed) times time.deltaTime <- used when we want movement to change to the same speed, no matter the frame rate
        
        //transform.rotation = playerRotation;
    //}
}
