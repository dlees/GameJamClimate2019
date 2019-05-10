using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobbler : MonoBehaviour {
    public Transform objectToMove;
    public RangedFloatReference rotationRange;
    public Vector3Reference unitVector = new Vector3Reference(Vector3.forward);
    public FloatReference wobblesPerSecond;

    private float curTime = 0.0f;

    void Update() {
        curTime += Time.deltaTime;

        float newRotation = RangedFloatReference.performPingPong(curTime, wobblesPerSecond, rotationRange);
        rotationRange.setValue(newRotation);

        setObjectsRotation(newRotation);
    }

    private void setObjectsRotation(float newRotation) {
        objectToMove.SetPositionAndRotation(objectToMove.position, Quaternion.AngleAxis(newRotation, unitVector));
    }

    public void setRotation(float newRotation) {
        rotationRange.setValue(newRotation);
        setObjectsRotation(newRotation);
    }

}