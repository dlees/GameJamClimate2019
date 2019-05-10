using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class RangeValue : FloatReferenceBehaviour {
    public string identifier;
    public float min;
    public float max;
    public RangeValueListener[] listeners;

    public float current {
        get { 
            return Value; 
        }
        set {
            Value = value;
        }
    }

    public override float Value {
        set {
            base.Value = getValueInRange(value);
            currentUpdated();
            // You could almost think of the Listener update and RangeValue check being 
            // decorators of Value. This would get rid of the inheritance And make it more reusable.
            // ALONG WITH BREAK ALL MY CODE!
        }
    }

    private void currentUpdated() {
        updateListeners();                
    }

    public bool isAtMax() {
        return current == max;
    }
    public bool isAtMin() {
        return current == min;
    }

    public float getRange() {
        return max - min;
    }

    public float getCurrentInNewRange(float new_min, float new_max) {
        return new_min + (new_max - new_min) / (max - min) * (current - min);
    }

    private float getValueInRange(float value) {
        if (value > max) {
            return max;
        }
        else if (value < min) {
            return min;
        }
        return value;
    }

    private void updateListeners() {
        foreach (var listener in listeners) {
            listener.updateValue(this);
        }
    }
}
