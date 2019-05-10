using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StringListTextView : MonoBehaviour {

    public Text text;
    public TextMeshProUGUI tmpText;
    public StringReference format;
    public List<StringReference> operands;

    void Update() {
        string result = string.Format(format, operands.Select(reference => reference.Value).ToArray());
        if (text != null) {
            text.text = result;
        }
        if (tmpText != null) {
            tmpText.text = result;
        }
    }
}
