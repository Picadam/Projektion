using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
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
        Vector3 xDir = cameraGameObject.right * inputManager.horizontalInput;
        Vector3 yDir = cameraGameObject.up * inputManager.verticalInput;

        if (cameraGameObject.up == new Vector3(0, 1, 0))
        {
            yDir = Vector3.zero;
        }

        Vector3 direction = xDir + yDir;
        direction.Normalize();
        direction *= playerSpeed;

        Vector3 movementVelocity = direction;
        playerRigidbody.velocity = movementVelocity;

    }

    private void PlayerRotation()
    {
        Vector3 xDir = cameraGameObject.right * inputManager.horizontalInput;
        Vector3 yDir = cameraGameObject.up * inputManager.verticalInput;

        if (cameraGameObject.up == new Vector3(0, 1, 0))
        {
            yDir = Vector3.zero;
        }

        Vector3 direction = xDir + yDir;
        direction.Normalize();

        Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, rotation, playerRotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
    private void PlayerFallingLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y += rayCastHeightOffset;

        if(!isGrounded)
        {
            animatorManager.PlayTargetAnimation("Falling");

            inAirTimer += Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * fallingVelocity);
            playerRigidbody.AddForce(fallingSpeed * inAirTimer * -Vector3.up);
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
        animatorManager.PlayTargetAnimation("Jumping");
    }

    
}
