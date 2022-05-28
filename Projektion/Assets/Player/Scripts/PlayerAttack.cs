using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Respawn respawn;
    private CapsuleCollider capsuleCollider;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        respawn = GetComponent<Respawn>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider as CapsuleCollider != null && collision.gameObject.tag == "Enemy")
        {
            Debug.Log("This nigga is dead");
            Destroy(collision.gameObject);
        }

        if(collision.collider as BoxCollider != null && collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Là c'est moi qui suis mort");
            respawn.ResetScene();
        }
    }
}
