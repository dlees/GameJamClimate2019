using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour {
    
    public RangeValue timerRangeValue;
    public FloatReference secsToWait;
    public UnityEvent unityEvent;
    
    private float timeLeft = 0.0f;

    public void reset() {
        timeLeft = secsToWait;
        if (timerRangeValue != null) {
            timerRangeValue.min = 0; 
            timerRangeValue.max = secsToWait;
            timerRangeValue.current = 0;
        }
    }

    void OnEnable() {
        reset();
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        
        if (timeLeft < 0) {
            timeLeft = 0;
            unityEvent.Invoke();
            reset();
        }

        if (timerRangeValue != null) {
            timerRangeValue.current += Time.deltaTime;
        }
    }
}
