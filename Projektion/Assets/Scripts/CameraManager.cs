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

    private Transform next_pos = null;

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
            if (Vector3.Distance(transform.position, next_pos.position) < 0.2f)
            {
                animating = false;
                return;
            }
            transform.SetPositionAndRotation(Vector3.Slerp(transform.position, next_pos.position, cameraSpeed * Time.deltaTime),
                                             Quaternion.Slerp(transform.rotation, next_pos.rotation, cameraSpeed * Time.deltaTime));
        }
    }

    public void SwitchCamera(string cam)
    { 
        if (!animating)
        {
            if (cam == "x")
            {
                next_pos = xPos;
                animating = true;
                GetComponent<Camera>().orthographic = false;
            }
            else if (cam == "y")
            {
                next_pos = yPos;
                animating = true;
                GetComponent<Camera>().orthographic = true;
            }
            else if (cam == "z")
            {
                next_pos = zPos;
                animating = true;
                GetComponent<Camera>().orthographic = true;
            }
        }
    }
}
