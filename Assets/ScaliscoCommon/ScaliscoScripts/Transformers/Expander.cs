using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour {

    // Will default to current game Object if null;
    public GameObject objectToScale = null;

    // 1 = expand once. 2 = expand and shrink
    public float expansionsPerSecond = 1.0f;
    
    // The range of factors that the local scale is multiplied by
    // This means the original local scale will corelate to 1 in this range
    // Since we either start at min or max, there could be an initial change 
    // in size if we aren't starting at 1.0f
    public float minScaleFactor = 1.0f;
    public float maxScaleFactor = 2.0f;

    // Setting this to true will make us start at the max scale factor
    public bool shrinkFirst = false;

    private float originalLocalScale;
    private Vector3 originalLocalScaleVector;
	private float curTime = 0;

    void Start() {
        if (objectToScale == null) {
            objectToScale = this.gameObject;
        }
        originalLocalScale = objectToScale.transform.localScale.x;
        originalLocalScaleVector = objectToScale.transform.localScale;

        Reset();
    }

    public void Reset() {
        if (shrinkFirst) {
            curTime = 1 / expansionsPerSecond;
        } else {
            curTime = 0;
        }
        shouldStopAtStart = false;
    }

    private bool shouldStopAtStart = false;
    /// <summary>
    /// Continues expanding until reaching scale that it started at.
    /// Then disables this component.
    /// </summary>
    public void stopWhenAtStart() {
        shouldStopAtStart = true;
    }

    void Update()
    {
        if (shouldStopAtStart) {
            scaleTowardsStart();

        } else {
            performPingPong();
        }
    }

    private void scaleTowardsStart() {
        objectToScale.transform.localScale = Vector3.MoveTowards(objectToScale.transform.localScale, originalLocalScaleVector, expansionsPerSecond/3);

        if (VectorMath.FuzzyEquals(objectToScale.transform.localScale, originalLocalScaleVector)) {
            objectToScale.transform.localScale = new Vector3(originalLocalScale, originalLocalScale, originalLocalScale);
            enabled = false;
        }
    }

    private void performPingPong() {
        curTime += Time.deltaTime;
        
        float newScale = originalLocalScale * RangedFloatReference.performPingPong(curTime, expansionsPerSecond, minScaleFactor, maxScaleFactor);

        objectToScale.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

}
