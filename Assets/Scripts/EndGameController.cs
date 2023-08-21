using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] public Text timer;
    [SerializeField] private float roundTime;
    [SerializeField] private bool timerIsRunning;

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (roundTime > 0.1)
            {
                roundTime -= Time.deltaTime;
                UpdateLevelTimer(roundTime);
            }
            else
            {
                timerIsRunning = false;
            }
        }
        else
        {
            //Time.timeScale = 0;
            //открывается окно с переходом на следующий уровень или в меню 
            SceneManager.LoadScene(0);
        }
    }

    private void UpdateLevelTimer(float totalSeconds)
    {
        var minutes = Mathf.FloorToInt(totalSeconds / 60f);
        var seconds = Mathf.RoundToInt(totalSeconds % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
