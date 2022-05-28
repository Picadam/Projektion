using UnityEngine;

public class Rotate : MonoBehaviour {

    public float xForce = 0, yForce = 0, zForce = 0, speedMultiplier = 1;

    void Update () {
        this.transform.Rotate (xForce * speedMultiplier * Time.deltaTime, yForce * speedMultiplier * Time.deltaTime, zForce * speedMultiplier * Time.deltaTime);
    }

}