using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void Resume(){
        GameObject.FindObjectOfType<GameManager>().PauseResume();
    }

    public void Exit(){
        GameObject.FindObjectOfType<GameManager>().Home();
    }
}
