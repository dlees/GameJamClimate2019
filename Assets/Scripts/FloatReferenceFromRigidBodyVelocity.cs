using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReferenceFromRigidBodyVelocity : MonoBehaviour
{

    public FloatReference result;
    public Rigidbody2D body;

    void Update() {
        result.Value = body.velocity.magnitude;
    }

}
