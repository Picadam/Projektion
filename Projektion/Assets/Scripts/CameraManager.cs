using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 5f;

    public Transform xPos;
    public Transform yPos;
    public Transform zPos;

    private Transform nextPos = null;

    private bool animating = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(zPos.position, zPos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        AnimateCamera();
    }

    private void AnimateCamera()
    {
        if (animating)
        {
            if (Vector3.Distance(transform.position, nextPos.position) < 0.2f)
            {
                animating = false;
                return;
            }
            transform.SetPositionAndRotation(Vector3.Slerp(transform.position, nextPos.position, cameraSpeed * Time.deltaTime),
                                             Quaternion.Slerp(transform.rotation, nextPos.rotation, cameraSpeed * Time.deltaTime));
        }
    }

    public void SwitchCamera(string cam)
    { 
        if (!animating)
        {
            if (cam == "x")
            {
                nextPos = xPos;
                animating = true;
                GetComponent<Camera>().orthographic = false;
            }
            else if (cam == "y")
            {
                nextPos = yPos;
                animating = true;
                GetComponent<Camera>().orthographic = true;
            }
            else if (cam == "z")
            {
                nextPos = zPos;
                animating = true;
                GetComponent<Camera>().orthographic = true;
            }
        }
    }
}
