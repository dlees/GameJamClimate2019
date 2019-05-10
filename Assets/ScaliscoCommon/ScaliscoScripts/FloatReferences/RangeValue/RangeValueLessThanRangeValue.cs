using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeValueLessThanRangeValue : Condition {
    public RangeValue compared;
    public RangeValue comparedWith;

    public override bool isConditionSatisfied() {
        return compared.current < comparedWith.current;
    }

    public override string ToString() {
        return comparedWith.current.ToString() + "/" + compared.current.ToString() + " " + comparedWith.identifier;
    }
}