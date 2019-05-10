using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StringReferenceTextView : MonoBehaviour {

    public Text text;
    public TextMeshProUGUI tmpText;
    public StringReference reference;
    public StringReference format = new StringReference("{0}");

    void Update() {
        if (text != null) {
            text.text = string.Format(format.Value, reference.Value);
        }
        if (tmpText != null) {
            tmpText.text = string.Format(format.Value, reference.Value); ;
        }
    }
}
