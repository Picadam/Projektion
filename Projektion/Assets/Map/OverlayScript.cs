using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverlayScript : MonoBehaviour
{
    public GameObject timer;
    public GameObject score;
    private float time = 0;
    private int scoreNumber = 0;

    private void Update()
    {
        time += Time.deltaTime;
        int intTime = (int)time;
        int oui = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = string.Format("{0:00}:{1:00}:{2:000}", oui, seconds, fraction);
        timer.GetComponent<TextMeshProUGUI>().text = timeText;
    }

    public void AddScore(int _score)
    {
        scoreNumber += _score;
        score.GetComponent<TextMeshProUGUI>().text = scoreNumber.ToString() + "Pts";
    }
}
