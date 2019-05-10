using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedFloatImageFillAmountUpdater : MonoBehaviour {

	public Image image;
	public RangedFloatReference value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		image.fillAmount = value.getCurrentInNewRange (0, 1);
	}
}
