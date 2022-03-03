using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerValue;
    public float timeRemaining;
    public bool timerIsRunning = false;

    public void Awake()
    {
        try
        {
            timerValue = GetComponent<Text>();
            timerValue.text = "00";
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }       
    }

    public void StartTimer()
    {
        timeRemaining = 15;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }   
        }

        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerValue.text = seconds.ToString();
    }
}
