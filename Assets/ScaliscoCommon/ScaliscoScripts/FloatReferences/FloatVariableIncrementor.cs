using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatVariableIncrementor : MonoBehaviour {

	public FloatVariable result;
	public RangeValue additionPerSecond;
    public float multiplier = 1.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		result.increment(multiplier * additionPerSecond.current * Time.deltaTime);
	}
}
