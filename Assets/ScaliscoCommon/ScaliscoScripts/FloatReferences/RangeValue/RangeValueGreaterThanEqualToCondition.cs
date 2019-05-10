using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeValueGreaterThanEqualToCondition : Condition {
    public RangeValue compared;
    public float comparedWith;

    public override bool isConditionSatisfied() {
        return compared.current >= comparedWith;
    }
}
