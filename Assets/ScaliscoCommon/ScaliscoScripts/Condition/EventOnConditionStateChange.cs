using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnConditionStateChange : MonoBehaviour {
    public Condition condition;

    public UnityEvent eventWhenSatisfied;
    public UnityEvent eventWhenUnsatisfied;

    private bool conditionIsAlreadySatisfied;
    private bool conditionIsAlreadyUnsatisfied;

    void Update() {

        if (condition.isConditionSatisfied()) {
            if (!conditionIsAlreadySatisfied) {
                eventWhenSatisfied.Invoke();
                conditionIsAlreadySatisfied = true;
                conditionIsAlreadyUnsatisfied = false;
            }

        } else {
            if (!conditionIsAlreadyUnsatisfied) {
                eventWhenUnsatisfied.Invoke();
                conditionIsAlreadyUnsatisfied = true;
                conditionIsAlreadySatisfied = false;
            }
        }
    }
}