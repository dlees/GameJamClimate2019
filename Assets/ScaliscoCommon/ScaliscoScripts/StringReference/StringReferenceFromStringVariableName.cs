using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringReferenceFromStringVariableName : MonoBehaviour {
    public StringReferenceBehaviour stringReference;
    public StringReferenceBehaviour objectToRefer;

    void Start() {
        stringReference.reference = new StringReference(objectToRefer.reference.scriptableObjectVariable.name);    
    }
}
