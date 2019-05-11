using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventWhenSatisfied : MonoBehaviour {
    public ConditionReference condition;
    public bool eventHappensOnce = false;

    public UnityEvent unityEvent;

    void Start() {

        // We add it as a listener because we don't want to evaluate this 
        // everytime the condition is satisfied.
        if (eventHappensOnce) {
            unityEvent.AddListener(turnOff);
        }
    }

	void Update() {
		if (condition.isConditionSatisfied()) {
            unityEvent.Invoke();
		}
			
	}

    public void turnOff() {
        this.enabled = false;
    }
    public void turnOn() {
        this.enabled = true;
    }
}
