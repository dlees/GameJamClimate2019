using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformVector3Provider : Vector3Provider {

    public Transform transformToUse;

    public override Vector3 Value {
        get {
            return new Vector3(
                transformToUse.position.x, transformToUse.position.y);
        }

        set {
            transformToUse.position.Set(value.x, value.y, value.z);
        }
    }
}
