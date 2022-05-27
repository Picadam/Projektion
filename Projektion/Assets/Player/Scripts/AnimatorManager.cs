using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator playerAnimator;
    private InputManager inputManager;


    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        if(inputManager.verticalInput != 0 || inputManager.horizontalInput != 0)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    public void PlayTargetAnimation(string animationName)
    {
        playerAnimator.CrossFade(animationName, 0.000000000000000000002f);
    }
}
