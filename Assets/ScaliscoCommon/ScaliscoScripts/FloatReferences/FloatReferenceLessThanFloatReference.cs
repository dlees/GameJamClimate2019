using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceLessThanFloatReference : Condition {
	public FloatReference compared;
	public FloatReference comparedWith;

    public override bool isConditionSatisfied() {
		return compared.Value < comparedWith.Value;
    }
}
