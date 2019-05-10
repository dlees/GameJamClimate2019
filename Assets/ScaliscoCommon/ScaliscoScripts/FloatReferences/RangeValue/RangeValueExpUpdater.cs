using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeValueExpUpdater : MonoBehaviour {

	public RangeValue result;
	public float initial;
	public RangeValue baseValue;
	public FloatReference exponent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		result.current = Mathf.Floor(initial * Mathf.Pow (baseValue.current, exponent.Value));
	}
}
