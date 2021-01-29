using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemainig = 120;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timer;
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemainig > 0)
            {
                timeRemainig -= Time.deltaTime;
                DisplayTimer();
            }
            else
            {
                timeRemainig = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTimer()
    {
        float minutes = Mathf.FloorToInt(timeRemainig / 60);
        float seconds = Mathf.FloorToInt(timeRemainig % 60);
        timer.text = "Time Left: " + minutes + ":" + seconds;
    }
}
