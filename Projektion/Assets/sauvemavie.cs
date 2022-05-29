using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sauvemavie : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag != "Player")
            return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
