using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

    public Timer timer;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.enabled = timer.enabled;

        text.text = TimeFormatedStringReference.convertToMinuteString(timer.TimeLeft);
		
	}
}
