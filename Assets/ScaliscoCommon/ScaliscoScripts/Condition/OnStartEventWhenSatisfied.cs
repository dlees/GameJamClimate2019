using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnStartEventWhenSatisfied : MonoBehaviour {

    public ConditionReference condition;
    public UnityEvent unityEvent;

    void Start() {
        if (condition.isConditionSatisfied()) {
            unityEvent.Invoke();
        }
    }

}
