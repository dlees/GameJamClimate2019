using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;// Required when using Event data.

public class OnTriggerEventWhenSatisfied : MonoBehaviour
{
    public ConditionReference condition;
    public UnityEvent unityEvent;

    public void trigger() {
        if (condition.isConditionSatisfied()) {
            unityEvent.Invoke();
        }
    }
}

