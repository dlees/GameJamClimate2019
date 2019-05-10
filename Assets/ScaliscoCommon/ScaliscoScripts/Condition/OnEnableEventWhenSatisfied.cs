using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEventWhenSatisfied : MonoBehaviour {
    [System.Obsolete("Deprecated. Use the ConditionReference instead.")]
    public Condition eventWhenSatisfied;

    public ConditionReference condition;
    public UnityEvent unityEvent;

    void Start() {
        // ONLY here for backwards compatability.
        if (eventWhenSatisfied != null) {
            condition = new ConditionReference(eventWhenSatisfied);
        }
    }

    void OnEnable() {
        if (condition.isConditionSatisfied()) {
            unityEvent.Invoke();
        }
    }

}
