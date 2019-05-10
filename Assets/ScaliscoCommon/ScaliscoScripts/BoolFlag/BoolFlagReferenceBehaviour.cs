using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolCallback : SerializableCallback<bool> { }

[System.Serializable]
public class BoolFlagReference : GenericReferenceWithCallback<bool, BoolFlag, BoolFlagReferenceBehaviour, BoolCallback> {
    public BoolFlagReference(bool value) : base(value) {
    }

    public void toggle() {
        setValue(!Value);
    }
}

public class BoolFlagReferenceBehaviour : MonoBehaviour, Valueable<bool> {
    public BoolFlagReference reference;

    public bool Value {
        get {
            return reference.Value;
        }
        set {
            reference.setValue(value);
        }
    }

    public void toggle() {
        reference.toggle() ;
    }
}
