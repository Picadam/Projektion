using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CubeRotationScript : MonoBehaviour
{
    PlayerControls playerControls;
    public float rotationForce;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

        }

        playerControls.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
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

        vec *= rotationForce;

        if (vec.magnitude > 0 && (playerControls.Cube.LeftClick.IsPressed() || Gamepad.all.Count > 0))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(vec.y, -vec.x, 0);
        }
        else
        {
            var angularVelo = GetComponent<Rigidbody>().angularVelocity * 2f;
            GetComponent<Rigidbody>().AddTorque(-angularVelo);
        }
    }
}
