using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceMath : MonoBehaviour {

	public FloatReference result;
    public MathOperator mathOperator;
	public List<FloatReference> operands;
    	
	void Update () {
		result.setValue(mathOperator.getResult(operands));
	}
}
