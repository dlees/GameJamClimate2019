using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatVariableLessThanFloatVariable : Condition {
	public FloatVariable compared;
	public FloatReference comparedWith;

    public override bool isConditionSatisfied() {
		return compared.Value < comparedWith;
    }

    public override string ToString() {
		return comparedWith.ToString() + "/" + compared.Value.ToString();
    }
}