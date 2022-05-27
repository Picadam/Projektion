using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}
