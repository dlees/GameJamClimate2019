using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ConditionSO : ScriptableObject, Valueable<bool> {
    public abstract bool isConditionSatisfied();
    
    public bool Value {
        get { return isConditionSatisfied(); }
        set { throw new System.NotImplementedException(); }
    }

}

[System.Serializable]
public class ConditionReference : GenericReferenceWithCallback<bool, ConditionSO, Condition, BoolCallback> {
    public ConditionReference(Condition value) : base(value) {
    }

    public ConditionReference(ConditionSO value) : base(value) {
    }

    public ConditionReference(bool value) : base(value) {
    }

    public bool isConditionSatisfied() {
        return Value;
    }
}