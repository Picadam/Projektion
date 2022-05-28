using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 15f;

    public Transform xPos;
    public Transform yPos;
    public Transform zPos;

    private Transform nextPos = null;

    private bool animating = false;
    private Transform[] camPos;
    private int cpt;

    // Start is called before the first frame update
    void Start()
    {
        camPos = new Transform[] { zPos, yPos, xPos };
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
            if (Vector3.Distance(transform.position, nextPos.position) < 0.02f)
            {
                animating = false;
                return;
            }
            transform.SetPositionAndRotation(Vector3.Slerp(transform.position, nextPos.position, cameraSpeed * Time.deltaTime),
                                             Quaternion.Slerp(transform.rotation, nextPos.rotation, cameraSpeed * Time.deltaTime));
        }
    }

    public void SwitchCamera(int direction)
    { 
        if (!animating)
        {
            cpt = ((cpt + camPos.Length) + direction) % camPos.Length;
            Debug.Log(cpt);
            nextPos = camPos[cpt];
            animating = true;

            if (cpt == 2)
                GetComponent<Camera>().orthographicSize = 10;
            else
                GetComponent<Camera>().orthographicSize = 18;
        }
    }
}
