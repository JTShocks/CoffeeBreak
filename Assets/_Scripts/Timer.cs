using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    private TMP_Text timerText;

    public TMP_Text TimerText => timerText;
    [SerializeField] private float timeToDisplay = 60.0f;
    private bool isRunning;
    
    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
    }

    void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }

    private void EventManagerOnTimerUpdate(float value) => timeToDisplay += value;
    private void EventManagerOnTimerStop() => isRunning = false;
    private void EventManagerOnTimerStart() => isRunning = true;

    void Update()
    {
        if(!isRunning)
        {
            //Don't let timer run if not active
            return;
        }

        //When time runs out
        if(timeToDisplay < 0.0f)
        {
            //Signal the timer has stopped
            EventManager.OnTimerStop();
            return;
        }

        //Countdown timer
        timeToDisplay += -Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
    }
}
