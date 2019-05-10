using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make a serializable object that is RangedFloatNonUnity that this is Valuable of instead of float
//      so the constant is something usable.
[System.Serializable]
public class RangedFloatReference : GenericReference<float, RangedFloat, RangeValue> {

    public RangedFloatReference(RangeValue value) : base(value) {    
    }

    public RangedFloatReference(RangedFloat value) : base(value) {
    }

    public float Min {
        get {
            switch (chosenType) {
                case Type.CONSTANT:
                    return 0;
                case Type.SCRIPTABLE_OBJECT:
                    return scriptableObjectVariable.min.Value;
                case Type.MONO_BEHAVIOUR:
                    return monoBehaviourVariable.min;
                default:
                    return 0;
            }
        }
    }

    public float Max {
        get {
            switch (chosenType) {
                case Type.CONSTANT:
                    return 100;
                case Type.SCRIPTABLE_OBJECT:
                    return scriptableObjectVariable.max.Value;
                case Type.MONO_BEHAVIOUR:
                    return monoBehaviourVariable.max;
                default:
                    return 100;
            }
        }
    }

    public float getRange() {
        return Max - Min;
    }

    public bool isAtMax() {
        return Value == Max;
    }
    public bool isAtMin() {
        return Value == Min;
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

    public float getCurrentInNewRange(float new_min, float new_max) {
        return new_min + (new_max - new_min) / (Max - Min) * (Value - Min);
    }

    public FloatReference getFloatRef() {        
        switch (chosenType) {
            case Type.CONSTANT:
                return new FloatReference(Value);
            case Type.SCRIPTABLE_OBJECT:
                return new FloatReference(scriptableObjectVariable);
            case Type.MONO_BEHAVIOUR:
                return new FloatReference(monoBehaviourVariable);
            default:
                return null;
        }
        
    }

    public static float performPingPong(float curTime, float secsForOnePingPong, RangedFloatReference rangedFloat) {
        // mult by getRange will make the ping pong go just as fast for any range
        float currentAValueInPingPong = curTime * rangedFloat.getRange() * secsForOnePingPong;

        return PingPongBetweenValues(currentAValueInPingPong, rangedFloat.Min, rangedFloat.Max);
    }

    public static float performPingPong(float curTime, float secsForOnePingPong, float min, float max) {
        // mult by getRange will make the ping pong go just as fast for any range
        float currentAValueInPingPong = curTime * (max - min) * secsForOnePingPong;

        return PingPongBetweenValues(currentAValueInPingPong, min, max);
    }

    // TODO: This needs a unit test more than anything
    private static float PingPongBetweenValues(float aValue, float aMin, float aMax) {
        return Mathf.PingPong(aValue, aMax - aMin) + aMin;
    }
}

// Only subclassing from RangeValue because its too hard to replace RV.
// We should also make this whole Hierarchy polymorphism based rather than inheritance based
//      by mking FloatRefBehaviours abstract. 
//      This will fix the annoying extra variables that are present.
public class RangedFloatReferenceBehaviour : RangeValue {
    [SerializeField]
    private RangedFloatReference reference;

    public void setReference(RangedFloatReference newRef) {
        reference = newRef;
        floatRef = reference.getFloatRef();
    }
    public void setReference(RangedFloatReferenceBehaviour newRef) {
        setReference(new RangedFloatReference(newRef));
    }
    public void setReference(RangedFloat newRef) {
        setReference(new RangedFloatReference(newRef));
    }

    void Start() {
        floatRef = reference.getFloatRef();

    }

    void Update() {
        max = reference.Max;
        min = reference.Min;
    }
}
