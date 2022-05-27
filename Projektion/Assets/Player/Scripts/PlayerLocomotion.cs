using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    Vector3 direction;
    Transform cameraGameObject;

    Rigidbody playerRigidbody;

    InputManager inputManager;

    public float playerSpeed = 5;
    public float playerRotationSpeed = 10;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraGameObject = Camera.main.transform;
    }

    public void PlayerActions()
    {
        PlayerMovement();
        PlayerRotation();
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
}
