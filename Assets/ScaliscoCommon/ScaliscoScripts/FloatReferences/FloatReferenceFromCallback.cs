using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceFromCallback : MonoBehaviour
{
    public FloatReference floatRef;
    public FloatCallback callback;

    private void Update() {
        floatRef.setValue(callback.Invoke());
    }
}
