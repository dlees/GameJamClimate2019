using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedFloatBarView : MonoBehaviour {
	public RectTransform background;
	public RectTransform foreground;
	public RangedFloatReference rangedFloat;

	// Update is called once per frame
	void Update () {
        foreground.sizeDelta = new Vector2(rangedFloat.getCurrentInNewRange(0, background.rect.width), foreground.sizeDelta.y);
	}


}
