using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHint : MonoBehaviour
{
    public TextMeshProUGUI hintBox;
    public string text;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
            return;

        hintBox.text = text;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag != "Player")
            return;

        hintBox.text = "";
    }
}
