using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Vector3 moveDir;
    public float moveForce;
    public Transform startPoint, endPoint;
    private float distance;

    private void Awake()
    {
        distance = Vector3.Distance(startPoint.position, endPoint.position);
        moveDir = endPoint.position - startPoint.position;
        moveDir.Normalize();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * moveForce * Time.deltaTime);
        Arrive();
    }

    private void Arrive()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(endPoint.transform.position.x, endPoint.transform.position.z)) < 0.5)
        {
            var temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;

            distance = Vector3.Distance(startPoint.position, endPoint.position);
            transform.rotation = Quaternion.LookRotation(transform.forward*-1);
        }
    }
}
