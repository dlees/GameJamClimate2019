using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FloatReferenceComparator : Condition {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

	public enum ComparisonOperator {
		GREATER_THAN,
		LESS_THAN,
		GREATER_THAN_EQUAL_TO,
		LESS_THAN_EQUAL_TO,
		EQUALS
	}

	public FloatReference compared;

    // TODO: Use floatOperator only instead of this class's comparison operator.
    public ComparisonOperator operation;
    private FloatComparisonOperators floatOperator;

    public FloatReference comparedWith;


    void Awake() {
        floatOperator = new FloatComparisonOperators(operation.ToString());
    }

    public override bool isConditionSatisfied() {
        return floatOperator.compare(compared, comparedWith);
    }

    // DEPRECATED: Use RangeValueTextView and Comparator RangeValueUpdater instead.
	public override string ToString() {
        string variableName = compared.floatType == FloatReference.FloatType.FLOAT_VARIABLE ? compared.Variable.getName() : "";
        if (variableName == "A/s") {
            variableName = "  ";
        }

		return String.Format("{0} / {1} {2}", NumberConverter.getString(compared.Value, "{0:F0}"), NumberConverter.getString(comparedWith.Value, "{0:F0}"), variableName);
	}
}
