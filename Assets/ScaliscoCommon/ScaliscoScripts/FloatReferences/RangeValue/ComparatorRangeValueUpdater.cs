using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparatorRangeValueUpdater : MonoBehaviour {
    public RangeValue rangeValue;

    public FloatReferenceComparator comparator;

    void Start() {
        if (comparator.operation != FloatReferenceComparator.ComparisonOperator.GREATER_THAN_EQUAL_TO) {
            Debug.LogError("ComparatorRangeValueUpdater only supports >= operators");
        }
    }

    void Update() {
        rangeValue.min = 0;
        rangeValue.max = comparator.comparedWith;
        rangeValue.current = comparator.compared;
    }
}
