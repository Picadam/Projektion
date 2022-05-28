using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CubeRotationScript : MonoBehaviour
{
    PlayerControls playerControls;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

        }

        playerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec;
        if (Gamepad.all.Count > 0)
        {
            vec = playerControls.Cube.CubeRotation.ReadValue<Vector2>();
        }
        else
        {
            vec = playerControls.Cube.Mouse.ReadValue<Vector2>();
        }

        if (vec.magnitude > 0 && (playerControls.Cube.LeftClick.IsPressed() || Gamepad.all.Count > 0))
        {
            GetComponent<Rigidbody>().AddTorque(vec.y, -vec.x, 0);
        }
        else
        {
            var angularVelo = GetComponent<Rigidbody>().angularVelocity;
            GetComponent<Rigidbody>().AddTorque(-angularVelo/3);
        }
    }
}
