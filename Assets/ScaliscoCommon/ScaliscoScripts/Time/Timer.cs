using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float countdownSeconds = 10.0f;

    private float timeLeft = 0.0f;
    public float TimeLeft
    {
        get { return timeLeft; }
    }

    void OnEnable()
    {
        timeLeft = countdownSeconds;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            timeLeft = 0;
        }
       
    }

    void OnDisable()
    {
        timeLeft = 0.0f;
    }
}
