using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseGameEventWhenSatisfied : MonoBehaviour {
    public ConditionReference condition;

    public GameEvent gameEvent;
    public Anything optionalEventData = null;

    

    void Update() {
        if (condition.isConditionSatisfied()) {
            gameEvent.Raise(optionalEventData);
        }

    }
}