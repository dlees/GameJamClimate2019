using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceBehaviour : MonoBehaviour, Valueable<float> {

    public FloatReference floatRef;

    public virtual float Value {
        get {
            return floatRef.Value;
        }

        set {
            floatRef.setValue(value);
        }
    }

    public void increment(FloatReference amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(FloatReferenceBehaviour amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(FloatVariable amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(float amountToIncrement) {
        Value = Value + amountToIncrement;
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

    public string getValueAsString() {
        return NumberConverter.getString(Value, "{0}");
    }
    public string getValueAsFormattedString(string format) {
        return NumberConverter.getString(Value, format); ;
    }
}
