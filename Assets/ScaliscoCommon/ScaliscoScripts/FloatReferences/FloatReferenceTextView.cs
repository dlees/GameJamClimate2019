using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatReferenceTextView : MonoBehaviour {
    
	public FloatReference reference;
    public Text text;
    public TextMeshProUGUI TMPText;
    public string formatString = "{0}";

    void Update() {
        if (text) {
            text.text = NumberConverter.getString(reference.Value, formatString);
        }
        if (TMPText) {
            TMPText.text = NumberConverter.getString(reference.Value, formatString);
        }
    }
}
