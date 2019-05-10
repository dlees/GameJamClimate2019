using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableCondition : SerializableCallback<bool> { }

public class CallbackCondition : Condition {
    public SerializableCondition condition;
 
    public override bool isConditionSatisfied() {
        return condition.Invoke();
    }
}
