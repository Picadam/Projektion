using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 5f;

    public Camera mainCamera;

    public Transform xPos;
    public Transform yPos;
    public Transform zPos;


    private Transform next_pos = null;

    private bool animating = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.SetPositionAndRotation(zPos.position, zPos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCameras();
    }

    private void SwitchCameras()
    { 
        if (!animating)
        {
            if (Input.GetKey(KeyCode.X))
            {
                next_pos = xPos;
                animating = true;
                mainCamera.orthographic = false;
            }
            else if (Input.GetKey(KeyCode.Y))
            {
                next_pos = yPos;
                animating = true;
                mainCamera.orthographic = true;
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                next_pos = zPos;
                animating = true;
                mainCamera.orthographic = true;
            }
        }

        if (animating)
        {
            if (Vector3.Distance(mainCamera.transform.position, next_pos.position) < 0.2f)
            {
                animating = false;
                return;
            }
            mainCamera.transform.SetPositionAndRotation(Vector3.Slerp(mainCamera.transform.position, next_pos.position, cameraSpeed * Time.deltaTime), 
                                                        Quaternion.Slerp(mainCamera.transform.rotation, next_pos.rotation, cameraSpeed * Time.deltaTime));
        }
    }
}
