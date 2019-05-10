using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnythingTextView : MonoBehaviour {

    public Text text;
    public Anything anything;
    public string anythingKey;
    public string formatString = "{0}";

	void Update () {
        if (!anything.data.ContainsKey(anythingKey)) {
            return;
        }
        text.text = string.Format(formatString,(string)anything.data[anythingKey]);
	}
}
