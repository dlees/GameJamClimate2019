using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericReferenceBehaviour<CONSTANT, REFERENCE> : MonoBehaviour, Valueable<CONSTANT>
    where REFERENCE : Valueable<CONSTANT> {

    public REFERENCE reference;

    public CONSTANT Value {
        get {
            return reference.Value;
        }

        set {
            reference.Value = value;
        }
    }

    public void setReference(REFERENCE reference) {
        this.reference = reference;
    }
}

