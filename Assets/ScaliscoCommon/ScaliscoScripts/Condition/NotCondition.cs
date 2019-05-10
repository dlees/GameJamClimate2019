using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCondition : Condition {
    [System.Obsolete("Deprecated. Use the ConditionReference instead.")]
    public Condition composite;

    public ConditionReference condition;

    void Start() {
        // ONLY here for backwards compatability.
        if (composite != null) {
            condition = new ConditionReference(composite);
        }
    }

    public override bool isConditionSatisfied() {
        return !condition.isConditionSatisfied();
    }
}
