using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    Vector3 direction;
    Transform cameraGameObject;

    Rigidbody playerRigidbody;

    InputManager inputManager;
    AnimatorManager animatorManager;

    public LayerMask groundLayer;

    public float playerSpeed = 5;
    public float playerRotationSpeed = 10;
    public float jumpHeight = 10f;
    public float gravity = 5f;
    public float fallingSpeed;
    public float fallingVelocity;

    public float rayCastHeightOffset = 0.5f;

    public float inAirTimer;

    public bool isJumping;
    public bool isGrounded;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        animatorManager = GetComponent<AnimatorManager>();

        cameraGameObject = Camera.main.transform;
    }

    public void PlayerActions()
    {
        PlayerMovement();
        PlayerRotation();
        PlayerFallingLanding();
    }
    private void PlayerMovement()
    {
        direction = cameraGameObject.forward * inputManager.verticalInput;
        direction = direction + cameraGameObject.right * inputManager.horizontalInput;
        direction.Normalize();
        direction.y = 0;
        direction = direction * playerSpeed;

        Vector3 movementVelocity = direction;
        playerRigidbody.velocity = movementVelocity;

    }

    private void PlayerRotation()
    {
        Vector3 direction = Vector3.zero;

        direction = cameraGameObject.forward * inputManager.verticalInput;
        direction = direction + cameraGameObject.right * inputManager.horizontalInput;
        direction.Normalize();
        direction.y = 0;

        if(direction == Vector3.zero)
        {
            direction = transform.forward;
        }

        Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, rotation, playerRotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
    private void PlayerFallingLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;

        if(!isGrounded)
        {
            animatorManager.PlayTargetAnimation("Falling");

            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * fallingVelocity);
            playerRigidbody.AddForce(-Vector3.up * fallingSpeed * inAirTimer);
        }

        if(Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if(!isGrounded)
            {
                animatorManager.PlayTargetAnimation("Landing");
            }

            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        
    }

    public void PlayerJumping()
    {

    }

    
}
