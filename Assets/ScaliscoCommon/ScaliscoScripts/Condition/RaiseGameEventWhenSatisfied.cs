using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseGameEventWhenSatisfied : MonoBehaviour {

    [System.Obsolete("Deprecated. Use the ConditionReference instead.")]
    public Condition eventWhenSatisfied;
    public ConditionReference condition;

    public GameEvent gameEvent;
    public Anything optionalEventData = null;



    void Start() {
        // ONLY here for backwards compatability.
        if (eventWhenSatisfied != null) {
            condition = new ConditionReference(eventWhenSatisfied);
        }
    }

    void Update() {
        if (condition.isConditionSatisfied()) {
            gameEvent.Raise(optionalEventData);
        }

    }
}