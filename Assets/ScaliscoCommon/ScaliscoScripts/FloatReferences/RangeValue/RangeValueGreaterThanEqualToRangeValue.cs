using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeValueGreaterThanEqualToRangeValue : Condition {
    public RangeValue compared;
    public RangeValue comparedWith;

    public override bool isConditionSatisfied() {
        return compared.current >= comparedWith.current;
    }
    
    public override string ToString() {
        // TODO: We could put the format in the RangeValue
        return String.Format("{0:F0}/{1:F0} {2}", compared.current, comparedWith.current, comparedWith.identifier);
    }


}
