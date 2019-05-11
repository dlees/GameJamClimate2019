using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCondition : Condition {
    public ConditionReference condition;

    public override bool isConditionSatisfied() {
        return !condition.isConditionSatisfied();
    }
}
