using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform objectToCompare;
    public FloatReferenceBehaviour distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance.Value = Vector3.Distance(objectToCompare.position, transform.position);
    }
}
