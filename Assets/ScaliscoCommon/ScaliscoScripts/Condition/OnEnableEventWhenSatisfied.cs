using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEventWhenSatisfied : MonoBehaviour {
    public ConditionReference condition;
    public UnityEvent unityEvent;
    
    void OnEnable() {
        if (condition.isConditionSatisfied()) {
            unityEvent.Invoke();
        }
    }

}
