using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceComparatorSO : ConditionSO {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public FloatReference compared;
    public FloatComparisonOperators operation;
    public FloatReference comparedWith;

    public override bool isConditionSatisfied() {
        return operation.compare(compared, comparedWith);
    }
}