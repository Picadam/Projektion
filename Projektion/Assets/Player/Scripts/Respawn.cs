using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject spawner;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        PlayerRespawn();
    }

    private void PlayerRespawn()
    {
        this.gameObject.transform.position = spawner.transform.position;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
