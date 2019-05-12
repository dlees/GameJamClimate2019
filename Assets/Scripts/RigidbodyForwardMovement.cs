using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyForwardMovement : MonoBehaviour {   
    
    // Physics movement variables
    public Rigidbody2D body;
    public Transform objectToMove;
    public float accel = 0.5f;
    public float turnSpeed = .025f;
    public float maxSpeed = 4.5f;
    
    private Quaternion getNewRotation(Vector3 target) {
        Quaternion q = Quaternion.AngleAxis(angleToTarget(target), Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, 1.0f);

    }
    private Quaternion getNewRotation(float scale, Vector3 target) {
        Quaternion q = Quaternion.AngleAxis(angleToTarget(target), Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, scale);

    }

    private float angleToTarget(Vector3 target) {
        Vector3 vectorToTarget = target - transform.position;
        return Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
    }

    public void MoveTowards(float moveSpeed, Vector3 target, float minDistanceToTarget) {
        //if up pressed
        if (DistanceToTarget(target) > minDistanceToTarget) {
            //add force
            body.AddRelativeForce(Vector2.up * accel);

            //if we are going too fast, cap speed
            if (body.velocity.magnitude > moveSpeed) {
                body.velocity = body.velocity.normalized * moveSpeed;
            }
        }

        //scale the amount you can turn based on current velocity so slower turning below max speed
        float scale = Mathf.Lerp(0.0005f, turnSpeed, body.velocity.magnitude / maxSpeed);
        objectToMove.rotation = getNewRotation(scale, target);
    }

    public float DistanceToTarget(Vector3 target) {
        return Vector3.Distance(target, transform.position);
    }
}
