using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator playerAnimator;


    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void PlayTargetAnimation(string animationName)
    {
        playerAnimator.CrossFade(animationName, 0.000000000000000000002f);
    }
}
