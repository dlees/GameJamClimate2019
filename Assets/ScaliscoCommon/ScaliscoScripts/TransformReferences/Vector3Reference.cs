using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Vector3Reference : GenericReference<Vector3, Vector3SO, Vector3Provider> {
    public Vector3Reference(Vector3 value) : base(value) { }
}

public class Vector3SO : ScriptableObject, Valueable<Vector3> {
    public Vector3 Vector3;
    public Vector3 Value {
        get {
            return Vector3;
        }

        set {
            Vector3 = value;
        }
    }
}
