using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionReferenceBehaviour : Condition {
    public ConditionReference condition;

    public override bool isConditionSatisfied() {
        return condition.Value;
    }
}
