using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventRepeater : MonoBehaviour {
    public FloatReference timesToRepeat;
    public UnityEvent eventToRepeat;

    public void repeatEvent() {
        for (int i = 0; i < timesToRepeat; i++) {
            eventToRepeat.Invoke();
        }
    }
    
    // Override the FloatRef field
    public void repeatEvent(float timesToRepeat_) {
        for (int i = 0; i < timesToRepeat_; i++) {
            eventToRepeat.Invoke();
        }
    }
}
