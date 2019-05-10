using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatCallback : SerializableCallback<float> { }

[System.Serializable]
public class NewFloatReference : GenericReference<float, FloatVariable, FloatReferenceBehaviour> {
    public void increment(FloatReference amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(FloatVariable amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(FloatReferenceBehaviour amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(float amountToIncrement) {
        setValue(Value + amountToIncrement);
    }
}

[System.Serializable]
public class FloatReference : Valueable<float> {
	public enum FloatType {
		CONSTANT,
		FLOAT_VARIABLE,
        RANGE_VALUE,
        FLOAT_REFERENCE,
        CALLBACK
	};
    public FloatType floatType = FloatType.CONSTANT;
    public float ConstantValue;
    public FloatVariable Variable;
	public RangeValue rangeValue;
    public FloatReferenceBehaviour floatRef;
    private FloatCallback callback;

    public FloatReference() { }

    public FloatReference(float value) {
		floatType = FloatType.CONSTANT;
        ConstantValue = value;

		if (rangeValue != null || Variable != null) {
			Debug.LogWarning ("This float reference type is constant, but has variables.");
		}
    }

	public FloatReference(RangeValue value) {
		floatType = FloatType.RANGE_VALUE;
		rangeValue = value;
	}

    public FloatReference(FloatVariable value) {
		floatType = FloatType.FLOAT_VARIABLE;
		Variable = value;
	}

    public FloatReference(FloatReferenceBehaviour value) {
        floatType = FloatType.FLOAT_REFERENCE;
        floatRef = value;
    }

    public FloatReference(FloatCallback callback_) {
        floatType = FloatType.CALLBACK;
        callback = callback_;
    }

	public FloatReference(FloatReference value) {
		floatType = value.floatType;
		ConstantValue = value.Value;
		Variable = value.Variable;
		rangeValue = value.rangeValue;
        floatRef = value.floatRef;
        callback = value.callback;
	}

    public float Value {
		get {
	    	switch (floatType) {
				case FloatType.CONSTANT: 
					return ConstantValue;
				case FloatType.FLOAT_VARIABLE:
                    return Variable.Value;
                case FloatType.FLOAT_REFERENCE:
                    return floatRef.Value;
                case FloatType.RANGE_VALUE:
                    return rangeValue.current;
                case FloatType.CALLBACK:
                    return callback.Invoke();
				default:
					return ConstantValue;
				}
			}
        set {
            setValue(value);
        }
    }


    public void setValue(float value) {
		switch (floatType) {
		case FloatType.CONSTANT: 
			ConstantValue = value;
			break;
		case FloatType.FLOAT_VARIABLE:
			Variable.Value = value;
			break;
        case FloatType.FLOAT_REFERENCE:
            floatRef.Value = value;
            break;
        case FloatType.RANGE_VALUE:
			rangeValue.current = value;
			break;
		default:
            Debug.Log("Cannot set FloatRef!");
			break;
		}
	}

	public void increment(FloatReference amountToIncrement) {
        increment(amountToIncrement.Value);
	}

    public void increment(FloatVariable amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(FloatReferenceBehaviour amountToIncrement) {
        increment(amountToIncrement.Value);
    }

    public void increment(float amountToIncrement) {
        setValue(Value + amountToIncrement);
	}

    public static implicit operator float(FloatReference reference) {
        return reference.Value;
    }
}
