using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatVariableReseter : MonoBehaviour {

    // NOTE: This wasn't implented as a hash set, so contains is O(N)
    public ScriptableObjectSet variablesToSkip = null;

	public void ResetFloatVariables () {
        foreach (FloatVariable floatVar in Resources.FindObjectsOfTypeAll(typeof(FloatVariable)) as FloatVariable[]) {
            if (variablesToSkip != null && variablesToSkip.Items.Contains(floatVar)) {
                continue;
            }

        }

	}
}
