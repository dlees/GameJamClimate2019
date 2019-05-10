using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedFloat : FloatVariable {
	public FloatReference min;
	public FloatReference max;

	public override float Value {
		set {
			base.Value = getValueInRange(value);
		}
	}

    private void OnEnable() {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

	public bool isAtMax() {
		return Value == max.Value;
	}
	public bool isAtMin() {
		return Value == min.Value;
	}

	public float getRange() {
		return max.Value - min.Value;
	}

	public float getCurrentInNewRange(float new_min, float new_max) {
		return new_min + (new_max - new_min) / (max.Value - min.Value) * (Value - min.Value);
	}

	private float getValueInRange(float value) {
		// TODO: REMOVE THIS if we find a way to initialize min and max before the first set of current.
		if (max == null || min == null)
			return value;
		
		if (value > max.Value) {
			return max.Value;
		}
		else if (value < min.Value) {
			return min.Value;
		}
		return value;
	}
}