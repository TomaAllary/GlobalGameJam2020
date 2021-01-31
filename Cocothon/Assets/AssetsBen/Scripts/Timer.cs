using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemainig = 120;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timer;
    public GameObject eggCounter;
    void Start()
    {
        timerIsRunning = true;
        timer.color = new Color32(255,255, 255,255);
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
                DisplayTimer();
                Langue.EggsTotal = eggCounter.gameObject.GetComponent<TimmyCollision>().eggsInStock;
                SceneManager.LoadScene(4);
            }
        }
    }

    void DisplayTimer()
    {
        float minutes = Mathf.FloorToInt(timeRemainig / 60);
        float seconds = Mathf.FloorToInt(timeRemainig % 60);
        if(minutes == 0 && seconds <= 20)
            timer.color = new Color32(255, 0, 0, 255);            
        if (minutes == 0 && seconds == 0)
            timer.text = "Time Left: 0:00";
        else if (minutes == 0 && seconds < 10)
            timer.text = "Time Left: 0:0" + seconds;
        else
            timer.text = "Time Left: " + minutes + ":" + seconds;
    }
}
