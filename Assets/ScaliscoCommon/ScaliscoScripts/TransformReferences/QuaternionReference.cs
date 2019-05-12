using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuaternionReference : GenericReference<Quaternion, QuaternionSO, QuaternionFromTransformBehaviour> {
    public QuaternionReference(Quaternion value) : base(value) { }
}

public class QuaternionSO : ScriptableObject, Valueable<Quaternion> {
    public Quaternion Quaternion;
    public Quaternion Value {
        get {
            return Quaternion;
        }

        set {
            Quaternion = value;
        }
    }
}
