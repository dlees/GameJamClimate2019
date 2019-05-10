using System;
using UnityEngine;

public class FloatVariable : ScriptableObject, Valueable<float> {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public float defaultValue;
    public float currentValue;

    public virtual float Value {
        get { return currentValue; }
        set { currentValue = value; }
    }

    public string varName = null;

    public void set(float value) {
        Value = value;
	}
	public void set(FloatVariable value) {
        Value = value.Value;
	}

    private void OnEnable() {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public void Reset() {
        Value = defaultValue;
    }

	public float get() {
        return Value;
	}

    public void increment(float amount) {
        Value += amount;
    }

    public void increment(FloatVariable amount) {
        Value += amount.Value;
    }

    public void increment(FloatReference amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(FloatReferenceBehaviour amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void decrement(float amount) {
        increment(-1 * amount);
    }

    public void decrement(FloatReference amountToIncrement) {
        increment(-1 * amountToIncrement.Value);
    }

    public void decrement(FloatReferenceBehaviour amountToIncrement) {
        increment(-1 * amountToIncrement.Value);
    }

    public void decrement(FloatVariable amountToIncrement) {
        increment(-1 * amountToIncrement.Value);
    }

    public void multiply(float v) {
        Value *= v;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public void setName(string varName_) {
        varName = varName_;
    }

    public string getName() {
        if (varName != null && varName != "") {
            return varName;
        }

        return name;
    }

}

