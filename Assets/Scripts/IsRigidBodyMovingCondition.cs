using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRigidBodyMovingCondition : Condition {

    public Rigidbody2D body;

    public override bool isConditionSatisfied() {
        return body.velocity.magnitude > .1f;
    }
}