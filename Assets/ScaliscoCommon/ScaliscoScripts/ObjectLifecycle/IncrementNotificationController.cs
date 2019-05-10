using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementNotificationController : MonoBehaviour {
    
    public float value;

    public string incrementName;
    public Text valueText;

    public void construct(float value) {
        valueText.text = value.ToString() + " " + incrementName + ((isPlural()) ? "s" : "");
    }


    private bool isPlural() {
        return value != 1.0f;
    }
}
