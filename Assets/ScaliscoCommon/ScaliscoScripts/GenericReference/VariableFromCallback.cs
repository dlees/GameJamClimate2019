using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableFromCallback<CONSTANT_TYPE, MB_TYPE, CALLBACK_TYPE> : MonoBehaviour 
    where MB_TYPE : Valueable<CONSTANT_TYPE>
    where CALLBACK_TYPE : SerializableCallback<CONSTANT_TYPE> {

    public MB_TYPE variable;
    public CALLBACK_TYPE callback;

    private void Update() {
        variable.Value = callback.Invoke();
    }
}
