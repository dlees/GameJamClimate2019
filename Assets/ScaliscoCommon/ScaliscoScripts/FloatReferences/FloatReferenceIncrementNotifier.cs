using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatReferenceIncrementNotifier : MonoBehaviour {

	public FloatReference value;
	public UnityEvent unityEvent;
    public float previousValue = 1;
    public bool shouldTrackdecrement = false;

    void Start() {
        previousValue = value.Value;
    }

    void Update() {
        if (shouldTrackdecrement) {
            if (value.Value < previousValue) {
                unityEvent.Invoke();
                previousValue = value.Value;
            }
        } else {
            if (value.Value > previousValue) {
                unityEvent.Invoke();
                previousValue = value.Value;
            }
        }
    }
}
