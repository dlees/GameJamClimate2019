using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Deprecated - use StringReferenceBehaviour Instead
 * */
public class StringVariable : MonoBehaviour, Valueable<string> {
    public string stringVar;

    public virtual string Value {
        get { return stringVar; }
        set { stringVar = value; }
    }

    public virtual void set(StringVariable variable) {
        Value = variable.Value;
    }
}

