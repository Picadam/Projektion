using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    InputManager inputManager;
    PlayerLocomotion playerLocomotion;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }


    private void Update()
    {
        inputManager.Movements();
    }

    private void FixedUpdate()
    {
        playerLocomotion.PlayerActions();
    }
}
