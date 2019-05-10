using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionTextView : MonoBehaviour {

    public Text text;
    public Condition condition;
    
	void Update () {
        text.text = condition.ToString();	
	}
}
