using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vector3Provider : MonoBehaviour, Valueable<Vector3> {

    // We are trying to use this as an interface, 
    // but some C# and Unity restrictions prevent that
    public virtual Vector3 Value {
        get {
            throw new System.NotImplementedException();
        }
        set {
            throw new System.NotImplementedException();
        }
    }
}
