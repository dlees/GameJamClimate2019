using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopwatchRangedFloatController : MonoBehaviour {

    public RangedFloatReference rangedFloat;
    public UnityEvent unityEvent;


    public void reset() {
        rangedFloat.setValue(rangedFloat.Min);
    }

	void Update () {
        rangedFloat.increment(Time.deltaTime);

        if (rangedFloat.isAtMax()) {
            unityEvent.Invoke();
            reset();
        }

	}
}
