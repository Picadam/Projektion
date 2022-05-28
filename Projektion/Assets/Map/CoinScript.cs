using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Transform coin;
    public float rotationSpeed;
    public float speedElevation;

    private bool isCatch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin.Rotate(0, rotationSpeed*Time.deltaTime, 0);

        if (isCatch)
        {
            transform.Translate(new Vector3(0, speedElevation * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("bigCoin");
            rotationSpeed *= 20;
            isCatch = true;

            Destroy(gameObject, 5f);
        }
    }
}
