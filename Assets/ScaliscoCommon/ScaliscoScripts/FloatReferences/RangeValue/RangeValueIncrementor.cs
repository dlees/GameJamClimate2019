using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeValueIncrementor : MonoBehaviour {

	public RangeValue result;
	public RangeValue additionPerSecond;
    public float multiplier = 1.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		result.current += (multiplier * additionPerSecond.current * Time.deltaTime);
	}
}
