using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRandomVector3Provider : Vector3Provider {

    public Transform topRight;
    public Transform bottomLeft;
    
    public override Vector3 Value {
        get {
            return new Vector3(
                Random.Range(bottomLeft.position.x, topRight.position.x),
                Random.Range(bottomLeft.position.y, topRight.position.y));
        }

        set {
            throw new System.NotImplementedException();
        }
    }
}
