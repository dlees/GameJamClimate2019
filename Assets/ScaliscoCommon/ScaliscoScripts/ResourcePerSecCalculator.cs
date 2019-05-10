using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePerSecCalculator : MonoBehaviour {

    private float oldValue;
    public FloatReference resourcePerSec;
    public FloatReference resource;

    void Start() {
        InvokeRepeating("updateRPS", 1, 1);   
    }

    public void updateRPS() {
        resourcePerSec.setValue(resource.Value - oldValue);
        oldValue = resource.Value;
    }
}