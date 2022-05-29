using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCoinScript : MonoBehaviour
{
    public float rotationSpeed;
    public float speedElevation;

    private bool isCatch = false;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed*Time.deltaTime, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("coin");
            FindObjectOfType<OverlayScript>().AddScore(10);
            Destroy(gameObject);
        }
    }
}
