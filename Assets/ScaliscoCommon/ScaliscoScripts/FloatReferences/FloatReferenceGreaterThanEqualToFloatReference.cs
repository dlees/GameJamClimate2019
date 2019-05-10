using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceGreaterThanEqualToFloatReference : FloatReferenceComparator {

    public override bool isConditionSatisfied() {
		return compared.Value >= comparedWith.Value;
    }
    
    public override string ToString() {
        // TODO: We could put the format in the FloatReference or Variable?
		return String.Format("{0:F0} > {1:F0} = {2}", compared.Value, comparedWith.Value, (compared.Value >= comparedWith.Value).ToString());
    }


}
