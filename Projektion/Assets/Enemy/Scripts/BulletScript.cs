using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float liveTime;
    private float startTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= liveTime)
        {
            DestroyImmediate(gameObject);
        }
    }
}
