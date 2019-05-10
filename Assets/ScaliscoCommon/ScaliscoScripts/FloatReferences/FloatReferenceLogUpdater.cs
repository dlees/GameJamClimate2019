using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceLogUpdater : MonoBehaviour {

	public FloatReference logBase;
	public FloatReference exponentialFactor;

	public FloatReference result;
	public FloatReference input;
	public RangeValue progressToNextLog;

	void Update() {
		result.setValue(Mathf.Floor(Mathf.Log(input.Value / exponentialFactor.Value, logBase.Value)));

		// Ideally the progress bar would be split up..
		if (progressToNextLog == null) {
			return;
		}

		if (result.Value > 0) {
			progressToNextLog.min = exponentialFactor * Mathf.Pow(logBase, result.Value);
		}

		progressToNextLog.max = exponentialFactor * Mathf.Pow(logBase, result.Value + 1);
		progressToNextLog.current = input.Value;
	}

}
