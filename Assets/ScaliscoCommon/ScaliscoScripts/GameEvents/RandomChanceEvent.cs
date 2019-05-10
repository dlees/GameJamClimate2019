using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomChanceEvent: MonoBehaviour {

    public FloatReference percentChance; // 0-100
    public UnityEvent unityEvent;
    
    public void trigger() {
        if (Random.Range(0.000001f, 100.0f) <= percentChance) {
            unityEvent.Invoke();
        }
	}
}
