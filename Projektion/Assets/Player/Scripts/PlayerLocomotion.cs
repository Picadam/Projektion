using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private Vector3 direction;
    private bool canJump = true;

    Transform cameraGameObject;

    Rigidbody playerRigidbody;

    InputManager inputManager;
    AnimatorManager animatorManager;

    public LayerMask groundLayer;

    public float playerSpeed = 5;
    public float playerRotationSpeed = 10;

    public float jumpForce = 30;
    public float gravityScale = 50;

    public float rayCastHeightOffset = 0.5f;

    public bool isJumping;
    public bool isGrounded;
    public bool alreadyLanded = false;

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
        PlayerFallingLanding();
    }

    private void PlayerMovement()
    {
        if(isJumping)
        {
            return;
        }

        int canGoUpDown = 1;
        canJump = false;
        if (cameraGameObject.up.y > 0.2f)
        {
            canJump = true;
            canGoUpDown = 0;
        }

        direction = cameraGameObject.right * inputManager.horizontalInput + canGoUpDown * inputManager.verticalInput * cameraGameObject.up;
        direction.Normalize();
        direction *= playerSpeed;

        playerRigidbody.velocity = direction;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerRotationSpeed * Time.deltaTime);
            animatorManager.playerAnimator.SetBool("isRunning", true);
        }
        else
            animatorManager.playerAnimator.SetBool("isRunning", false);
    }

    private void PlayerFallingLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y += rayCastHeightOffset;

        if(!isGrounded && !isJumping)
        {
            animatorManager.PlayTargetAnimation("Falling");

            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, -gravityScale, playerRigidbody.velocity.z);
        }


        if(Physics.SphereCast(rayCastOrigin, 0.0000000000001f, -Vector3.up, out hit, groundLayer))
        {
            if(!isGrounded)
            {
                animatorManager.PlayTargetAnimation("Landing");
            }

            isGrounded = true;
            if(!alreadyLanded)
            {
                FindObjectOfType<AudioManager>().Play("landing");
                alreadyLanded = true;
            }
        }
        else
        {
            isGrounded = false;
            alreadyLanded = false;
        }
    }

    public void PlayerJumping()
    {
        if(isGrounded && canJump)
        {
            animatorManager.playerAnimator.SetBool("isJumping", true);
            animatorManager.PlayTargetAnimation("Jump");

            if(alreadyLanded)
            {
                FindObjectOfType<AudioManager>().Play("jump");
            }
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, jumpForce, playerRigidbody.velocity.z);
        }
    }

    private void Step()
    {
        FindObjectOfType<AudioManager>().Play("step");
    }

    
}
