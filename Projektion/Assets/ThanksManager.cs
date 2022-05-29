using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanksManager : MonoBehaviour
{
    public void Exit(){
        GameObject.FindObjectOfType<GameManager>().Home();
    }
}
