using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCubeRotator : MonoBehaviour
{
    public Vector2 turn;

    // Update is called once per frame
    void Update()
    {
        turn.x = Input.GetAxis("Mouse.X");
        turn.x = Input.GetAxis("Mouse.Y");
    }
}
