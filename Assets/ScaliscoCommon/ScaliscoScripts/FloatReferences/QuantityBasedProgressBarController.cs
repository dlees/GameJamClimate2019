using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityBasedProgressBarController : MonoBehaviour {

    public FloatReference quantity;
    public RangedFloatReference rangedFloat;

	void Update () {
        rangedFloat.increment(Time.deltaTime * quantity.Value);
	}
}
