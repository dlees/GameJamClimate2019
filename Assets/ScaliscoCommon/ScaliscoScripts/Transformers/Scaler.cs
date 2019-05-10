using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour {

	public float secToScale = 1.0f;
	public float endingScale = 2.0f;

	private float curTime;
	private Vector3 startScale;
	private Vector3 endScale;

	void Start() {
		startScale = transform.localScale;
		endScale = Vector3.one * endingScale;
	}

	void Update()
	{
		curTime += Time.deltaTime;
		
		transform.localScale = Vector3.Lerp (startScale, endScale, curTime/(secToScale*1000));

	}
}
