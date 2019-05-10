using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringCallback : SerializableCallback<string> { }

[System.Serializable]
public class StringReference : GenericReferenceWithCallback<string, StringVariableSO, StringVariable, StringCallback> {
    public StringReference(StringVariableSO value) : base(value) {
    }
    public StringReference(StringVariable value) : base(value) {
    }
    public StringReference(string value) : base(value) {
    }
}

