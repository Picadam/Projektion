using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float verticalInput;
    public float horizontalInput;

    public bool isJumping;

    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Jumping.performed += i => isJumping = true;
           
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void Movements()
    {
        MovementInput();
        Jump();
    }


    private void MovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }

    private void Jump()
    {
        // appeler dans locomotion
        if(isJumping)
        {
            isJumping = false;
            playerLocomotion.PlayerJumping();
        }
    }
}
