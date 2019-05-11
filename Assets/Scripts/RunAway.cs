using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Seeks towards a position and fires a UnityEvent when it reaches the destination.
 * 
 * */
public class RunAway : MonoBehaviour {
    public Transform objectToMove = null;
    public GameObject destination;
    public UnityEvent unityEvent;
    public FloatReference speed;

    // Physics movement variables
    public Rigidbody2D body;
    public float minDistanceToTarget = 1f;
    public float accel = 0.5f;
    public float turnSpeed = 1f;
    public float maxSpeed = 4.5f;

    public bool shouldMoveAway = false;

    void Start() {
        if (objectToMove == null) {
            objectToMove = this.gameObject.transform;
        }
        body = objectToMove.GetComponent<Rigidbody2D>();
    }

    void Update() {
        //objectToMove.position = Vector3.MoveTowards (objectToMove.position, destination.transform.position, speed);

        Vector3 target = shouldMoveAway ? getAwayFromTarget() : destination.transform.position;
        MoveTowards(speed, target);

        //objectToMove.rotation = getNewRotation();

        if (DistanceToTarget(target) <= minDistanceToTarget) {
            unityEvent.Invoke();
        }
    }

    private Vector3 getAwayFromTarget() {
        return 2 * destination.transform.position - objectToMove.position;
    }

    private Quaternion getNewRotation() {
        Quaternion q = Quaternion.AngleAxis(angleToTarget(), Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, 1.0f);

    }
    private Quaternion getNewRotation(float scale) {
        Quaternion q = Quaternion.AngleAxis(angleToTarget(), Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, scale);

    }

    private float angleToTarget() {
        Vector3 vectorToTarget = destination.transform.position - transform.position;
        return Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
    }

    public void changeDestination(GameObject newDestination) {
        destination = newDestination;
    }

    void MoveTowards(float moveSpeed, Vector3 target) {
        //if up pressed
        if (DistanceToTarget(target) > minDistanceToTarget) {
            //add force
            body.AddRelativeForce(Vector2.up * accel);

            //if we are going too fast, cap speed
            if (body.velocity.magnitude > moveSpeed) {
                body.velocity = body.velocity.normalized * moveSpeed;
            }
        }

        //float newRotation = angleToTarget() - transform.eulerAngles.z;
        //Debug.Log("Angle to target " + newRotation +"(" + angleToTarget() + ", " + transform.eulerAngles.z+")");
        ////if right/left pressed add torque to turn
        //if (Mathf.Abs(newRotation) > 0.001f)
        //{
        //scale the amount you can turn based on current velocity so slower turning below max speed
        float scale = Mathf.Lerp(0f, turnSpeed, body.velocity.magnitude / maxSpeed);
        //    //axis is opposite what we want by default
        //    body.AddTorque(-Mathf.Sign(newRotation) * scale);
        //}
        objectToMove.rotation = getNewRotation(scale);
    }

    private float DistanceToTarget(Vector3 target) {
        return Vector3.Distance(target, transform.position);
    }

}
