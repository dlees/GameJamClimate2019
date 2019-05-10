using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldStringUpdater: MonoBehaviour {
    
    public InputField inputField;
    public StringReference stringReference;

    void Update() {
        stringReference.setValue(inputField.text);
    }
    
}
