using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceIncrementor : MonoBehaviour {

	public FloatReference result;
	public FloatReference additionPerSecond;
    public float multiplier = 1.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		result.increment(multiplier * additionPerSecond.Value * Time.deltaTime);
	}
}
