using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatReferenceIncrementNotifier : MonoBehaviour {

	public FloatReference value;
	public UnityEvent unityEvent;
    public float previousValue = 1;

    void Start() {
        previousValue = value.Value;
    }

    void Update() {
        if (value.Value > previousValue) {
			unityEvent.Invoke ();
            previousValue = value.Value;
        }
    }

}
