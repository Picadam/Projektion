using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyScript : EnemyScript
{

    private Vector3 moveDir;
    private float distance;
    private Rigidbody rb;

    public float moveForce;
    public Transform startPoint, endPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        distance = Vector3.Distance(startPoint.position, endPoint.position);
        moveDir = endPoint.position - startPoint.position;
        moveDir.Normalize();
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = moveDir * moveForce * Time.deltaTime;

        transform.Translate(velocity.x, 0, velocity.z, Space.World);

        if (Distance(transform.position, endPoint.position) < 0.2)
        {
            var temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;

            distance = Vector3.Distance(startPoint.position, endPoint.position);
            moveDir *= -1;
            transform.rotation = Quaternion.LookRotation(transform.forward*-1);
        }
    }

    private float Distance(Vector3 vec1, Vector3 vec2)
    {
        return Vector2.Distance(new Vector2(vec1.x, vec1.z), new Vector2(vec2.x, vec2.z));
    }
}
