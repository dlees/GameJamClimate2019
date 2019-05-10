using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceRangeValueUpdater : MonoBehaviour {

    public RangeValue rangeValue;

    public FloatReference min;
    public FloatReference max;
    public FloatReference cur;

	// Update is called once per frame
    void Update() {
        rangeValue.min = min;
        rangeValue.max = max;
        rangeValue.current = cur;
	}
}
