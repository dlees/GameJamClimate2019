using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RangeValueTextView : MonoBehaviour {
    
    public RangeValue value;
    public Text text;
    public TMP_Text tmpText;
    public string formatString = "{0}";

	void Update () {
        string result = String.Format(formatString, NumberConverter.getString(value.current, "{0:F0}"), NumberConverter.getString(value.max, "{0:F0}"));
        if (text) {
            text.text = result;
        }
        if (tmpText) {
            tmpText.text = result;
        }
	}
}
