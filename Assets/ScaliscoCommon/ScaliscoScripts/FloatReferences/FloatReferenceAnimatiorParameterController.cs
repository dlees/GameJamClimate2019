using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceAnimatiorParameterController : MonoBehaviour {

    public Animator animator;
    public string parameterName;

    public FloatReference floatRef;

	void Update () {
        animator.SetFloat(parameterName, floatRef.Value);
    }
}
