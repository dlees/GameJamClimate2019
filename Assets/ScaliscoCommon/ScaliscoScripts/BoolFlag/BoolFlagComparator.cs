using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolFlagComparator : Condition {
    
    public BoolFlagReference compared;
    public BoolFlagReference comparedWith;

    public override bool isConditionSatisfied() {
        return compared.Value == comparedWith.Value;
    }
}
