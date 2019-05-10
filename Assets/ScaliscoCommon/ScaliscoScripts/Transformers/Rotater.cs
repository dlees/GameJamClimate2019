using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Transform objectToMove;
    public FloatReference degreesPerSecond;
    public Vector3Reference unitVector;

    void Update()
    {
        objectToMove.Rotate(unitVector.Value * degreesPerSecond.Value * Time.deltaTime);
    }

    public void reverseDirection() {
        degreesPerSecond.setValue(degreesPerSecond * -1);
    }
}
