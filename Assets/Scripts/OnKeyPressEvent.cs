using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyPressEvent : MonoBehaviour {

    public KeyCode key;
    public UnityEvent eventToTrigger;

    public void Update() {
        if (Input.GetKeyUp(key)) {
            eventToTrigger.Invoke();
        }
    }
}
